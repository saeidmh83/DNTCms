using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNTCms.DomainClasses.Entities.Users
{
    [Flags]
    public enum DisabledPermissions
    {
        SuspensionForumTopics = 1,
        SuspensionBlogDrafts = 2,
        SuspensionNews = 4,
        SuspensionAttachments = 8,
        SuspensionAnnouncements = 16,
        SuspensionConversations = 32,
        SuspensionComments = 64,
        SuspensionPolls = 128,
        SuspensionForumPosts = 256,
        ModerateComments = 512,
        ModerateForumTopics = 1024,
        ModerateForumPosts = 2048,
        ModerateBlogDrafts = 4096,
        ModerateNews = 8192,
        ModerateAttachments = 16384,
        ModeratePolls = 32768,
        ModerateAnnouncements = 65536
    }
}
