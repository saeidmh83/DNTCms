using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;


namespace DNTCms.DomainClasses.Configurations.Users
{
    using Entities.Users;
    
    public class RoleConfig : EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {
            ToTable("Roles");

            Property(r => r.Name)
                 .IsRequired()
                 .HasMaxLength(20)
                 .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_UniqueRoleName") { IsUnique = true }));
        

            HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId).WillCascadeOnDelete(true);
        }
    }
}
