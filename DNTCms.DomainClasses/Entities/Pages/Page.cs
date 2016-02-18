using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Entities.Pages
{
    /// <summary>
    /// represents one custom page
    /// </summary>
    public class Page : BaseEntity<long, long>
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
        /// gets or sets title for snippet
        /// </summary>
        public string SocialSnippetTitle { get; set; }
        /// <summary>
        /// gets or sets description for snippet
        /// </summary>
        public string SocialSnippetDescription { get; set; }
        /// <summary>
        /// gets or sets section's type that this page show on
        /// </summary>
        public virtual ShowPageSection Section { get; set; }
        /// <summary>
        /// indicate this page has not any body
        /// </summary>
        public virtual bool IsCategory { get; set; }
        /// <summary>
        /// gets or sets order for display forum
        /// </summary>
        public virtual int DisplayOrder { get; set; }
        #endregion

        #region NavigationProeprties
        /// <summary>
        /// gets or sets Parent of this page
        /// </summary>
        public virtual Page Parent { get; set; }
        /// <summary>
        /// gets or sets parent'id of this page
        /// </summary>
        public virtual long? ParentId { get; set; }
        /// <summary>
        /// get or set collection of page that they are children of this page
        /// </summary>
        public virtual ICollection<Page> Children { get; set; }
        #endregion
    }
}
