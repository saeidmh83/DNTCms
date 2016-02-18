using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Entities.Polling
{
    public class Poll : BaseContent
    {
        #region Properties
        /// <summary>
        /// gets or set Date that this Poll will Expire
        /// </summary>
        public virtual DateTime? ExpireOn { get; set; }
        /// <summary>
        ///indicating this poll allow to select multi item
        /// </summary>
        public virtual bool IsMultiSelect { get; set; }
        /// <summary>
        /// gets or sets Count of this poll's votes 
        /// </summary>
        public virtual long VotesCount { get; set; }
        /// <summary>
        /// indicate this Poll is approved by admin if Poll.Moderate==true
        /// </summary>
        public virtual bool IsApproved { get; set; }

        #endregion

        #region NavigationProperties
        /// <summary>
        /// get or set comments of this poll
        /// </summary>
        public virtual ICollection<PollComment> Comments { get; set; }
        /// <summary>
        /// get or set Options Of Poll For selection
        /// </summary>
        public virtual ICollection<PollOption> Options { get; set; }
        /// <summary>
        /// get or set Users List That vote for this poll
        /// </summary>
        public virtual ICollection<User> Voters { get; set; }
        #endregion
    }
}
