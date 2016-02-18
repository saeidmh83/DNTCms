using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Pages;

namespace DNTCms.DomainClasses.Configurations.Pages
{
    public class PageConfig : EntityTypeConfiguration<Page>
    {
        public PageConfig()
        {
            HasRequired(p => p.ModifiedBy).WithMany().HasForeignKey(p => p.ModifiedById).WillCascadeOnDelete(false);
            HasRequired(p => p.CreatedBy).WithMany().HasForeignKey(p => p.CreatedById).WillCascadeOnDelete(false);
        }
    }
}
