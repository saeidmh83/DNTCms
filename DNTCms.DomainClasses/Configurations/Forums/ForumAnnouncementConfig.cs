using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Forums;

namespace DNTCms.DomainClasses.Configurations.Forums
{
    public class ForumAnnouncementConfig : EntityTypeConfiguration<ForumAnnouncement>
    {
        public ForumAnnouncementConfig()
        {
            HasRequired(fa => fa.ModifiedBy).WithMany().HasForeignKey(fa => fa.ModifiedById);
            HasRequired(fa=>fa.CreatedBy).WithMany().HasForeignKey(fa=>fa.CreatedById).WillCascadeOnDelete(false);
        }
    }
}
