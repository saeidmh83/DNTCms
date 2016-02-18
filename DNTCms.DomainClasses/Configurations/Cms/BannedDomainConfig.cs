using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Cms;

namespace DNTCms.DomainClasses.Configurations.Cms
{
   public class BannedDomainConfig:EntityTypeConfiguration<BannedDomain>
   {
       public BannedDomainConfig()
       {
            HasRequired(d => d.ModifiedBy).WithMany().HasForeignKey(d => d.ModifiedById).WillCascadeOnDelete(false);
            HasRequired(d => d.CreatedBy).WithMany().HasForeignKey(d => d.CreatedById).WillCascadeOnDelete(false);
       }
    }
}
