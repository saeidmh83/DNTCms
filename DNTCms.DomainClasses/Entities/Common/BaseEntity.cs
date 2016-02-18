using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Users;

namespace DNTCms.DomainClasses.Entities.Common
{
    /// <summary>
    /// Represents the base Entity
    /// </summary>
    /// <typeparam name="TKey">type of Id</typeparam>
    /// <typeparam name="TForeignKey">type of User's Id that can be long or long?</typeparam>
    public abstract class BaseEntity<TKey,TForeignKey> : Entity<TForeignKey>
    {
        #region Properties
        /// <summary>
        /// gets or sets Identifier of this Entity
        /// </summary>
        public virtual TKey Id { get; set; }
        #endregion
    }
}
