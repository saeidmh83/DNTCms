using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Entities.Forums
{
    /// <summary>
    /// Represents The Moderator For Forum
    /// </summary>
    public class ForumModerator
    {
        #region NavigationProperties
        /// <summary>
        /// gets or sets Forum
        /// </summary>
        public virtual Forum Forum { get; set; }
        /// <summary>
        /// gets or sets identifier of forum
        /// </summary>
        public virtual long ForumId { get; set; }
        /// <summary>
        /// gets or sets user that moderate forum
        /// </summary>
        public virtual User Moderator { get; set; }
        /// <summary>
        /// gets or sets id of user that moderate forum
        /// </summary>
        public virtual long ModeratorId { get; set; }
        /// <summary>
        /// gets or sets permission of user that moderate forum
        /// </summary>
        public virtual ForumModeratorPermissions Permissions { get; set; }
        /// <summary>
        /// indicate moderator's permissions in this forum apply with
        /// </summary>
        public virtual bool ApplyChildren { get; set; }
        #endregion
    }
}
