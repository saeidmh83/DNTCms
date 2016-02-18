using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Forums
{
    /// <summary>
    /// Represents 
    /// </summary>
    public class ForumTracker
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="ForumTracker"/>
        /// </summary>
        public ForumTracker()
        {
            LastMarkedOn = DateTime.Now;
        }

        #endregion

        #region Properties
        /// <summary>
        /// gets or sets DateTime Of Las Visit by User
        /// </summary>
        public virtual DateTime LastMarkedOn { get; set; }

        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets Forum that Tracked
        /// </summary>
        public virtual Forum Forum { get; set; }
        /// <summary>
        /// gets or sets Id of Forum tath Tracked
        /// </summary>
        public virtual long ForumId { get; set; }
        /// <summary>
        /// gets or sets User that tracked The forum
        /// </summary>
        public virtual User Tracker { get; set; }
        /// <summary>
        /// gets or sets Id Of User that Tracked the forum
        /// </summary>
        public virtual long TrackerId { get; set; }
        #endregion
    }
}
