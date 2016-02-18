using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.News;

namespace DNTCms.DomainClasses.Configurations.News
{
   public class NewsCommentConfig:EntityTypeConfiguration<NewsComment>
   {
       public NewsCommentConfig()
        {
            HasOptional(nc => nc.ModifiedBy).WithMany().HasForeignKey(nc => nc.ModifiedById).WillCascadeOnDelete(false);
            HasOptional(nc => nc.CreatedBy).WithMany(u=>u.NewsComments).HasForeignKey(nc => nc.CreatedById).WillCascadeOnDelete(false);
        }
    }
}
