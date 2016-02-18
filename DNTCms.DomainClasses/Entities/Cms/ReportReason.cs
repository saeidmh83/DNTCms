using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Common;

namespace DNTCms.DomainClasses.Entities.Cms
{
    public class ReportReason : BaseEntity<long,long>
    {
        #region Properties
        /// <summary>
        /// gets or sets Title of this reason
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// gets or sets short details of this this reason
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// gets or sets Order of display
        /// </summary>
        public virtual int DisplayOrder { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// get or set list of reports that associated this this reason
        /// </summary>
        public virtual ICollection<Report> Reports { get; set; }

        #endregion
    }
}
