using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using EFSecondLevelCache;
using EntityFramework.Filters;
using Microsoft.AspNet.Identity.EntityFramework;
using DNTCms.DomainClasses.Configurations.Users;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.Utility;
using Microsoft.AspNet.Identity;

namespace DNTCms.DataLayer.Context
{
    public class BaseDbContext : IdentityDbContext
        <User, Role, long, UserLogin, UserRole, UserClaim>
    {
        #region Ctor
        public BaseDbContext(string connectionString)
            : base(connectionString)
        {

        }
        #endregion

        #region Override OnModelCreating
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder));

            DbInterception.Add(new FilterInterceptor());
            DbInterception.Add(new YeKeInterceptor());

            // for full text search  DbInterception.Add(new FtsInterceptor());
            modelBuilder.Ignore<BaseEntity<Guid, long>>();
            modelBuilder.Ignore<BaseEntity<long, long>>();
            modelBuilder.Ignore<BaseEntity<long, long?>>();
            modelBuilder.Ignore<BaseComment>();
            modelBuilder.Ignore<BaseContent>();

            modelBuilder.Configurations.AddFromAssembly(typeof(UserConfig).Assembly);
            LoadEntities(typeof(User).Assembly, modelBuilder, "DNTCms.DomainClasses.Entities");
        }

        #endregion

        #region RejectChanges
        public void RejectChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        #endregion

        #region SaveChanges
        public int SaveAllChanges(bool invalidateCacheDependencies = true, bool updateAuditFields = true)
        {
            if (updateAuditFields)
                AuditFields();
            var result = SaveChanges();
            if (!invalidateCacheDependencies) return result;
            var changedEntityNames = GetChangedEntityNames();
            new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
            return result;
        }
        public Task<int> SaveAllChangesAsync(bool invalidateCacheDependencies = true, bool updateAuditFields = true)
        {
            if (updateAuditFields)
                AuditFields();
            var result = SaveChangesAsync();
            if (!invalidateCacheDependencies) return result;
            var changedEntityNames = GetChangedEntityNames();
            new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);

            return result;
        }

        #endregion

        #region PrivateMethods
        private void AuditFields()
        {
            var auditUserId = HttpContext.Current.User.Identity.GetUserId<long>();
            var auditUserIp = HttpContext.Current.Request.GetIp();
            var auditUserAgent = HttpContext.Current.Request.GetBrowser();
            var auditDate = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries<Entity<long>>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = auditDate;
                        entry.Entity.CreatedById = auditUserId;
                        entry.Entity.ModifiedOn = auditDate;
                        entry.Entity.Action = AuditAction.Create;
                        entry.Entity.ModifiedById = auditUserId;
                        entry.Entity.CreatorIp = auditUserIp;
                        entry.Entity.ModifierIp = auditUserIp;
                        entry.Entity.CreatorAgent = auditUserAgent;
                        entry.Entity.ModifierAgent = auditUserAgent;
                        entry.Entity.Version = 1;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedOn = auditDate;
                        entry.Entity.ModifiedById = auditUserId;
                        entry.Entity.ModifierIp = auditUserIp;
                        entry.Entity.ModifierAgent = auditUserAgent;
                        entry.Entity.Version = ++entry.Entity.Version;
                        entry.Entity.Action = entry.Entity.IsDeleted ? AuditAction.SoftDelete : AuditAction.Update;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        private string[] GetChangedEntityNames()
        {
            return ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added ||
                            x.State == EntityState.Modified ||
                            x.State == EntityState.Deleted)
                .Select(x => ObjectContext.GetObjectType(x.Entity.GetType()).FullName)
                .Distinct()
                .ToArray();
        }

        private static void LoadEntities(Assembly asm, DbModelBuilder modelBuilder, string nameSpace)
        {
            var entityTypes = asm.GetTypes()
                .Where(type => type.BaseType != null &&
                               type.Namespace == nameSpace &&
                               type.BaseType == null)
                .ToList();

            entityTypes.ForEach(modelBuilder.RegisterEntityType);
        }
        #endregion

        #region Dispose
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing); //فقط تعريف شده تا يك برك پوينت در اينجا قرار داده شود براي آزمايش فراخواني آن
        }
        #endregion

    }
}
