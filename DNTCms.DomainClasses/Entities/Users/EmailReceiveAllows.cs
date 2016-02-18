using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNTCms.DomainClasses.Entities.Users
{
    [Flags]
    public enum EmailReceiveAllows
    {
        ReceiveWeeklyNewPosts = 1,
        ReceiveWeeklyNewNews = 2,
        ReceiveWeeklyNewPolls = 4,
        ReceiveWeeklyNewAnnouncements=8
    }
}
