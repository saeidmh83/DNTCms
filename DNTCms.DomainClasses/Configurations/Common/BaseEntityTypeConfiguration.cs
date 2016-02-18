using DNTCms.DomainClasses.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNTCms.DomainClasses.Configurations.Common
{
    /// <summary>
    /// Represents Base Mapping class
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TForeignKey"></typeparam>
    public class BaseEntityTypeConfiguration<TEntity, TForeignKey> : EntityTypeConfiguration<TEntity> where TEntity : Entities.Common.Entity<TForeignKey>
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public BaseEntityTypeConfiguration()
        {
            Property(e => e.CreatedOn)
                .IsRequired()
                 .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_CreatedOn")));

        }
    }
}
