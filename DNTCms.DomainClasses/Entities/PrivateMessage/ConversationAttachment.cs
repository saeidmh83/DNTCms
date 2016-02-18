using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Entities.PrivateMessage
{
    /// <summary>
    /// Represents the attachment That attached in Conversation
    /// </summary>
    public class ConversationAttachment : BaseAttachment
    {
        #region NavigationProperties

        public virtual Conversation Conversation { get; set; }
        public virtual Guid? ConversationId { get; set; }
        #endregion
    }
}
