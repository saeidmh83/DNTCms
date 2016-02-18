using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Blog;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Entities.News
{
    public class NewsComment : BaseComment
    {
        #region NavigationProperties

        /// <summary>
        /// gets or sets body of blog NewsItem's comment
        /// </summary>
        public virtual long? ReplyId { get; set; }
        /// <summary>
        /// gets or sets body of blog NewsItem's comment
        /// </summary>
        public virtual NewsComment Reply { get; set; }
        /// <summary>
        /// gets or sets body of blog NewsItem's comment
        /// </summary>
        public virtual ICollection<NewsComment> Children { get; set; }
        /// <summary>
        /// gets or sets NewsItem that this comment sent to it
        /// </summary>
        public virtual NewsItem NewsItem { get; set; }
        /// <summary>
        /// gets or sets NewsItem'Id that this comment sent to it
        /// </summary>
        public virtual long NewsItemId { get; set; }

        #endregion
    }
}
