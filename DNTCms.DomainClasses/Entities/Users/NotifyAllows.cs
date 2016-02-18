using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNTCms.DomainClasses.Entities.Users
{
    [Flags]
    public enum NotifyAllows
    {
        PrivateMessage = 1,
        NewCommentToMyContents= 2,
        NewReplyToMyComments = 4,
        NewReplyToMyTopics=8
    }
}
