using System;

using System.Data.Entity.ModelConfiguration;
using DNTCms.DomainClasses.Entities.Forums;

namespace DNTCms.DomainClasses.Configurations.Forums
{
    public class ForumConfig : EntityTypeConfiguration<Forum>
    {
        public ForumConfig()
        {
            ToTable("Forums");
            
            HasMany(f=>f.Moderators).WithRequired(fm=>fm.Forum).HasForeignKey(fm=>fm.ForumId).WillCascadeOnDelete(false);
            HasMany(f => f.Subscribers).WithMany(u => u.SubscribedForums).Map(m =>
            {
                m.MapRightKey("ForumId");
                m.MapLeftKey("SubscriberId");
                m.ToTable("ForumSubscriptions");
            });
            HasMany(f=>f.Topics).WithRequired(ft=>ft.Forum).HasForeignKey(ft=>ft.ForumId).WillCascadeOnDelete(true);
            HasMany(f=>f.Announcements).WithRequired(fa=>fa.Forum).HasForeignKey(fa=>fa.ForumId).WillCascadeOnDelete(true);
            HasMany(f=>f.Trackers).WithRequired(ft=>ft.Forum).HasForeignKey(ft=>ft.ForumId).WillCascadeOnDelete(true);
            HasRequired(f=>f.ModifiedBy).WithMany().HasForeignKey(f=>f.ModifiedById).WillCascadeOnDelete(false);
            HasRequired(f=>f.CreatedBy).WithMany().HasForeignKey(f=>f.CreatedById).WillCascadeOnDelete(false);

        }
    }
}
