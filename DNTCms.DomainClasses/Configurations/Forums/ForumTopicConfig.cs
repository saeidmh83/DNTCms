using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Forums;

namespace DNTCms.DomainClasses.Configurations.Forums
{
    public class ForumTopicConfig : EntityTypeConfiguration<ForumTopic>
    {
        public ForumTopicConfig()
        {
            
            HasMany(ft=>ft.Posts).WithRequired(fp=>fp.Topic).HasForeignKey(fp=>fp.TopicId).WillCascadeOnDelete(false);
            HasMany(ft => ft.Subscribers).WithMany(u => u.SubscribedForumTopics).Map(m =>
            {
                m.ToTable("ForumTopicSubscription");
                m.MapLeftKey("SubscriberId");
                m.MapRightKey("ForumTopicId");
            });
            HasRequired(ft=>ft.CreatedBy).WithMany(u=>u.ForumTopics).HasForeignKey(ft=>ft.CreatedById).WillCascadeOnDelete(false);

            HasMany(ft=>ft.Trackers).WithRequired(ftf=>ftf.Topic).HasForeignKey(ftt=>ftt.TopicId).WillCascadeOnDelete(false);
            HasRequired(ft=>ft.ModifiedBy).WithMany().HasForeignKey(ft=>ft.ModifiedById).WillCascadeOnDelete(false);
        }
    }
}
