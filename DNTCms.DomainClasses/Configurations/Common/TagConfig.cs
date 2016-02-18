using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Configurations.Common
{
    public class TagConfig : EntityTypeConfiguration<Tag>
    {
        public TagConfig()
        {
            HasRequired(t => t.ModifiedBy).WithMany().HasForeignKey(t => t.ModifiedById).WillCascadeOnDelete(false);
            HasRequired(t=>t.CreatedBy).WithMany().HasForeignKey(t=>t.CreatedById).WillCascadeOnDelete(false);
        }
    }
}
