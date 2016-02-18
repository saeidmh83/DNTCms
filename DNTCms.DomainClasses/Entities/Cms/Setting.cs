namespace DNTCms.DomainClasses.Entities.Cms
{
    /// <summary>
    /// Represent The CMS setting
    /// </summary>
    public class Setting
    {
        #region Properties
        /// <summary>
        /// sets or gets name of setting
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// sets or gets value of setting
        /// </summary>
        public virtual string Value { get; set; }
        /// <summary>
        /// sets or gets Type of setting
        /// </summary>
        public virtual string Type { get; set; }
        #endregion
    }
}
