using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Entities.Forums
{
    /// <summary>
    /// Represents The Post of Forum
    /// </summary>
    public class ForumPost : BaseEntity<long, long>
    {
        #region Properties
        /// <summary>
        /// gets or sets body of this post
        /// </summary>
        public virtual string Body { get; set; }
        /// <summary>
        /// gets or sets reason of Last Update for increase performance
        /// </summary>
        public virtual string LastModifyReason { get; set; }
        /// <summary>
        /// gets or sets rating values 
        /// <remarks>is a complex type</remarks>
        /// </summary>
        public virtual Rating Rating { get; set; }
        /// <summary>
        /// gets or sets status of this post
        /// </summary>
        public virtual ForumPostStatus Status { get; set; }
        
        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets ParentPost of this post
        /// </summary>
        public virtual ForumPost Reply { get; set; }
        /// <summary>
        /// gets or sets ParentPost's Id of this post
        /// </summary>
        public virtual long? ReplyId { get; set; }
        /// <summary>
        /// gets or sets 
        /// </summary>
        public virtual ICollection<ForumPost> Children { get; set; }
        /// <summary>
        /// gets or sets Topic That Associated with this Post
        /// </summary>
        public virtual ForumTopic Topic { get; set; }
        /// <summary>
        /// gets or sets Id of Topic That Associated with this Post
        /// </summary>
        public virtual long TopicId { get; set; }
        /// <summary>
        /// gets or sets Forum that this post created in it . used for retrive posts count 
        /// </summary>
        public virtual Forum Forum { get; set; }
        /// <summary>
        /// gets or sets id of Forum that this post created in it . used for retrive posts count 
        /// </summary>
        public virtual long ForumId { get; set; }
        #endregion
    }
}
