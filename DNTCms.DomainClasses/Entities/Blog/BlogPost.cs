using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Entities.Blog
{
    /// <summary>
    /// Represents a blog post
    /// </summary>
    public class BlogPost : BaseContent
    {
        #region Properties
        /// <summary>
        /// gets or sets Status of LinkBack Notifications
        /// </summary>
        public virtual LinkBackStatus LinkBackStatus { get; set; }
        /// <summary>
        /// indicate pingbacks of this post are sent
        /// </summary>
        public virtual bool Pinged { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// get or set  blog post's Reviews
        /// </summary>
        public virtual ICollection<BlogComment> Comments { get; set; }
        /// <summary>
        /// get or set collection of links that reference to this blog post
        /// </summary>
        public virtual ICollection<LinkBack> LinkBacks { get; set; }
        /// <summary>
        /// get or set Collection of Users that Contribute on this post
        /// </summary>
        public virtual ICollection<User> Contributors { get; set; }
        #endregion
    }
}
