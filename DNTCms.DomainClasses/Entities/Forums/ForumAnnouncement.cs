using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Forums
{
    /// <summary>
    /// Represents the Announcement that shown Top Of Forums
    /// </summary>
    public class ForumAnnouncement : BaseEntity<long, long>
    {
        #region Properties
        /// <summary>
        /// gets or sets DateTime That this Announcement Will be Shown
        /// </summary>
        public virtual DateTime StartOn { get; set; }
        /// <summary>
        /// gets or sets DateTime That this Announcement Will be Finished 
        /// </summary>
        public virtual DateTime? ExpireOn { get; set; }
        /// <summary>
        /// gets or sets Content of this Announcement
        /// </summary>
        public virtual string Message { get; set; }
        /// <summary>
        /// Indicate this Announcement Will be shown on Children Forums
        /// </summary>
        public virtual bool ApplyChildren { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets Forum that associated With this Announcement
        /// </summary>
        public virtual Forum Forum { get; set; }
        /// <summary>
        /// gets or sets Identifier of Forum that associated With this Announcement
        /// </summary>
        public virtual long ForumId { get; set; }
        #endregion
    }
}
