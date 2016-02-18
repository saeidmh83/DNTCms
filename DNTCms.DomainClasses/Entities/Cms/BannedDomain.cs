using System;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Entities.Cms
{
    /// <summary>
    /// Represents Domain that is banned
    /// </summary>
    public class BannedDomain : BaseEntity<long, long>
    {
        #region Propertie
        /// <summary>
        /// gets or sets DomainName
        /// </summary>
        public virtual string Name { get; set; }
        #endregion
    }
}
