using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.DomainClasses.Entities.Polling;

namespace DNTCms.DomainClasses.Configurations.Polling
{
    public class PollCommentConfig : EntityTypeConfiguration<PollComment>
    {
        public PollCommentConfig()
        {
            HasOptional(pc => pc.ModifiedBy).WithMany().HasForeignKey(pc => pc.ModifiedById).WillCascadeOnDelete(false);
            HasOptional(pc => pc.CreatedBy).WithMany(u => u.PollComments).HasForeignKey(pc => pc.CreatedById).WillCascadeOnDelete(false);
            HasRequired(pc => pc.Poll).WithMany(p => p.Comments).HasForeignKey(pc => pc.PollId).WillCascadeOnDelete(false);
        }
    }
}
