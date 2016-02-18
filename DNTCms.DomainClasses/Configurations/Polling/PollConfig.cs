using System.Data.Entity.ModelConfiguration;
using DNTCms.DomainClasses.Entities.Polling;

namespace DNTCms.DomainClasses.Configurations.Polling
{
    public class PollConfig : EntityTypeConfiguration<Poll>
    {
        public PollConfig()
        {
            HasMany(p => p.Voters).WithMany(u => u.VotedPolls).Map(m =>
            {
                m.MapLeftKey("VoterId");
                m.MapRightKey("PollId");
                m.ToTable("PollVoter");
            });
            HasMany(p => p.Tags).WithMany(t => t.Polls).Map(m =>
              {
                  m.MapLeftKey("TagId");
                  m.MapRightKey("PollId");
                  m.ToTable("PollTag");
              });
            HasMany(p => p.Options).WithRequired(po => po.Poll).HasForeignKey(po => po.PollId).WillCascadeOnDelete(true);
            HasRequired(p=>p.CreatedBy).WithMany(u=>u.Polls).HasForeignKey(p=>p.CreatedById).WillCascadeOnDelete(false);
            HasRequired(p => p.ModifiedBy).WithMany().HasForeignKey(p => p.ModifiedById).WillCascadeOnDelete(false);
        }
    }
}
