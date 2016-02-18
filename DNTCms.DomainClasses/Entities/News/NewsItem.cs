using System;
using System.Collections.Generic;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Common;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Entities.News
{
    /// <summary>
    /// Represents one news item 
    /// </summary>
    public class NewsItem : BaseContent
    {
        #region Properties
        /// <summary>
        /// indicating that this news show on sidebar
        /// </summary>
        public virtual bool ShowOnSideBar { get; set; }

        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets or sets  newsitem's Reviews
        /// </summary>
        public virtual ICollection<NewsComment> Comments { get; set; }
        #endregion
    }
}
