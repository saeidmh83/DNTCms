using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.MessagingSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class ReminderFrequency : BaseEntity<Guid, long>
    {
        #region Properties
        /// <summary>
        /// Indicate that the record is disable or enable
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// gets or sets title of this record
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// gets or sets distance for next reminder
        /// </summary>
        public int FrequencyDays { get; set; }
        #endregion

        #region NavigationProperties
        ///// <summary>
        ///// get or set  Message that user this reminder
        ///// </summary>
        //public ICollection<Message> Messages { get; set; }
        #endregion
    }
}
