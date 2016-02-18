using DNTCms.DomainClasses.Entities.Users;
using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Entities.Forums
{
    /// <summary>
    /// Represents the Forum
    /// </summary>
    public class Forum : BaseEntity<long,long>
    {
        #region Properties
        /// <summary>
        /// gets or sets Forum's title
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// gets or sets Description of forum
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// gets or sets value indicating Custom Slug
        /// </summary>
        public virtual string SlugUrl { get; set; }
        /// <summary>
        /// gets or sets order for display forum
        /// </summary>
        public virtual long DisplayOrder { get; set; }
        /// <summary>
        /// Indicating This Forum is Active or Not
        /// </summary>
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// Indicating This Forum is Close or Not
        /// </summary>
        public virtual bool IsClose { get; set; }
        /// <summary>
        /// Indicating This Forum is Private or Not
        /// </summary>
        public virtual bool IsPrivate { get; set; }
        /// <summary>
        /// sets or gets password for login to Private forums
        /// </summary>
        public virtual string PasswordHash { get; set; }
        /// <summary>
        /// sets or gets depth of forum in tree structure of forums
        /// </summary>
        public virtual int Depth { get; set; }
        /// <summary>
        /// sets or gets Count of  posts That they are Approved
        /// </summary>
        public virtual long ApprovedPostsCount { get; set; }
        /// <summary>
        /// sets or gets Count of  topics That they are Approved
        /// </summary>
        public virtual long ApprovedTopicsCount { get; set; }
        /// <summary>
        /// Gets or sets the id of last topic
        /// </summary>
        public virtual long LastTopicId { get; set; }
        /// <summary>
        /// gets or sets date of creation of last topic
        /// </summary>
        public virtual DateTime? LastTopicCreatedOn { get; set; }
        /// <summary>
        /// gets or sets title of last topic
        /// </summary>
        public virtual string LastTopicTitle { get; set; }
        /// <summary>
        /// gets or sets creator of last topic
        /// </summary>
        public virtual string LastTopicCreator { get; set; }
        /// <summary>
        /// gets or sets id of creator that create last topic
        /// </summary>
        public virtual long LastTopicCreatorId { get; set; }
        /// <summary>
        /// Indicate in this Forum Moderate Topics Before Display 
        /// </summary>
        public virtual bool ModerateTopics { get; set; }
        /// <summary>
        /// Indicate in this Forum Moderate Posts Before Dipslay
        /// </summary>
        public virtual bool ModeratePosts { get; set; }
        /// <summary>
        /// gets or sets Count of posts that they are UnApproved
        /// </summary>
        public virtual long UnApprovedPostsCount { get; set; }
        /// <summary>
        /// gets or sets Count of topics that they are UnApproved
        /// </summary>
        public virtual long UnApprovedTopicsCount { get; set; }
        /// <summary>
        /// gets or sets icon name with size 200*200 px for snippet 
        /// </summary>
        public virtual string SocialSnippetIconName { get; set; }
        /// <summary>
        /// gets or sets title for snippet
        /// </summary>
        public virtual string SocialSnippetTitle { get; set; }
        /// <summary>
        /// gets or sets description for snippet
        /// </summary>
        public virtual string SocialSnippetDescription { get; set; }
        /// <summary>
        /// gets or sets path for tree structure antipattern (1/3/4/23)
        /// </summary>
        public virtual string Path { get; set; }
        /// <summary>
        /// Indicate this forum inherit moderators from parent forum
        /// </summary>
        public virtual bool IsModeratorsInherited { get; set; }
        /// <summary>
        /// gets or set datetime that Last Post is Created In this forum. used for ForumTracking 
        /// </summary>
        public virtual DateTime? LastPostCreatedOn { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// sets or gets identifier forum's parent
        /// </summary>
        public virtual long? ParentId { get; set; }
        /// <summary>
        /// sets or gets forum's parent
        /// </summary>
        public virtual Forum Parent { get; set; }
        /// <summary>
        /// sets or gets sub forums of forum
        /// </summary>
        public virtual ICollection<Forum> Children { get; set; }
        /// <summary>
        /// set or get topics of forum
        /// </summary>
        public virtual ICollection<ForumTopic> Topics { get; set; }
        /// <summary>
        /// get or set moderators of this forum
        /// </summary>
        public virtual ICollection<ForumModerator> Moderators { get; set; }
        /// <summary>
        /// get or set Subscriptions List 
        /// </summary>
        public virtual ICollection<User> Subscribers { get; set; }
        /// <summary>
        /// get or set Announcements Collection of this Forum
        /// </summary>
        public virtual ICollection<ForumAnnouncement> Announcements { get; set; }
        /// <summary>
        /// get or set Trackers List Of this Forum
        /// </summary>
        public virtual ICollection<ForumTracker> Trackers { get; set; }
        /// <summary>
        /// get or set Posts List that Posted in this forum for increase Performance for get Posts Count 
        /// </summary>
        public virtual ICollection<ForumPost> Posts { get; set; }
        /// <summary>
        /// get or set 
        /// </summary>
        public virtual ICollection<ForumTopicTracker> TopicTrackers { get; set; }
        #endregion
    }
}
