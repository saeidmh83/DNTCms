using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNTCms.DomainClasses.Entities.Forums
{
    [Flags]
    public enum  ForumModeratorPermissions
    {
        CanEditPosts=1,
        CanDeletePosts=2,
        CanManageTopics=4,
        CanOpenCloseTopics=8,
    }
}
