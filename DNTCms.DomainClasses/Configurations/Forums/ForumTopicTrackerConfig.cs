using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Forums;

namespace DNTCms.DomainClasses.Configurations.Forums
{
    public class ForumTopicTrackerConfig : EntityTypeConfiguration<ForumTopicTracker>
    {
        public ForumTopicTrackerConfig()
        {
            HasKey(ftt => new {ftt.TopicId, ftt.TrackerId});
        }
    }
}
