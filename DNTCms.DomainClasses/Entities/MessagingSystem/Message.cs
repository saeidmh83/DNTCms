//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DNTCms.DomainClasses.Entities.PrivateMessage;
//using DNTCms.DomainClasses.Entities.Users;
//using DNTCms.Utility;

//namespace DNTCms.DomainClasses.Entities.MessagingSystem
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class Message
//    {
//        #region Ctor
//        /// <summary>
//        /// create one instance of <see cref="Message"/>
//        /// </summary>
//        public Message()
//        {
//            Id = SequentialGuidGenerator.NewSequentialGuid();
//            CreateDate = DateTime.Now;
//        }
//        #endregion

//        #region Properties
//        /// <summary>
//        /// gets or sets identifier of record
//        /// </summary>
//        public Guid Id { get; set; }
//        /// <summary>
//        /// gets or sets body of this Message
//        /// </summary>
//        public string Body { get; set; }
//        /// <summary>
//        /// gets or sets subject of this conversation
//        /// </summary>
//        public string Subject { get; set; }
//        /// <summary>
//        /// gets or sets Date that this record added
//        /// </summary>
//        public DateTime CreateDate { get; set; }
//        /// <summary>
//        /// Indicate That the Message send by Reminder
//        /// </summary>
//        public bool IsReminder { get; set; }
//        /// <summary>
//        /// Gets or sets Date that this Message's Reminder is finish
//        /// </summary>
//        public DateTime ExpiryDate { get; set; }
//        /// <summary>
//        /// gets or sets next reminder Date
//        /// </summary>
//        public DateTime? NextReminderDate { get; set; }
//        #endregion

//        #region NavigationProperties
//        /// <summary>
//        /// gets or sets  Parent's Id Of this Message
//        /// </summary>
//        public Guid? ParentId { get; set; }
//        /// <summary>
//        /// gets or sets Parent Of this Message
//        /// </summary>
//        public Message Parent { get; set; }
//        /// <summary>
//        /// get or set Children Of this Message
//        /// </summary>
//        public ICollection<Message> Children { get; set; }
//        /// <summary>
//        /// gets or sets Creator's Id of this record
//        /// </summary>
//        public long CreatorId { get; set; }
//        /// <summary>
//        /// gets or sets Creator of this record
//        /// </summary>
//        public User Creator { get; set; }
//        /// <summary>
//        /// gets or sets ReminderFrequency that used for this message
//        /// </summary>
//        public ReminderFrequency ReminderFrequency { get; set; }
//        /// <summary>
//        /// gets or sets ReminderFrequency's Id that used for this message
//        /// </summary>
//        public Guid? ReminderFrequencyId { get; set; }
//        /// <summary>
//        /// get or set MessageRecipients of this Message
//        /// </summary>
//        public ICollection<MessageRecipient> MessageRecipients { get; set; }
//        #endregion
//    }
//}
