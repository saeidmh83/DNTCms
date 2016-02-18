//using System;
//using System.Collections.Generic;
//using DNTCms.DomainClasses.Entities.Common;
//using DNTCms.DomainClasses.Entities.Users;
//using DNTCms.Utility;

//namespace DNTCms.DomainClasses.Entities.Cms
//{
//    /// <summary>
//    /// Represents 
//    /// </summary>
//    public class Promotion : BaseEntity<Guid,long>
//    {
//        #region Properties
//        public virtual string Title { get; set; }
//        public virtual string Description { get; set; }
//        public virtual bool IsEnable { get; set; }
//        public virtual PromotionRequirements Requirements { get; set; }
//        public virtual long ReputationRequired { get; set; }
//        public virtual long ForumPostsCountRequired { get; set; }
//        public virtual long BlogPostsCountRequired { get; set; }
//        #endregion

//        #region NavigationProperties
//        public virtual Roles SourceRole { get; set; }
//        public virtual Roles TargetRole { get; set; }
//        #endregion
//    }
//}
