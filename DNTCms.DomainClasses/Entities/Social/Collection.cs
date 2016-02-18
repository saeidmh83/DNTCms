using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Social
{
    /// <summary>
    /// Represents the Collection for group  posts by topic 
    /// </summary>
    public class Collection : BaseEntity<Guid, long>
    {
        #region Properties
        /// <summary>
        /// gets or sets name of group
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// gets or sets Alternative SlugUrl
        /// </summary>
        public virtual string SlugUrl { get; set; }
        /// <summary>
        /// gets or sets some description of group
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// gets or sets description that indicate how to pay 
        /// </summary>
        public virtual string HowToPay { get; set; }
        /// <summary>
        /// gets or sets Visibility Type 
        /// </summary>
        public virtual CollectionVisibility Visibility { get; set; }
        /// <summary>
        /// gets or sets color of Collection's Cover
        /// </summary>
        public virtual string Color { get; set; }
        /// <summary>
        /// gets or sets Name of Image that used as Cover
        /// </summary>
        public virtual string Photo { get; set; }
        /// <summary>
        /// gets or sets name of tags seperated by comma that assosiated with this content fo increase performance
        /// </summary>
        public virtual string TagNames { get; set; }
        /// <summary>
        /// indicate this collection is active or not
        /// </summary>
        public virtual bool IsActive { get; set; }
        #endregion

        #region  NavigationProperties
        /// <summary>
        /// get or set collection of attachments that attached in this group
        /// </summary>
        public virtual ICollection<CollectionAttachment> Attachments { get; set; }
        /// <summary>
        /// get or set tags of collection
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }
        /// <summary>
        /// get or set List Of Posts that Associated with this Collection
        /// </summary>
        public virtual ICollection<CollectionPost> Posts { get; set; }
        /// <summary>
        /// get or set Users that they are Member of this collection if visibility is Custom
        /// </summary>
        public virtual ICollection<User> Memebers { get; set; }
        #endregion
    }
}
