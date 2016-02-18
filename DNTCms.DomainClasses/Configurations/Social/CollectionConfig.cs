using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Social;

namespace DNTCms.DomainClasses.Configurations.Social
{
    public class CollectionConfig : EntityTypeConfiguration<Collection>
    {
        public CollectionConfig()
        {
            //HasMany(c => c.Tags).WithMany(t => t.Collections).Map(a =>
            //{
            //    a.MapLeftKey("TagId");
            //    a.MapRightKey("CollectionId");
            //    ToTable("CollectionTag");
            //});
            HasRequired(c=>c.ModifiedBy).WithMany().HasForeignKey(c=>c.ModifiedById).WillCascadeOnDelete(false);
            HasRequired(c=>c.CreatedBy).WithMany(u=>u.Collections).HasForeignKey(c=>c.CreatedById).WillCascadeOnDelete(true);
        }
    }
}
