using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Entities.Announcements
{
    /// <summary>
    /// Represents Announcement For Announcement Section
    /// </summary>
    public class Announcement : BaseContent
    {
        #region Properties
        /// <summary>
        /// gets or sets Date that this Announcement will Expire
        /// </summary>
        public virtual DateTime? ExpireOn { get; set; }
      
        #endregion

        #region NavigationProperties
        /// <summary>
        /// get or set Collection of Comments for this Announcement
        /// </summary>
        public virtual ICollection<AnnouncementComment> Comments { get; set; }

        #endregion
    }
}