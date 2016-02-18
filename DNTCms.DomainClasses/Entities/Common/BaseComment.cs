using System;
using DNTCms.DomainClasses.Entities.Cms;
namespace DNTCms.DomainClasses.Entities.Common
{
    /// <summary>
    /// Represents a base class for every comment in system 
    /// </summary>
    public class BaseComment : BaseEntity<long, long?>
    {
        #region Properties
        /// <summary>
        /// gets or sets displayName of this comment's Creator
        /// </summary>
        public virtual string CreatorDisplayName { get; set; }
        /// <summary>
        /// gets or sets body of blog post's comment
        /// </summary>
        public virtual string Body { get; set; }
        /// <summary>
        /// gets or sets body of blog post's comment
        /// </summary>
        public virtual Rating Rating { get; set; }
        /// <summary>
        /// gets or sets siteUrl of Creator if he/she is Anonymouse
        /// </summary>
        public virtual string SiteUrl { get; set; }
        /// <summary>
        /// gets or sets Email of Creator if he/she is anonymouse
        /// </summary>
        public virtual string Email { get; set; }
        /// <summary>
        /// gets or sets status of comment
        /// </summary>
        public virtual CommentStatus Status { get; set; }
        #endregion
    }
}
