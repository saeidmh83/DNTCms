using System.ComponentModel.DataAnnotations.Schema;

namespace DNTCms.DomainClasses.Entities.Cms
{
    /// <summary>
    /// Represent the rating as ComplexType
    /// </summary>
    [ComplexType]
    public class Rating
    {
        /// <summary>
        /// sets or gets total of rating
        /// </summary>
        public virtual double? TotalRating { get; set; }
        /// <summary>
        /// sets or gets rater's count
        /// </summary>
        public virtual long? RatersCount { get; set; }
        /// <summary>
        /// sets or gets average of rating
        /// </summary>
        public virtual double? AverageRating { get; set; }
    }
}
