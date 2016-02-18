using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.PrivateMessage
{
    /// <summary>
    /// Represents One Reply to Conversation
    /// </summary>
    public class ConversationReply
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="ConversationReply"/>
        /// </summary>
        public ConversationReply()
        {
            Id = SequentialGuidGenerator.NewSequentialGuid();
            SentOn = DateTime.Now;


        }
        #endregion

        #region Properties
        /// <summary>
        /// gets or sets identifier of record
        /// </summary>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// represents this conversaionReply is seen
        /// </summary>
        public virtual bool IsRead { get; set; }
        /// <summary>
        /// gets or sets body of this conversationReply
        /// </summary>
        public virtual string Body { get; set; }
        /// <summary>
        /// gets or sets Date that this record added
        /// </summary>
        public virtual DateTime SentOn { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets  Parent's Id Of this ConversationReply
        /// </summary>
        public virtual Guid? ParentId { get; set; }
        /// <summary>
        /// gets or sets Parent Of this ConversationReply
        /// </summary>
        public virtual ConversationReply Parent { get; set; }
        /// <summary>
        /// get or set Children Of this ConversationReply
        /// </summary>
        public virtual ICollection<ConversationReply> Children { get; set; }
        /// <summary>
        /// gets or sets if of  user that start this conversationReply
        /// </summary>
        public virtual long SenderId { get; set; }
        /// <summary>
        /// gets or sets user that start this conversationReply
        /// </summary>
        public virtual User Sender { get; set; }
        /// <summary>
        /// gets or sets Conversation that this message sent in it 
        /// </summary>
        public virtual Conversation Conversation { get; set; }
        /// <summary>
        /// gets or sets Id of Conversation that this message sent in it 
        /// </summary>
        public virtual Guid ConversationId { get; set; }
        #endregion
    }
}
