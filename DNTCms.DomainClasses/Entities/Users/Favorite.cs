using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Users
{
    /// <summary>
    /// Represents the Favorite record
    /// </summary>
    public class Favorite
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="Favorite"/>
        /// </summary>
        public Favorite()
        {
            Id = SequentialGuidGenerator.NewSequentialGuid();
            CreatedOn = DateTime.Now;
        }
        #endregion

        #region Properties
        /// <summary>
        /// gets or sets identifier 
        /// </summary>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// gets or sets date that this record Created
        /// </summary>
        public virtual DateTime CreatedOn { get; set; }
        /// <summary>
        /// gets or sets the description of this favorite
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// gets or sets the page url
        /// </summary>
        public virtual string Url { get; set; }
        /// <summary>
        /// gets or sets the title of page
        /// </summary>
        public virtual string Title { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets the user that is owner of this favorite
        /// </summary>
        public virtual User Owner { get; set; }
        /// <summary>
        /// gets or sets the id fo user that is owner of this favorite
        /// </summary>
        public virtual long OwnerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }
        #endregion
    }
}
