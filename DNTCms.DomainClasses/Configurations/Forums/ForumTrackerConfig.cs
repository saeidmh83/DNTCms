using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Forums;

namespace DNTCms.DomainClasses.Configurations.Forums
{
    public class ForumTrackerConfig : EntityTypeConfiguration<ForumTracker>
    {
        public ForumTrackerConfig()
        {
            HasKey(ft => new { ft.TrackerId, ft.ForumId });
        }
    }
}
