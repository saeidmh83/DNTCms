using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Entities.Announcements
{
    /// <summary>
    /// Repersents Comment For Announcement
    /// </summary>
    public class AnnouncementComment : BaseComment
    {
        #region NavigationProperties
        /// <summary>
        /// gets or sets body of announcement's comment
        /// </summary>
        public virtual long? ReplyId { get; set; }
        /// <summary>
        /// gets or sets body of announcement's comment
        /// </summary>
        public virtual AnnouncementComment Reply { get; set; }
        /// <summary>
        /// gets or sets body of announcement's comment
        /// </summary>
        public virtual ICollection<AnnouncementComment> Children { get; set; }
        /// <summary>
        /// gets or sets announcement that this comment sent to it
        /// </summary>
        public virtual Announcement Announcement { get; set; }
        /// <summary>
        /// gets or sets announcement'Id that this comment sent to it
        /// </summary>
        public virtual long AnnouncementId { get; set; }
        #endregion
    }
}
