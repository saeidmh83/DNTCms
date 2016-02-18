using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Entities.Blog
{
    /// <summary>
    /// Represents a blog post's comment
    /// </summary>
    public class BlogComment : BaseComment
    {
        #region NavigationProperties
        /// <summary>
        /// gets or sets BlogComment's identifier for Replying and impelemention self referencing
        /// </summary>
        public virtual long? ReplyId { get; set; }
        /// <summary>
        /// gets or sets blog's comment for Replying and impelemention self referencing
        /// </summary>
        public virtual BlogComment Reply { get; set; }
        /// <summary>
        /// get or set collection of blog's comment for Replying and impelemention self referencing
        /// </summary>
        public virtual ICollection<BlogComment> Children { get; set; }
        /// <summary>
        /// gets or sets post that this comment sent to it
        /// </summary>
        public virtual BlogPost Post { get; set; }
        /// <summary>
        /// gets or sets post'Id that this comment sent to it
        /// </summary>
        public virtual long PostId { get; set; }

        #endregion
    }
}
