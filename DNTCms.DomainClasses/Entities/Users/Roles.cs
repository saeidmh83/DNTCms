using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNTCms.DomainClasses.Entities.Users
{
    [Flags]
    public enum Roles
    {
        User=1,
        Author=2,
        Editor=4,
        Moderator=8,
        Adminisrator=16,
        BlogModerator=32,
        NewsModerator=64,
        PollModerator=128,
        AnnouncementModerator=256,
        ForumModerator=512,
        PagesModerator=1024,
        CollectionsModerator=2048
    }
}
