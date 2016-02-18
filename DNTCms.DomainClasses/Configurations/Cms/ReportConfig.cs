using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Cms;

namespace DNTCms.DomainClasses.Configurations.Cms
{
    public class ReportConfig : EntityTypeConfiguration<Report>
    {
        public ReportConfig()
        {
            HasRequired(r => r.Reporter).WithMany().HasForeignKey(r => r.ReporterId).WillCascadeOnDelete(false);
            HasRequired(r => r.ReasonType).WithMany(rr => rr.Reports).HasForeignKey(r => r.ReasonTypeId).WillCascadeOnDelete(true);
        }
    }
}
