using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Forums;

namespace DNTCms.DomainClasses.Configurations.Forums
{
    public class ForumPostConfig : EntityTypeConfiguration<ForumPost>
    {
        public ForumPostConfig()
        {
          
            HasRequired(fp => fp.CreatedBy).WithMany(u => u.ForumPosts).HasForeignKey(fp => fp.CreatedById).WillCascadeOnDelete(false);
            HasRequired(fp=>fp.ModifiedBy).WithMany().HasForeignKey(fp=>fp.ModifiedById).WillCascadeOnDelete(false);
        }
    }
}
