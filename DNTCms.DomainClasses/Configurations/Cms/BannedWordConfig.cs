using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Cms;

namespace DNTCms.DomainClasses.Configurations.Cms
{
    public class BannedWordConfig : EntityTypeConfiguration<BannedWord>
    {
        public BannedWordConfig()
        {
            HasRequired(w=>w.CreatedBy).WithMany().HasForeignKey(w=>w.CreatedById).WillCascadeOnDelete(false);

            HasRequired(w => w.ModifiedBy).WithMany().HasForeignKey(w => w.ModifiedById).WillCascadeOnDelete(false);
        }
    }
}
