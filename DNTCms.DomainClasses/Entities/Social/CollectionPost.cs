using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Social
{
    public class CollectionPost : BaseEntity<Guid, long>
    {
        #region Properties
        /// <summary>
        /// indicate this post should be pin
        /// </summary>
        public virtual bool IsPin { get; set; }
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
        public virtual string SlugAltUrl { get; set; }
        /// <summary>
        /// gets or sets a value indicating whether the content comments are allowed 
        /// </summary>
        public virtual bool AllowComments { get; set; }
        /// <summary>
        /// indicate comments should be approved before display
        /// </summary>
        public virtual bool ModerateComments { get; set; }
        /// <summary>
        /// gets or sets viewed count 
        /// </summary>
        public virtual long ViewCount { get; set; }
        /// <summary>
        /// Gets or sets the total number of  approved comments
        /// <remarks>The same as if we run Item.Comments.Count()
        /// We use this property for performance optimization (no SQL command executed)
        /// </remarks>
        /// </summary>
        public virtual int ApprovedCommentsCount { get; set; }
        /// <summary>
        /// Gets or sets the total number of  unapproved comments
        /// <remarks>The same as if we run Item.Comments.Count()
        /// We use this property for performance optimization (no SQL command executed)
        /// </remarks>
        /// </summary>
        public virtual int UnApprovedCommentsCount { get; set; }
        /// <summary>
        /// gets or sets date that last comment sent to this content
        /// </summary>
        public virtual DateTime? LastCommentCreatedOn { get; set; }
        /// <summary>
        /// gets or sets rating complex instance
        /// </summary>
        public virtual Rating Rating { get; set; }
        /// <summary>
        /// indicate users can share this post
        /// </summary>
        public virtual bool IsEnableForShare { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// get or set comments of this post
        /// </summary>
        public virtual ICollection<CollectionComment> Comments { get; set; }
       
        /// <summary>
        /// gets or sets collection that associated with this post
        /// </summary>
        public virtual Collection Collection { get; set; }
        /// <summary>
        /// gets or sets id of collection that associated with this post
        /// </summary>
        public virtual Guid CollectionId { get; set; }
        #endregion
    }
}
