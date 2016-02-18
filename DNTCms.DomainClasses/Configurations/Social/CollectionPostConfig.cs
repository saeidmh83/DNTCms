using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Social;

namespace DNTCms.DomainClasses.Configurations.Social
{
    public class CollectionPostConfig : EntityTypeConfiguration<CollectionPost>
    {
        public CollectionPostConfig()
        {
            HasRequired(cp => cp.ModifiedBy).WithMany().HasForeignKey(cp => cp.ModifiedById).WillCascadeOnDelete(false);
            HasRequired(cp => cp.CreatedBy).WithMany().HasForeignKey(cp => cp.CreatedById).WillCascadeOnDelete(false);
        }
    }
}
