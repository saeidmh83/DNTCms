using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Announcements;
using DNTCms.DomainClasses.Entities.Blog;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.DomainClasses.Entities.Forums;
using DNTCms.DomainClasses.Entities.News;
using DNTCms.DomainClasses.Entities.Polling;
using DNTCms.DomainClasses.Entities.PrivateMessage;
using DNTCms.DomainClasses.Entities.Social;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DNTCms.DomainClasses.Entities.Users
{
    /// <summary>
    /// Represents  the User record
    /// </summary>
    public class User : IdentityUser<long, UserLogin, UserRole, UserClaim>
    {
        #region Ctor
        /// <summary>
        /// Create one instance of <see cref="User"/>
        /// </summary>
        public User()
        {
            RegisterDate = DateTime.Now;
        }
        #endregion

        #region Properties 
        /// <summary>
        /// gets or sets count of user's Announcements
        /// </summary>
        public virtual long AnnouncementsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's AnnouncementComments
        /// </summary>
        public virtual long AnnouncementCommentsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's blogdrafts
        /// </summary>
        public virtual long BlogDraftsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's blogposts
        /// </summary>
        public virtual long BlogPostsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's BlogPostComments
        /// </summary>
        public virtual long BlogPostCommentsCount { get; set; }
        /// <summary>
        /// Indicate That User's Drafts Convert to BlogPost Automaticly
        /// </summary>
        public virtual bool AutoConvertDraftsToLive { get; set; }
        /// <summary>
        /// gets or sets Total Size of user's Attachments
        /// </summary>
        public virtual long AttachmentsSize { get; set; }
        /// <summary>
        /// gets or sets Total Space That this user can Upload File/image.
        /// </summary>
        public virtual long Space { get; set; }
        /// <summary>
        /// gets or sets count of user's ForumTopics
        /// </summary>
        public virtual long ForumTopicsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's ForumPosts
        /// </summary>
        public virtual long ForumPostsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's NewsItems
        /// </summary>
        public virtual long NewsItemsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's NewsComments
        /// </summary>
        public virtual long NewsCommentsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's polls
        /// </summary>
        public virtual long PollsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's PollComments
        /// </summary>
        public virtual long PollCommentsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's Collection
        /// </summary>
        public virtual long CollectionsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's CollectionPosts
        /// </summary>
        public virtual long CollectionPostsCount { get; set; }
        /// <summary>
        /// gets or sets count of user's CollectionComments
        /// </summary>
        public virtual long CollectionCommentsCount { get; set; }
        /// <summary>
        /// Gets or Sets Count of User's Followers
        /// </summary>
        public virtual long FollowersCount { get; set; }
        /// <summary>
        /// gets or sets count of users that this user following
        /// </summary>
        public virtual long FollowedUsersCount { get; set; }
        /// <summary>
        /// gets or sets the location 
        /// </summary>
        public virtual string Location { get; set; }
        /// <summary>
        /// gets or sets the site's Url
        /// </summary>
        public virtual string Website { get; set; }
        /// <summary>
        /// gets or sets the last Date that password was changed
        /// </summary>
        public virtual DateTime? LastPasswordChangedDate { get; set; }
        /// <summary>
        /// Indicate That User is Ban
        /// </summary>
        public virtual bool IsBanned { get; set; }
        /// <summary>
        /// gets or sets date that this user was banned
        /// </summary>
        public virtual DateTime? BannedDate { get; set; }
        /// <summary>
        /// gets or sets the reason of ban
        /// </summary>
        public virtual string BannedReason { get; set; }
        /// <summary>
        /// gets or sets the description of user
        /// </summary>
        public virtual string AboutMe { get; set; }
        /// <summary>
        /// gets or sets That Date of User's Last Activity
        /// </summary>
        public virtual DateTime? LastActivityOn { get; set; }
        /// <summary>
        /// gets or sets Name Of User For Show in System
        /// </summary>
        public virtual string DisplayName { get; set; }
        /// <summary>
        /// Indicate That User is Soft Deleted
        /// </summary>
        public virtual bool IsDeleted { get; set; }
        /// <summary>
        /// Indicate That User is One SystemUser
        /// </summary>
        public virtual bool IsSystemAccount { get; set; }
        /// <summary>
        /// gets or sets one Comment from  Administrator to User
        /// </summary>
        public virtual string AdminComment { get; set; }
        /// <summary>
        /// gets or sets permissions that disabled for this user
        /// </summary>
        public virtual DisabledPermissions DisabledPermissions { get; set; }
        /// <summary>
        /// gets or sets User's status
        /// </summary>
        public virtual UserStatus Status { get; set; }
        /// <summary>
        /// gets or sets name of avatar's file
        /// </summary>
        public virtual string Avatar { get; set; }
        /// <summary>
        /// gets or sets the User's Signature
        /// </summary>
        public virtual string Signature { get; set; }
        /// <summary>
        /// gets or sets BirthDay
        /// </summary>
        public virtual DateTime? BirthDay { get; set; }
        /// <summary>
        /// gets or sets date that this user registerd
        /// </summary>
        public virtual DateTime RegisterDate { get; set; }
        /// <summary>
        /// gets or sets User's GooglePlusId
        /// </summary>
        public virtual string GooglePlusId { get; set; }
        /// <summary>
        /// gets or sets User's FaceBookId
        /// </summary>
        public virtual string FaceBookId { get; set; }
        /// <summary>
        /// gets or sets User's LinkedInId
        /// </summary>
        public virtual string LinkedInId { get; set; }
        /// <summary>
        /// gets or sets user's TwitterId
        /// </summary>
        public virtual string TwitterId { get; set; }
        /// <summary>
        /// gets or sets the user's Location's Latitude
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// gets or sets the user's Location's Longitude
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// gets or sets the User's last IP Address 
        /// </summary>
        public virtual string LastIp { get; set; }
        /// <summary>
        /// gets or sets the date  of User's Last Login
        /// </summary>
        public virtual DateTime? LastLoginDate { get; set; }
        /// <summary>
        /// indicate that user allow us for showing email
        /// </summary>
        public virtual bool DisplayEmailAddressAsIamge { get; set; }
        /// <summary>
        /// get or set 
        /// </summary>
        public virtual NotifyAllows NotifyAllows { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual EmailReceiveAllows EmailReceiveAllows { get; set; }
        /// <summary>
        /// gets or sets the User's Reputation
        /// </summary>
        public virtual double TotalReputation { get; set; }
        /// <summary>
        /// indicate the user's permissions Have changed
        /// </summary>
        public virtual bool IsChangedPermissions { get; set; }
        /// <summary>
        /// gets or sets User's ConnectionIds that use for integrated with Asp.net signalR (NotMapped)
        /// </summary>
        public virtual HashSet<string> ConnectionIds { get; set; }
        /// <summary>
        /// gets or sets date that use sent Last Post in forum
        /// </summary>
        public virtual DateTime? LastForumPostCreatedOn { get; set; }
        /// <summary>
        /// gets or sets 
        /// </summary>
        public virtual DateTime? LastMarkedForumsOn { get; set; }
        /// <summary>
        /// gets or sets the page url that use is there now , used for indicate where is user
        /// </summary>
        public virtual string CurrentPageUrl { get; set; }
        /// <summary>
        /// gets or sets count of bronze badges
        /// </summary>
        public virtual long BronzeBadgesCount { get; set; }
        /// <summary>
        /// gets or sets count of silver badges
        /// </summary>
        public virtual long SilverBadgesCount { get; set; }
        /// <summary>
        /// gets or sets count of gold badges
        /// </summary>
        public virtual long GoldBadgesCount { get; set; }
        /// <summary>
        /// gets or sets the Timestamp that used for concurrency problems
        /// </summary>
        public virtual byte[] RowVersion { get; set; }
        #endregion

        #region NavigationProperties
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<AnnouncementComment> AnnouncementComments { get; set; }
        public virtual ICollection<BlogDraft> BlogDrafts { get; set; }
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
        public virtual ICollection<BlogComment> BlogComments { get; set; }
        public virtual ICollection<BlogPost> ContributedBlogPosts { get; set; }
        public virtual ICollection<BaseAttachment> Attachments { get; set; }
        public virtual ICollection<ForumTopic> ForumTopics { get; set; }
        public virtual ICollection<Forum> SubscribedForums { get; set; }
        public virtual ICollection<ForumTopic> SubscribedForumTopics { get; set; }
        public virtual ICollection<ForumPost> ForumPosts { get; set; }
        public virtual ICollection<ForumTracker> TrackedForums { get; set; }
        public virtual ICollection<ForumTopicTracker> TrackedForumTopics { get; set; }
        public virtual ICollection<ForumModerator> ModeratedForums { get; set; }
        public virtual ICollection<NewsComment> NewsComments { get; set; }
        public virtual ICollection<NewsItem> NewsItems { get; set; }
        public virtual ICollection<Poll> Polls { get; set; }
        public virtual ICollection<Poll> VotedPolls { get; set; }
        public virtual ICollection<PollComment> PollComments { get; set; }
        public virtual ICollection<Conversation> SentConversations { get; set; }
        public virtual ICollection<Conversation> ReceivedConversations { get; set; }
        public virtual ICollection<ConversationReply> SentMessages { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<Collection> AllowedCollections  { get; set; }
        public virtual ICollection<CollectionPost> CollectionPosts { get; set; }
        public virtual ICollection<CollectionComment> CollectionComments { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<ActivityLog> Activities { get; set; }
        public virtual ICollection<User> Blockers { get; set; }
        public virtual ICollection<User> BlockedUsers { get; set; }
        public virtual ICollection<User> Followers { get; set; }
        public virtual ICollection<User> FollowedUsers { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Tag> Tags  { get; set; }
        public virtual ICollection<ReputationLog> ReputationLogs  { get; set; }
        #endregion
    }
}
