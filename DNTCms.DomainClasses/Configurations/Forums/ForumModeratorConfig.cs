using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Forums;

namespace DNTCms.DomainClasses.Configurations.Forums
{
    public class ForumModeratorConfig : EntityTypeConfiguration<ForumModerator>
    {
        public ForumModeratorConfig()
        {
            HasKey(fm => new { fm.ForumId, fm.ModeratorId });
        }
    }
}
