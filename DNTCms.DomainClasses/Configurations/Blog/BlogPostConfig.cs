using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Blog;

namespace DNTCms.DomainClasses.Configurations.Blog
{
    public class BlogPostConfig : EntityTypeConfiguration<BlogPost>
    {
        public BlogPostConfig()
        {
            HasMany(p => p.Contributors).WithMany(u => u.ContributedBlogPosts).Map(m =>
            {
                m.ToTable("BlogPostContributor");
                m.MapLeftKey("BlogPostId");
                m.MapRightKey("ContributorId");
            });
            HasRequired(b=>b.CreatedBy).WithMany(u=>u.BlogPosts).HasForeignKey(b=>b.CreatedById).WillCascadeOnDelete(false);
            HasRequired(b=>b.ModifiedBy).WithMany().HasForeignKey(b=>b.ModifiedById).WillCascadeOnDelete(false);
        }
    }
}
