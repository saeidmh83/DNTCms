using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Entities.Cms
{
    public class Observation
    {
        #region Ctor
        /// <summary>
        /// create one instance of <see cref="Observation"/>
        /// </summary>
        public Observation()
        {
            LastObservedOn = DateTime.Now;
            Id = SequentialGuidGenerator.NewSequentialGuid();
        }
        #endregion

        #region Properties
        public virtual Guid Id { get; set; }
        /// <summary>
        /// gets or sets datetime of last visit 
        /// </summary>
        public virtual DateTime LastObservedOn { get; set; }
        /// <summary>
        /// gets or sets Id Of section That user is  observing the entity
        /// </summary>
        public virtual string SectionId { get; set; }
        /// <summary>
        /// gets or sets  section That user is  observing in it
        /// </summary>
        public virtual string Section { get; set; }
        #endregion

        #region NavigationProperites
        /// <summary>
        /// gets or sets user that observed the entity
        /// </summary>
        public virtual User Observer { get; set; }
        /// <summary>
        /// gets or sets identifier of user that observed the entity
        /// </summary>
        public virtual long ObserverId { get; set; }
        #endregion
    }
}
