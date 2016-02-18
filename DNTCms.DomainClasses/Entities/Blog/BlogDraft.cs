using System;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Blog
{
    /// <summary>
    /// Represents the Post's Draft
    /// </summary>
    public class BlogDraft
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="BlogDraft"/>
        /// </summary>
        public BlogDraft()
        {
            Id = SequentialGuidGenerator.NewSequentialGuid();
        }
        #endregion

        #region Properties
        /// <summary>
        /// gets or sets Id of post's draft
        /// </summary>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// gets or sets body of post's draft
        /// </summary>
        public virtual string Body { get; set; }
        /// <summary>
        /// gets or set title of post's draft
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// gets or sets tags of post's draft that seperated using ','
        /// </summary>
        public virtual string TagNames { get; set; }
        /// <summary>
        /// gets or sets value indicating whether this draft is ready to publish
        /// </summary>
        public virtual bool IsReadyForPublish { get; set; }
        /// <summary>
        /// ges ro sets DateTime that this draft added
        /// </summary>
        public virtual DateTime CreatedOn { get; set; }
        /// <summary>
        /// gets or sets information of User-Agent
        /// </summary>
        public virtual string Agent { get; set; }
        /// <summary>
        /// gets or sets user's ip address
        /// </summary>
        public virtual string Ip { get; set; }
        /// <summary>
        /// gets or sets date that this draft publish as ready
        /// </summary>
        public virtual DateTime? ReadyForPublishOn { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets Id of user that he is owner of this draft
        /// </summary>
        public virtual long OwnerId { get; set; }
        /// <summary>
        /// gets or sets user that he is owner of this draft
        /// </summary>
        public virtual User Owner { get; set; }
        #endregion
    }
}
