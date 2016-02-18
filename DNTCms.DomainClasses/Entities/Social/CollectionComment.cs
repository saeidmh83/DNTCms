using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Entities.Social
{
    public class CollectionComment : BaseEntity<Guid, long>
    {
        #region Properties
        /// <summary>
        /// gets or sets body of blog post's comment
        /// </summary>
        public virtual string Body { get; set; }
        /// <summary>
        /// gets or sets body of blog post's comment
        /// </summary>
        public virtual Rating Rating { get; set; }
        /// <summary>
        /// indicate this comment is Approved 
        /// </summary>
        public virtual bool IsApproved { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets post that this comment added it
        /// </summary>
        public virtual CollectionPost Post { get; set; }
        /// <summary>
        /// gets or sets id of post that this comment added it
        /// </summary>
        public virtual Guid PostId { get; set; }
        /// <summary>
        /// gets or sets CollectionComment's identifier for Replying and impelemention self referencing
        /// </summary>
        public virtual Guid? ReplyId { get; set; }
        /// <summary>
        /// gets or sets Collection's comment for Replying and impelemention self referencing
        /// </summary>
        public virtual CollectionComment Reply { get; set; }
        /// <summary>
        /// get or set collection of Collection's comment for Replying and impelemention self referencing
        /// </summary>
        public virtual ICollection<CollectionComment> Children { get; set; }
        #endregion
    }
}
