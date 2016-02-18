using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Forums
{
    public class ForumTopicTracker
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="ForumTopicTracker"/>
        /// </summary>
        public ForumTopicTracker()
        {
            LastVisitedOn = DateTime.Now;
        }

        #endregion

        #region Properties
        /// <summary>
        /// gets or sets DateTime Of Las Visit by User
        /// </summary>
        public virtual DateTime LastVisitedOn { get; set; }

        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets topc that Tracked
        /// </summary>
        public virtual ForumTopic Topic { get; set; }
        /// <summary>
        /// gets or sets Id of topic tath Tracked
        /// </summary>
        public virtual long TopicId { get; set; }
        /// <summary>
        /// gets or sets User that tracked The topic
        /// </summary>
        public virtual User Tracker { get; set; }
        /// <summary>
        /// gets or sets Id Of User that Tracked the topic
        /// </summary>
        public virtual long TrackerId { get; set; }
        /// <summary>
        /// gets or sets Forum 
        /// </summary>
        public virtual Forum Forum { get; set; }
        /// <summary>
        /// gets or sets Identifier of Forum . used for delete 
        /// </summary>
        public virtual long ForumId { get; set; }

        #endregion
    }
}
