﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Cms;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Entities.Common
{
    /// <summary>
    /// Represents the  entity
    /// </summary>
    /// <typeparam name="TForeignKey">type of user's Id that can be long or long? </typeparam>
    public abstract class Entity<TForeignKey>
    {
        #region Properties
        /// <summary>
        /// gets or sets date that this entity was created
        /// </summary>
        public virtual DateTime CreatedOn { get; set; }
        /// <summary>
        /// gets or sets Date that this entity was updated
        /// </summary>
        public virtual DateTime ModifiedOn { get; set; }
        /// <summary>
        /// gets or sets IP Address of Creator
        /// </summary>
        public virtual string CreatorIp { get; set; }
        /// <summary>
        /// gets or set IP Address of Modifier
        /// </summary>
        public virtual string ModifierIp { get; set; }
        /// <summary>
        /// indicate this entity is Locked for Modify
        /// </summary>
        public virtual bool ModifyLocked { get; set; }
        /// <summary>
        /// indicate this entity is deleted softly
        /// </summary>
        public virtual bool IsDeleted { get; set; }
        /// <summary>
        /// gets or sets information of user agent of modifier
        /// </summary>
        public virtual string ModifierAgent { get; set; }
        /// <summary>
        /// gets or sets information of user agent of Creator
        /// </summary>
        public virtual string CreatorAgent { get; set; }
        /// <summary>
        /// gets or sets date that this entity repoted last time
        /// </summary>
        public virtual DateTime? ReportedOn { get; set; }
        /// <summary>
        /// gets or sets counter for Content's report
        /// </summary>
        public virtual int ReportsCount { get; set; }
        /// <summary>
        /// gets or sets count of Modification Default is 1
        /// </summary>
        public virtual int Version { get; set; }
        /// <summary>
        /// gets or sets action (create,update,softDelete) 
        /// </summary>
        public virtual AuditAction Action { get; set; }
        /// <summary>
        /// gets or sets TimeStamp for prevent concurrency Problems
        /// </summary>
        public virtual byte[] RowVersion { get; set; }
        #endregion

        #region NavigationProperties
        /// <summary>
        /// gets ro sets User that Modify this entity
        /// </summary>
        public virtual User ModifiedBy { get; set; }
        /// <summary>
        /// gets ro sets Id of  User that modify this entity
        /// </summary>
        public virtual TForeignKey ModifiedById { get; set; }
        /// <summary>
        /// gets ro sets User that Create this entity
        /// </summary>
        public virtual User CreatedBy { get; set; }
        /// <summary>
        /// gets ro sets User that Create this entity
        /// </summary>
        public virtual TForeignKey CreatedById { get; set; }
        #endregion
    }
}
