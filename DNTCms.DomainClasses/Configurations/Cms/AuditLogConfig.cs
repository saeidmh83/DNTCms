
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using DNTCms.DomainClasses.Entities.Cms;

namespace DNTCms.DomainClasses.Configurations.Cms
{
    /// <summary>
    /// کلاس میپنگ مربوط به لاگ آماری
    /// </summary>
    public class AuditLogConfig : EntityTypeConfiguration<AuditLog>
    {
        /// <summary>
        /// سازنده پیش فرض
        /// </summary>
        public AuditLogConfig()
        {
            Ignore(a => a.XmlNewValueWrapper);
            Ignore(a => a.XmlOldValueWrapper);
            HasRequired(a => a.Operant).WithMany().HasForeignKey(a => a.OperantId).WillCascadeOnDelete(false);
        }
    }
}
