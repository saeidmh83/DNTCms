using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Blog;

namespace DNTCms.DomainClasses.Configurations.Blog
{
    public class DraftPostConfig:EntityTypeConfiguration<BlogDraft>
    {
        public DraftPostConfig()
        {
            Property(d => d.Title).HasMaxLength(255).IsRequired();
            
           
        }
    }
}
