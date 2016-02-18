using System;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Users
{
    /// <summary>
    /// Represents the Reputation Log Record
    /// </summary>
    public class ReputationLog
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="ReputationLog"/>
        /// </summary>
        public ReputationLog()
        {
            Id = SequentialGuidGenerator.NewSequentialGuid();
            ObtainedOn=DateTime.Now;
        }
        #endregion

        #region Properties
        /// <summary>
        /// gets or sets identifier
        /// </summary>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// gets or sets value of rating
        /// </summary>
        public virtual double TotalRating { get; set; }
        /// <summary>
        /// gets or sets date that this rating obtained
        /// </summary>
        public virtual DateTime ObtainedOn { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets User 
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// gets or sets the identifier of User
        /// </summary>
        public virtual long UserId { get; set; }
        #endregion
    }
}
