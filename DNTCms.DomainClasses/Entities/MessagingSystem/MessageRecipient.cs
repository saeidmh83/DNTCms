//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DNTCms.DomainClasses.Entities.Users;
//using DNTCms.Utility;

//namespace DNTCms.DomainClasses.Entities.MessagingSystem
//{
//    /// <summary>
//    /// Represents Recipient Of Message 
//    /// </summary>
//    public class MessageRecipient
//    {
//        #region Ctor
//        /// <summary>
//        /// 
//        /// </summary>
//        public MessageRecipient()
//        {
//            Id = SequentialGuidGenerator.NewSequentialGuid();
//        }

//        #endregion

//        #region Properties
//        /// <summary>
//        /// gets or sets Identifier
//        /// </summary>
//        public Guid Id { get; set; }
//        /// <summary>
//        /// Indicate that the Message Is read by Receiver
//        /// </summary>
//        public bool IsRead { get; set; }
//        #endregion

//        #region  NavigationProperties
//        /// <summary>
//        /// gets or sets Message's Identifier
//        /// </summary>
//        public Guid MessageId { get; set; }
//        /// <summary>
//        /// gets or sets Message
//        /// </summary>
//        public Message Message { get; set; }
//        /// <summary>
//        /// gets or sets Receiver User's Id
//        /// </summary>
//        public long? UserId { get; set; }
//        /// <summary>
//        /// gets or sets Receiver User
//        /// </summary>
//        public User User { get; set; }
//        /// <summary>
//        /// gets or sets Receiver Role's Id
//        /// </summary>
//        public long? RoleId { get; set; }
//        /// <summary>
//        /// gets or sets Receiver Role
//        /// </summary>
//        public Role Role { get; set; }
//        #endregion
//    }
//}
