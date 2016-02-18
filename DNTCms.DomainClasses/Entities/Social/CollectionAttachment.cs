using System;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Entities.Social
{
    public class CollectionAttachment : BaseAttachment
    {
        #region NavigationProperties
        /// <summary>
        /// gets or sets Collection  that this file attached 
        /// </summary>
        public virtual Collection Collection { get; set; }
        /// <summary>
        /// gets or sets Id of Collection  that this file attached
        /// </summary>
        public virtual Guid? CollectionId { get; set; }
        #endregion
    }
}
