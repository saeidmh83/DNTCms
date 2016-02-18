using System;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Cms
{
    /// <summary>
    /// Represents Rating Record regard by section type for Rating System
    /// </summary>
    public class UserRating
    {
        #region Ctor
        /// <summary>
        /// Create one instance of <see cref="UserRating"/>
        /// </summary>
        public UserRating()
        {
            Id = SequentialGuidGenerator.NewSequentialGuid();
        }
        #endregion

        #region Properties
        /// <summary>
        /// gets or sets Id of Rating Record
        /// </summary>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// gets or sets value of rate
        /// </summary>
        public virtual double RatingValue { get; set; }
        /// <summary>
        /// gets or sets Section's Id 
        /// </summary>
        public virtual string SectionId { get; set; }
        /// <summary>
        /// gets or sets Section 
        /// </summary>
        public virtual string Section { get; set; }
        #endregion

        #region Navigation Properties
        /// <summary>
        /// gets or sets user that rate one section
        /// </summary>
        public virtual User Rater { get; set; }
        /// <summary>
        /// gets or sets Rater Id that rate one section
        /// </summary>
        public virtual long RaterId { get; set; }

        #endregion
    }
}
