using System.Data.Entity.ModelConfiguration;

namespace DNTCms.DomainClasses.Configurations.Announcement
{
    public class AnnouncementConfig : EntityTypeConfiguration<Entities.Announcements.Announcement>
    {
        public AnnouncementConfig()
        {
            HasRequired(a => a.CreatedBy)
                .WithMany(u => u.Announcements)
                .HasForeignKey(a => a.CreatedById)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.ModifiedBy).WithMany().HasForeignKey(a => a.CreatedById).WillCascadeOnDelete(false);
        }
    }
}
