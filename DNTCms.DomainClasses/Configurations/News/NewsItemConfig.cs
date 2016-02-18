
using System.Data.Entity.ModelConfiguration;
using DNTCms.DomainClasses.Entities.News;

namespace DNTCms.DomainClasses.Configurations.News
{
    public class NewsItemConfig : EntityTypeConfiguration<NewsItem>
    {
        public NewsItemConfig()
        {
            HasRequired(n => n.CreatedBy).WithMany(u => u.NewsItems).HasForeignKey(n => n.CreatedById).WillCascadeOnDelete(false);
            HasRequired(n=>n.ModifiedBy).WithMany().HasForeignKey(n=>n.ModifiedById).WillCascadeOnDelete(false);
        }
    }
}
