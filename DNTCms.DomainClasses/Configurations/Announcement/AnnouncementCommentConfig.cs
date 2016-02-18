using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Announcements;

namespace DNTCms.DomainClasses.Configurations.Announcement
{
    public class AnnouncementCommentConfig : EntityTypeConfiguration<AnnouncementComment>
    {
        public AnnouncementCommentConfig()
        {
            HasOptional(ac => ac.ModifiedBy).WithMany().HasForeignKey(ac => ac.ModifiedById).WillCascadeOnDelete(false);
            HasOptional(ac=>ac.CreatedBy).WithMany(u=>u.AnnouncementComments).HasForeignKey(ac=>ac.CreatedById).WillCascadeOnDelete(false);
        }
    }
}
