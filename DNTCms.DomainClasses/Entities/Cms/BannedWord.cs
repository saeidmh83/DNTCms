using System;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Cms
{
    /// <summary>
    /// Represents the banned words
    /// </summary>
    public class BannedWord : BaseEntity<long, long>
    {
        #region Properties
        /// <summary>
        /// gets or sets Bad word
        /// </summary>
        public string BadWord { get; set; }
        /// <summary>
        /// gets or sets Good replaceword
        /// </summary>
        public string GoodWord { get; set; }
        /// <summary>
        /// indicating that this Word is spam
        /// </summary>
        public bool IsStopWord { get; set; }
        #endregion
    }
}
