using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using DNTCms.DomainClasses.Entities.Users;
using DNTCms.Utility;

namespace DNTCms.DomainClasses.Configurations.Users
{
    /// <summary>
    /// نشان دهنده  مپینگ کلاس کاربر
    /// </summary>
    public class UserConfig : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// سازنده پیش فرض
        /// </summary>
        public UserConfig()
        {
            ToTable("Users");

            Property(u => u.LastIp).IsOptional().HasMaxLength(20);
            Property(u => u.RowVersion).IsRowVersion();
            Property(u => u.AboutMe).IsOptional().HasMaxLength(1024);
            Property(u => u.AdminComment).IsOptional().HasMaxLength(1024);
            Property(u => u.Avatar).IsOptional().HasMaxLength(50);
            Property(u => u.FaceBookId).IsOptional().HasMaxLength(50);
            Property(u => u.GooglePlusId).IsOptional().HasMaxLength(50);

            Ignore(u => u.ConnectionIds);

            Property(u => u.UserName)
                 .IsRequired()
                 .HasMaxLength(50)
                 .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_UniqueUserName") { IsUnique = true }));

            Property(u => u.DisplayName).HasMaxLength(50).IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_UniqueNameForShow") { IsUnique = true }));

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_UniqueEmail") { IsUnique = true }));

            HasMany(u=>u.BlogDrafts).WithRequired(bd=>bd.Owner).HasForeignKey(bd=>bd.OwnerId).WillCascadeOnDelete(true);
            HasMany(u => u.ModeratedForums).WithRequired(fm => fm.Moderator).HasForeignKey(fm => fm.ModeratorId).WillCascadeOnDelete(false);
            HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId).WillCascadeOnDelete(true);
            HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId).WillCascadeOnDelete(true);
            HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId).WillCascadeOnDelete(true);
            HasMany(u => u.Attachments).WithRequired(a => a.Owner).HasForeignKey(a => a.OwnerId).WillCascadeOnDelete(false);
            HasMany(u => u.ReceivedConversations).WithRequired(c => c.Receiver).HasForeignKey(c => c.ReceiverId).WillCascadeOnDelete(false);
            HasMany(u => u.SentConversations).WithRequired(c => c.Sender).HasForeignKey(c => c.SenderId).WillCascadeOnDelete(false);
            HasMany(u => u.SentMessages).WithRequired(m => m.Sender).HasForeignKey(m => m.SenderId).WillCascadeOnDelete(false);
            HasMany(u=>u.TrackedForumTopics).WithRequired(ftt=>ftt.Tracker).HasForeignKey(ftt=>ftt.TopicId).WillCascadeOnDelete(false);
            HasMany(u=>u.TrackedForums).WithRequired(ft=>ft.Tracker).HasForeignKey(ft=>ft.TrackerId).WillCascadeOnDelete(false);
        }
    }
}
