using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Cms
{
    /// <summary>
    /// Repersents a Report template for every cms section
    /// </summary>
    public class Report
    {
        #region Ctor
        /// <summary>
        /// Create one instance for <see cref="Report"/>
        /// </summary>
        public Report()
        {
            ReportedOn = DateTime.Now;
            Id = SequentialGuidGenerator.NewSequentialGuid();
        }
        #endregion

        #region Properties
        /// <summary>
        /// gets or sets identifier for Report
        /// </summary>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// gets or sets reason of report
        /// </summary>
        public virtual string Reason { get; set; }
        /// <summary>
        /// gets or sets section that is reported
        /// </summary>
        public virtual string Section { get; set; }
        /// <summary>
        /// gets or sets sectionid that is reported
        /// </summary>
        public virtual string SectionId { get; set; }
        /// <summary>
        /// gets or sets report's datetime
        /// </summary>
        public virtual DateTime ReportedOn { get; set; }
        /// <summary>
        /// indicate this report is read by admin
        /// </summary>
        public virtual bool IsRead { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets id of user that is reporter
        /// </summary>
        public virtual long ReporterId { get; set; }
        /// <summary>
        /// gets or sets id of user that is reporter
        /// </summary>
        public virtual User Reporter { get; set; }
        /// <summary>
        /// gets or sets  reasontype 
        /// </summary>
        public virtual ReportReason ReasonType { get; set; }
        /// <summary>
        /// gets or sets  id of reasontype 
        /// </summary>
        public virtual long ReasonTypeId { get; set; }
        #endregion
    }
}
