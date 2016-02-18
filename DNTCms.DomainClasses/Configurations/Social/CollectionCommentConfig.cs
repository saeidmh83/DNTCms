using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Social;

namespace DNTCms.DomainClasses.Configurations.Social
{
    public class CollectionCommentConfig : EntityTypeConfiguration<CollectionComment>
    {
        public CollectionCommentConfig()
        {
            HasRequired(cc => cc.ModifiedBy).WithMany().HasForeignKey(cc => cc.ModifiedById).WillCascadeOnDelete(false);
            HasRequired(cc => cc.CreatedBy).WithMany(u => u.CollectionComments).HasForeignKey(cc => cc.CreatedById).WillCascadeOnDelete(false);
        }
    }
}
