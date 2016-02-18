using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Entities.Polling
{
    public class PollComment : BaseComment
    {
        #region NavigationProperties

        /// <summary>
        /// gets or sets body of blog poll's comment
        /// </summary>
        public virtual long? ReplyId { get; set; }
        /// <summary>
        /// gets or sets body of blog poll's comment
        /// </summary>
        public virtual PollComment Reply { get; set; }
        /// <summary>
        /// gets or sets body of blog poll's comment
        /// </summary>
        public virtual ICollection<PollComment> Children { get; set; }
        /// <summary>
        /// gets or sets poll that this comment sent to it
        /// </summary>
        public virtual Poll Poll { get; set; }
        /// <summary>
        /// gets or sets poll'Id that this comment sent to it
        /// </summary>
        public virtual long PollId { get; set; }
        #endregion
    }
}
