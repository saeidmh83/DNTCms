using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Cms;

namespace DNTCms.DomainClasses.Configurations.Cms
{
    public class ReportReasonConfig : EntityTypeConfiguration<ReportReason>
    {
        public ReportReasonConfig()
        {
            Ignore(rr => rr.ReportedOn);
            Ignore(rr => rr.ReportsCount);
            Ignore(rr => rr.ModifyLocked);
            HasRequired(rr=>rr.CreatedBy).WithMany().HasForeignKey(rr=>rr.CreatedById).WillCascadeOnDelete(false);
            HasOptional(rr=>rr.ModifiedBy).WithMany().HasForeignKey(rr=>rr.ModifiedById).WillCascadeOnDelete(false);
        }
    }
}
