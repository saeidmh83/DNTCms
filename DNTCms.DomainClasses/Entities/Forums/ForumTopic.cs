using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Entities.Forums
{
    /// <summary>
    /// Represents the Topic in the Forums
    /// </summary>
    public class ForumTopic : BaseEntity<long, long>
    {
        #region Properties
        /// <summary>
        /// gets or sets Title Of this topic
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// gets or sets name of tags that assosiated with 
        /// this content fo increase performance
        /// </summary>
        public virtual string TagNames { get; set; }
        /// <summary>
        /// indicate this topic is Sticky and will be shown top of forum
        /// </summary>
        public virtual bool IsSticky { get; set; }
        /// <summary>
        /// indicate this topic is closed
        /// </summary>
        public virtual bool IsClosed { get; set; }
        /// <summary>
        /// gets or sets identifier of  last post in this topic
        /// </summary>
        public virtual long LastPostId { get; set; }
        /// <summary>
        /// gets or sets identifier of Last user that post in this topic
        /// </summary>
        public virtual long LastPosterId { get; set; }
        /// <summary>
        /// gets or sets title of last Post in this topic
        /// </summary>
        public virtual string LastPostTitle { get; set; }
        /// <summary>
        /// gets or sets displayName of user that create lastpost in this topic
        /// </summary>
        public virtual string LastPoster { get; set; }
        /// <summary>
        /// gets or sets datetime that last post posted in this topic
        /// </summary>
        public virtual DateTime? LastPostCreatedOn { get; set; }
        /// <summary>
        /// indicate this topic is approved
        /// </summary>
        public virtual bool IsApproved { get; set; }
        /// <summary>
        /// indicate this topic is type of Announcements and shown in Annoucements sections
        /// </summary>
        public virtual bool IsAnnouncement { get; set; }
        /// <summary>
        /// gets or sets viewed count 
        /// </summary>
        public virtual long ViewCount { get; set; }
        /// <summary>
        /// gets or sets count of posts that they are approved
        /// </summary>
        public virtual int ApprovedPostsCount { get; set; }
        /// <summary>
        /// gets or sets count of posts that they are Unapproved
        /// </summary>
        public virtual int UnApprovedPostsCount { get; set; }
        /// <summary>
        /// gets or sets specifications of this topic's rating
        /// </summary>
        public virtual Rating Rating { get; set; }
        /// <summary>
        /// gets or sets datetime that this topic closed
        /// </summary>
        public virtual DateTime? ClosedOn { get; set; }
        /// <summary>
        /// gets or sets reason that this topic colsed
        /// </summary>
        public virtual string ClosedReason { get; set; }
        /// <summary>
        /// gets or sets count of reports
        /// </summary>
        public virtual int ReportsCount { get; set; }
        /// <summary>
        /// indicate the posts of this topic should be Moderate Before Dipslay
        /// </summary>
        public virtual bool ModeratePosts { get; set; }
        /// <summary>
        /// gets or sets 
        /// </summary>
        public virtual ForumTopicLevel Level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ForumTopicType Type { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets Collection of tags that associated with this topic
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }
        /// <summary>
        /// gets or sets forum
        /// </summary>
        public virtual Forum Forum { get; set; }
        /// <summary>
        /// gets or sets identifier of Forum
        /// </summary>
        public virtual long ForumId { get; set; }
        /// <summary>
        /// gets or sets Posts Of this topic
        /// </summary>
        public virtual ICollection<ForumPost> Posts { get; set; }
        /// <summary>
        /// get or set Subscriptions List 
        /// </summary>
        public virtual ICollection<User> Subscribers { get; set; }
        /// <summary>
        /// get or set Trackkers list of this Topic
        /// </summary>
        public virtual ICollection<ForumTopicTracker> Trackers { get; set; }

        #endregion
    }
}
