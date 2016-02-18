using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Blog;
using DNTCms.DomainClasses.Entities.Forums;
using DNTCms.DomainClasses.Entities.News;
using DNTCms.DomainClasses.Entities.Polling;
using DNTCms.DomainClasses.Entities.Social;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Entities.Common
{
    /// <summary>
    /// Represents the lable record
    /// </summary>
    public class Tag : BaseEntity<long, long>
    {
        #region Properties
        /// <summary>
        /// sets or gets Tag's name
        /// </summary>
        public virtual string Name { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// set or get Tag's posts
        /// </summary>
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
        /// <summary>
        /// get or set Tag's News
        /// </summary>
        public virtual ICollection<NewsItem> NewsItems { get; set; }
        public virtual ICollection<Poll> Polls  { get; set; }
        public virtual ICollection<Collection> Collections  { get; set; }
        public virtual ICollection<ForumTopic> ForumTopics { get; set; }
        public virtual ICollection<User>  Users{ get; set; }
        #endregion
    }
}
