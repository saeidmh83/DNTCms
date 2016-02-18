using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using DNTCms.DomainClasses.Entities.Blog;
namespace DNTCms.DomainClasses.Configurations.Blog
{
    public class BlogCommentConfig : EntityTypeConfiguration<BlogComment>
    {
        public BlogCommentConfig()
        {
            HasOptional(bc => bc.ModifiedBy).WithMany().HasForeignKey(bc => bc.ModifiedById).WillCascadeOnDelete(false);
            HasOptional(bc => bc.CreatedBy).WithMany(u => u.BlogComments).HasForeignKey(bc => bc.CreatedById).WillCascadeOnDelete(false);
        }
    }
}
