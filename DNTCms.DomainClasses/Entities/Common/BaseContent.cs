﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Entities.Common
{
    /// <summary>
    /// Represents a base class for every content in system
    /// </summary>
    public abstract class BaseContent : BaseEntity<long, long>
    {
        #region Properties
        /// <summary>
        /// gets or sets the blog pot body
        /// </summary>
        public virtual string Body { get; set; }
        /// <summary>
        /// gets or sets the content title
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// gets or sets value  indicating Custom Slug
        /// </summary>
        public virtual string SlugUrl { get; set; }
        /// <summary>
        /// gets or sets meta title for seo
        /// </summary>
        public virtual string MetaTitle { get; set; }
        /// <summary>
        /// gets or sets meta keywords for seo
        /// </summary>
        public virtual string MetaKeywords { get; set; }
        /// <summary>
        /// gets or sets meta description of the content
        /// </summary>
        public virtual string MetaDescription { get; set; }
        /// <summary>
        /// gets or sets 
        /// </summary>
        public virtual string FocusKeyword { get; set; }
        /// <summary>
        /// gets or sets value indicating whether the content use CanonicalUrl
        /// </summary>
        public virtual bool UseCanonicalUrl { get; set; }
        /// <summary>
        /// gets or sets CanonicalUrl That the Post Point to it
        /// </summary>
        public virtual string CanonicalUrl { get; set; }
        /// <summary>
        /// gets or sets value indicating whether the content user no Follow for Seo
        /// </summary>
        public virtual bool UseNoFollow { get; set; }
        /// <summary>
        /// gets or sets value indicating whether the content user no Index for Seo
        /// </summary>
        public virtual bool UseNoIndex { get; set; }
        /// <summary>
        /// gets or sets value indicating whether the content in sitemap
        /// </summary>
        public virtual bool IsInSitemap { get; set; }
        /// <summary>
        /// gets or sets a value indicating whether the content comments are allowed 
        /// </summary>
        public virtual bool AllowComments { get; set; }
        /// <summary>
        /// gets or sets a value indicating whether the content comments are allowed for anonymouses 
        /// </summary>
        public virtual bool AllowCommentForAnonymous { get; set; }
        /// <summary>
        /// gets or sets  viewed count by rss
        /// </summary>
        public virtual long ViewCountByRss { get; set; }
        /// <summary>
        /// gets or sets viewed count 
        /// </summary>
        public virtual long ViewCount { get; set; }
        /// <summary>
        /// Gets or sets the total number of  comments
        /// <remarks>The same as if we run Item.Comments.where(a=>a.Status==Status.Approved).Count()
        /// We use this property for performance optimization (no SQL command executed)
        /// </remarks>
        /// </summary>
        public virtual int ApprovedCommentsCount { get; set; }
        /// <summary>
        /// Gets or sets the total number of  comments
        /// <remarks>The same as if we run Item.Comments.where(a=>a.Status==Status.UnApproved).Count()
        /// We use this property for performance optimization (no SQL command executed)</remarks></summary>
        public virtual int UnApprovedCommentsCount { get; set; }
        /// <summary>
        /// gets or sets date that last comment sent to this content
        /// </summary>
        public virtual DateTime? LastCommentCreatedOn { get; set; }
        /// <summary>
        /// indicate comments should be approved before display
        /// </summary>
        public virtual bool ModerateComments { get; set; }
        /// <summary>
        /// gets or sets rating complex instance
        /// </summary>
        public virtual Rating Rating { get; set; }
        /// <summary>
        /// gets or sets value indicating whether the content show with rssFeed
        /// </summary>
        public virtual bool ShowWithRss { get; set; }
        /// <summary>
        /// gets or sets value indicating maximum days count that users can send comment
        /// </summary>
        public virtual int DaysCountForSupportComment { get; set; }
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
        /// gets or sets name of tags seperated by comma that assosiated with this content fo increase performance
        /// </summary>
        public virtual string TagNames { get; set; }
        /// <summary>
        /// indicate this entity is approved by admin 
        /// </summary>
        public virtual bool IsApproved { get; set; }

        #endregion

        #region NavigationProperties
        /// <summary>
        /// get or set  the tags integrated with content
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }
        #endregion
    }
}
