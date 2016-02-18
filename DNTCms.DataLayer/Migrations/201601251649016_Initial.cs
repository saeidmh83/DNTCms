namespace DNTCms.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DisplayName = c.String(),
                        IsSystemRole = c.Boolean(nullable: false),
                        IsBanned = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 100),
                        Permissions = c.String(),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_UniqueRoleName");
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AutoConvertDraftsToLive = c.Boolean(nullable: false),
                        IsBanned = c.Boolean(nullable: false),
                        BannedDate = c.DateTime(),
                        BannedReason = c.String(),
                        AboutMe = c.String(maxLength: 1024),
                        LastActivityOn = c.DateTime(),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        BlogPostsCount = c.Long(nullable: false),
                        NewsItemsCount = c.Long(nullable: false),
                        PollItemsCount = c.Long(nullable: false),
                        FollowersCount = c.Long(nullable: false),
                        FollowingsCount = c.Long(nullable: false),
                        AnnouncementsCount = c.Long(nullable: false),
                        ForumTopicsCount = c.Long(nullable: false),
                        BlogPostCommentsCount = c.Long(nullable: false),
                        AnnouncementCommentsCount = c.Long(nullable: false),
                        NewsCommentsCount = c.Long(nullable: false),
                        PollCommentsCount = c.Long(nullable: false),
                        PollsCount = c.Long(nullable: false),
                        ForumPostsCount = c.Long(nullable: false),
                        AttachmentsCount = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsSystemAccount = c.Boolean(nullable: false),
                        AdminComment = c.String(maxLength: 1024),
                        DisabledPermissions = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        AvatarFileName = c.String(maxLength: 50),
                        Signature = c.String(),
                        BirthDay = c.DateTime(),
                        RegisterDate = c.DateTime(nullable: false),
                        GooglePlusId = c.String(maxLength: 50),
                        FaceBookId = c.String(maxLength: 50),
                        LinkedInId = c.String(),
                        LastIp = c.String(maxLength: 20),
                        LastLoginDate = c.DateTime(),
                        ShowEmailAddressAsIamge = c.Boolean(nullable: false),
                        NotifyAllows = c.Int(nullable: false),
                        EmailReceiveAllows = c.Int(nullable: false),
                        TotalReputation = c.Long(nullable: false),
                        IsChangedPermissions = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Space = c.Long(nullable: false),
                        LastForumPostCreatedOn = c.DateTime(),
                        LastMarkedForumsOn = c.DateTime(),
                        Email = c.String(nullable: false, maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Collection_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collections", t => t.Collection_Id)
                .Index(t => t.DisplayName, unique: true, name: "IX_UniqueNameForShow")
                .Index(t => t.Email, unique: true, name: "IX_UniqueEmail")
                .Index(t => t.UserName, unique: true, name: "IX_UniqueUserName")
                .Index(t => t.Collection_Id);
            
            CreateTable(
                "dbo.AnnouncementComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReplyId = c.Long(),
                        AnnouncementId = c.Long(nullable: false),
                        CreatorDisplayName = c.String(),
                        Body = c.String(),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        SiteUrl = c.String(),
                        Email = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(),
                        CreatedById = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Announcements", t => t.AnnouncementId, cascadeDelete: true)
                .ForeignKey("dbo.AnnouncementComments", t => t.ReplyId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ReplyId)
                .Index(t => t.AnnouncementId)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ExpireOn = c.DateTime(),
                        Body = c.String(),
                        Title = c.String(),
                        SlugUrl = c.String(),
                        MetaTitle = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        FocusKeyword = c.String(),
                        UseCanonicalUrl = c.Boolean(nullable: false),
                        CanonicalUrl = c.String(),
                        UseNoFollow = c.Boolean(nullable: false),
                        UseNoIndex = c.Boolean(nullable: false),
                        IsInSitemap = c.Boolean(nullable: false),
                        AllowComments = c.Boolean(nullable: false),
                        AllowCommentForAnonymous = c.Boolean(nullable: false),
                        ViewCountByRss = c.Long(nullable: false),
                        ViewCount = c.Long(nullable: false),
                        ApprovedCommentsCount = c.Int(nullable: false),
                        UnApprovedCommentsCount = c.Int(nullable: false),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        ShowWithRss = c.Boolean(nullable: false),
                        DaysCountForSupportComment = c.Int(nullable: false),
                        SocialSnippetIconName = c.String(),
                        SocialSnippetTitle = c.String(),
                        SocialSnippetDescription = c.String(),
                        TagNames = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                        Announcement_Id = c.Long(),
                        NewsItem_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .ForeignKey("dbo.Announcements", t => t.Announcement_Id)
                .ForeignKey("dbo.NewsItems", t => t.NewsItem_Id)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.Announcement_Id)
                .Index(t => t.NewsItem_Id);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LinkBackStatus = c.Int(nullable: false),
                        Pinged = c.Boolean(nullable: false),
                        Body = c.String(),
                        Title = c.String(),
                        SlugUrl = c.String(),
                        MetaTitle = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        FocusKeyword = c.String(),
                        UseCanonicalUrl = c.Boolean(nullable: false),
                        CanonicalUrl = c.String(),
                        UseNoFollow = c.Boolean(nullable: false),
                        UseNoIndex = c.Boolean(nullable: false),
                        IsInSitemap = c.Boolean(nullable: false),
                        AllowComments = c.Boolean(nullable: false),
                        AllowCommentForAnonymous = c.Boolean(nullable: false),
                        ViewCountByRss = c.Long(nullable: false),
                        ViewCount = c.Long(nullable: false),
                        ApprovedCommentsCount = c.Int(nullable: false),
                        UnApprovedCommentsCount = c.Int(nullable: false),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        ShowWithRss = c.Boolean(nullable: false),
                        DaysCountForSupportComment = c.Int(nullable: false),
                        SocialSnippetIconName = c.String(),
                        SocialSnippetTitle = c.String(),
                        SocialSnippetDescription = c.String(),
                        TagNames = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReplyId = c.Long(),
                        PostId = c.Long(nullable: false),
                        CreatorDisplayName = c.String(),
                        Body = c.String(),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        SiteUrl = c.String(),
                        Email = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(),
                        CreatedById = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogComments", t => t.ReplyId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .ForeignKey("dbo.BlogPosts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.ReplyId)
                .Index(t => t.PostId)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.LinkBacks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Url = c.String(),
                        Type = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        PostId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogPosts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        SlugUrl = c.String(),
                        Description = c.String(),
                        HowToPay = c.String(),
                        Visibility = c.Int(nullable: false),
                        Color = c.String(),
                        Photo = c.String(),
                        TagNames = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Size = c.Long(nullable: false),
                        Extension = c.String(),
                        AttachedOn = c.DateTime(nullable: false),
                        DownloadsCount = c.Long(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Section = c.Int(nullable: false),
                        Agent = c.String(),
                        OwnerId = c.Long(nullable: false),
                        CollectionId = c.Guid(),
                        ConversationId = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collections", t => t.CollectionId)
                .ForeignKey("dbo.Conversations", t => t.ConversationId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .Index(t => t.OwnerId)
                .Index(t => t.CollectionId)
                .Index(t => t.ConversationId);
            
            CreateTable(
                "dbo.CollectionPosts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsPin = c.Boolean(nullable: false),
                        Body = c.String(),
                        Title = c.String(),
                        SlugAltUrl = c.String(),
                        AllowComments = c.Boolean(nullable: false),
                        ModerateComments = c.Boolean(nullable: false),
                        ViewCount = c.Long(nullable: false),
                        ApprovedCommentsCount = c.Int(nullable: false),
                        UnApprovedCommentsCount = c.Int(nullable: false),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        IsEnableForShare = c.Boolean(nullable: false),
                        CollectionId = c.Guid(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collections", t => t.CollectionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.CollectionId)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.CollectionComments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Body = c.String(),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        IsApproved = c.Boolean(nullable: false),
                        PostId = c.Guid(nullable: false),
                        ReplyId = c.Guid(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CollectionComments", t => t.ReplyId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .ForeignKey("dbo.CollectionPosts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.ReplyId)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.ForumTopics",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        TagNames = c.String(),
                        IsSticky = c.Boolean(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        LastPostId = c.Long(nullable: false),
                        LastPosterId = c.Long(nullable: false),
                        LastPostTitle = c.String(),
                        LastPoster = c.String(),
                        LastPostCreatedOn = c.DateTime(),
                        IsApproved = c.Boolean(nullable: false),
                        IsAnnouncement = c.Boolean(nullable: false),
                        ViewCount = c.Long(nullable: false),
                        ApprovedPostsCount = c.Int(nullable: false),
                        UnApprovedPostsCount = c.Int(nullable: false),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        ClosedOn = c.DateTime(),
                        ClosedReason = c.String(),
                        ReportsCount = c.Int(nullable: false),
                        ModeratePosts = c.Boolean(nullable: false),
                        Level = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        ForumId = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Forums", t => t.ForumId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ForumId)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Forums",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        SlugUrl = c.String(),
                        DisplayOrder = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsClose = c.Boolean(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        Depth = c.Int(nullable: false),
                        ApprovedPostsCount = c.Long(nullable: false),
                        ApprovedTopicsCount = c.Long(nullable: false),
                        LastTopicId = c.Long(nullable: false),
                        LastTopicCreatedOn = c.DateTime(),
                        LastTopicTitle = c.String(),
                        LastTopicCreator = c.String(),
                        LastTopicCreatorId = c.Long(nullable: false),
                        ModerateTopics = c.Boolean(nullable: false),
                        ModeratePosts = c.Boolean(nullable: false),
                        UnApprovedPostsCount = c.Long(nullable: false),
                        UnApprovedTopicsCount = c.Long(nullable: false),
                        SocialSnippetIconName = c.String(),
                        SocialSnippetTitle = c.String(),
                        SocialSnippetDescription = c.String(),
                        Path = c.String(),
                        IsModeratorsInherited = c.Boolean(nullable: false),
                        LastPostCreatedOn = c.DateTime(),
                        ParentId = c.Long(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forums", t => t.ParentId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ParentId)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.ForumAnnouncements",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartOn = c.DateTime(nullable: false),
                        ExpireOn = c.DateTime(),
                        Message = c.String(),
                        ApplyChildren = c.Boolean(nullable: false),
                        ForumId = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById, cascadeDelete: true)
                .ForeignKey("dbo.Forums", t => t.ForumId, cascadeDelete: true)
                .Index(t => t.ForumId)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.ForumModerators",
                c => new
                    {
                        ForumId = c.Long(nullable: false),
                        ModeratorId = c.Long(nullable: false),
                        Permissions = c.Int(nullable: false),
                        ApplyChildren = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ForumId, t.ModeratorId })
                .ForeignKey("dbo.Forums", t => t.ForumId)
                .ForeignKey("dbo.Users", t => t.ModeratorId)
                .Index(t => t.ForumId)
                .Index(t => t.ModeratorId);
            
            CreateTable(
                "dbo.ForumPosts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Body = c.String(),
                        LastModifyReason = c.String(),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        Status = c.Int(nullable: false),
                        ReplyId = c.Long(),
                        TopicId = c.Long(nullable: false),
                        ForumId = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForumPosts", t => t.ReplyId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Forums", t => t.ForumId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .ForeignKey("dbo.ForumTopics", t => t.TopicId)
                .Index(t => t.ReplyId)
                .Index(t => t.TopicId)
                .Index(t => t.ForumId)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.ForumTopicTrackers",
                c => new
                    {
                        TopicId = c.Long(nullable: false),
                        TrackerId = c.Long(nullable: false),
                        LastVisitedOn = c.DateTime(nullable: false),
                        ForumId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.TopicId, t.TrackerId })
                .ForeignKey("dbo.Forums", t => t.ForumId, cascadeDelete: true)
                .ForeignKey("dbo.ForumTopics", t => t.TopicId)
                .ForeignKey("dbo.Users", t => t.TopicId)
                .Index(t => t.TopicId)
                .Index(t => t.ForumId);
            
            CreateTable(
                "dbo.ForumTrackers",
                c => new
                    {
                        TrackerId = c.Long(nullable: false),
                        ForumId = c.Long(nullable: false),
                        LastMarkedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrackerId, t.ForumId })
                .ForeignKey("dbo.Forums", t => t.ForumId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.TrackerId)
                .Index(t => t.TrackerId)
                .Index(t => t.ForumId);
            
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ExpireOn = c.DateTime(),
                        IsMultiSelect = c.Boolean(nullable: false),
                        VotesCount = c.Long(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        Body = c.String(),
                        Title = c.String(),
                        SlugUrl = c.String(),
                        MetaTitle = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        FocusKeyword = c.String(),
                        UseCanonicalUrl = c.Boolean(nullable: false),
                        CanonicalUrl = c.String(),
                        UseNoFollow = c.Boolean(nullable: false),
                        UseNoIndex = c.Boolean(nullable: false),
                        IsInSitemap = c.Boolean(nullable: false),
                        AllowComments = c.Boolean(nullable: false),
                        AllowCommentForAnonymous = c.Boolean(nullable: false),
                        ViewCountByRss = c.Long(nullable: false),
                        ViewCount = c.Long(nullable: false),
                        ApprovedCommentsCount = c.Int(nullable: false),
                        UnApprovedCommentsCount = c.Int(nullable: false),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        ShowWithRss = c.Boolean(nullable: false),
                        DaysCountForSupportComment = c.Int(nullable: false),
                        SocialSnippetIconName = c.String(),
                        SocialSnippetTitle = c.String(),
                        SocialSnippetDescription = c.String(),
                        TagNames = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.PollComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReplyId = c.Long(),
                        PollId = c.Long(nullable: false),
                        CreatorDisplayName = c.String(),
                        Body = c.String(),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        SiteUrl = c.String(),
                        Email = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(),
                        CreatedById = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PollComments", t => t.ReplyId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .ForeignKey("dbo.Polls", t => t.PollId)
                .Index(t => t.ReplyId)
                .Index(t => t.PollId)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.PollOptions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        VotesCount = c.Long(nullable: false),
                        Description = c.String(),
                        PollId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: true)
                .Index(t => t.PollId);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        Subject = c.String(),
                        SentOn = c.DateTime(nullable: false),
                        DeletedBySender = c.Boolean(nullable: false),
                        DeletedByReceiver = c.Boolean(nullable: false),
                        UnReadSenderMessagesCount = c.Int(nullable: false),
                        UnReadReceiverMessagesCount = c.Int(nullable: false),
                        MessagesCount = c.Int(nullable: false),
                        SenderId = c.Long(nullable: false),
                        ReceiverId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ReceiverId)
                .ForeignKey("dbo.Users", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.ConversationReplies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        Body = c.String(),
                        SentOn = c.DateTime(nullable: false),
                        ParentId = c.Guid(),
                        SenderId = c.Long(nullable: false),
                        ConversationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConversationReplies", t => t.ParentId)
                .ForeignKey("dbo.Conversations", t => t.ConversationId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.SenderId)
                .Index(t => t.ParentId)
                .Index(t => t.SenderId)
                .Index(t => t.ConversationId);
            
            CreateTable(
                "dbo.BlogDrafts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Body = c.String(),
                        Title = c.String(nullable: false, maxLength: 255),
                        TagNames = c.String(),
                        IsReadyForPublish = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        Agent = c.String(),
                        Ip = c.String(),
                        ReadyForPublishOn = c.DateTime(),
                        OwnerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Action = c.Int(nullable: false),
                        Description = c.String(),
                        OperatedOn = c.DateTime(nullable: false),
                        Entity = c.String(),
                        OldValue = c.String(),
                        NewValue = c.String(),
                        EntityId = c.String(),
                        Agent = c.String(),
                        OperantIp = c.String(),
                        OperantId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OperantId)
                .Index(t => t.OperantId);
            
            CreateTable(
                "dbo.NewsComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ReplyId = c.Long(),
                        NewsItemId = c.Long(nullable: false),
                        CreatorDisplayName = c.String(),
                        Body = c.String(),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        SiteUrl = c.String(),
                        Email = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(),
                        CreatedById = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsComments", t => t.ReplyId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .ForeignKey("dbo.NewsItems", t => t.NewsItemId, cascadeDelete: true)
                .Index(t => t.ReplyId)
                .Index(t => t.NewsItemId)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.NewsItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ShowOnSideBar = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        Body = c.String(),
                        Title = c.String(),
                        SlugUrl = c.String(),
                        MetaTitle = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        FocusKeyword = c.String(),
                        UseCanonicalUrl = c.Boolean(nullable: false),
                        CanonicalUrl = c.String(),
                        UseNoFollow = c.Boolean(nullable: false),
                        UseNoIndex = c.Boolean(nullable: false),
                        IsInSitemap = c.Boolean(nullable: false),
                        AllowComments = c.Boolean(nullable: false),
                        AllowCommentForAnonymous = c.Boolean(nullable: false),
                        ViewCountByRss = c.Long(nullable: false),
                        ViewCount = c.Long(nullable: false),
                        ApprovedCommentsCount = c.Int(nullable: false),
                        UnApprovedCommentsCount = c.Int(nullable: false),
                        Rating_TotalRating = c.Double(),
                        Rating_RatersCount = c.Long(),
                        Rating_AverageRating = c.Double(),
                        ShowWithRss = c.Boolean(nullable: false),
                        DaysCountForSupportComment = c.Int(nullable: false),
                        SocialSnippetIconName = c.String(),
                        SocialSnippetTitle = c.String(),
                        SocialSnippetDescription = c.String(),
                        TagNames = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Observations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LastObservedOn = c.DateTime(nullable: false),
                        SectionId = c.String(),
                        Section = c.String(),
                        ObserverId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ObserverId, cascadeDelete: true)
                .Index(t => t.ObserverId);
            
            CreateTable(
                "dbo.UserRatings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RatingValue = c.Double(nullable: false),
                        SectionId = c.String(),
                        Section = c.String(),
                        RaterId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.RaterId)
                .Index(t => t.RaterId);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Reason = c.String(),
                        Section = c.String(),
                        SectionId = c.String(),
                        ReportedOn = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        ReporterId = c.Long(nullable: false),
                        ReasonTypeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReportReasons", t => t.ReasonTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ReporterId)
                .Index(t => t.ReporterId)
                .Index(t => t.ReasonTypeId);
            
            CreateTable(
                "dbo.ReportReasons",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Body = c.String(),
                        Title = c.String(),
                        SlugUrl = c.String(),
                        MetaTitle = c.String(),
                        MetaKeywords = c.String(),
                        MetaDescription = c.String(),
                        FocusKeyword = c.String(),
                        UseCanonicalUrl = c.Boolean(nullable: false),
                        CanonicalUrl = c.String(),
                        UseNoFollow = c.Boolean(nullable: false),
                        UseNoIndex = c.Boolean(nullable: false),
                        IsInSitemap = c.Boolean(nullable: false),
                        SocialSnippetTitle = c.String(),
                        SocialSnippetDescription = c.String(),
                        Section = c.Int(nullable: false),
                        IsCategory = c.Boolean(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        ParentId = c.Long(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pages", t => t.ParentId)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ParentId)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.BannedDomains",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.BannedWords",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BadWord = c.String(),
                        GoodWord = c.String(),
                        IsStopWord = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatorIp = c.String(),
                        ModifierIp = c.String(),
                        ModifyLocked = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ModifierAgent = c.String(),
                        CreatorAgent = c.String(),
                        ReportedOn = c.DateTime(),
                        ReportsCount = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        ModifiedById = c.Long(nullable: false),
                        CreatedById = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Type = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => new { t.Name, t.Type });
            
            CreateTable(
                "dbo.BlogPostContributor",
                c => new
                    {
                        BlogPostId = c.Long(nullable: false),
                        ContributorId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogPostId, t.ContributorId })
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ContributorId, cascadeDelete: true)
                .Index(t => t.BlogPostId)
                .Index(t => t.ContributorId);
            
            CreateTable(
                "dbo.BlogPostTags",
                c => new
                    {
                        BlogPost_Id = c.Long(nullable: false),
                        Tag_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlogPost_Id, t.Tag_Id })
                .ForeignKey("dbo.BlogPosts", t => t.BlogPost_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.BlogPost_Id)
                .Index(t => t.Tag_Id);
            
            CreateTable(
                "dbo.CollectionTags",
                c => new
                    {
                        Collection_Id = c.Guid(nullable: false),
                        Tag_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Collection_Id, t.Tag_Id })
                .ForeignKey("dbo.Collections", t => t.Collection_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Collection_Id)
                .Index(t => t.Tag_Id);
            
            CreateTable(
                "dbo.ForumSubscriptions",
                c => new
                    {
                        SubscriberId = c.Long(nullable: false),
                        ForumId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubscriberId, t.ForumId })
                .ForeignKey("dbo.Forums", t => t.SubscriberId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ForumId, cascadeDelete: true)
                .Index(t => t.SubscriberId)
                .Index(t => t.ForumId);
            
            CreateTable(
                "dbo.ForumTopicSubscription",
                c => new
                    {
                        SubscriberId = c.Long(nullable: false),
                        ForumTopicId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubscriberId, t.ForumTopicId })
                .ForeignKey("dbo.ForumTopics", t => t.SubscriberId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ForumTopicId, cascadeDelete: true)
                .Index(t => t.SubscriberId)
                .Index(t => t.ForumTopicId);
            
            CreateTable(
                "dbo.ForumTopicTags",
                c => new
                    {
                        ForumTopic_Id = c.Long(nullable: false),
                        Tag_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ForumTopic_Id, t.Tag_Id })
                .ForeignKey("dbo.ForumTopics", t => t.ForumTopic_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.ForumTopic_Id)
                .Index(t => t.Tag_Id);
            
            CreateTable(
                "dbo.PollTag",
                c => new
                    {
                        TagId = c.Long(nullable: false),
                        PollId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.PollId })
                .ForeignKey("dbo.Polls", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.PollId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.PollId);
            
            CreateTable(
                "dbo.PollVoter",
                c => new
                    {
                        VoterId = c.Long(nullable: false),
                        PollId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.VoterId, t.PollId })
                .ForeignKey("dbo.Polls", t => t.VoterId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PollId, cascadeDelete: true)
                .Index(t => t.VoterId)
                .Index(t => t.PollId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BannedWords", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.BannedWords", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.BannedDomains", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.BannedDomains", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Pages", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.Pages", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Pages", "ParentId", "dbo.Pages");
            DropForeignKey("dbo.ForumTopicTrackers", "TopicId", "dbo.Users");
            DropForeignKey("dbo.ForumTrackers", "TrackerId", "dbo.Users");
            DropForeignKey("dbo.ConversationReplies", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Conversations", "SenderId", "dbo.Users");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.Reports", "ReporterId", "dbo.Users");
            DropForeignKey("dbo.Reports", "ReasonTypeId", "dbo.ReportReasons");
            DropForeignKey("dbo.ReportReasons", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.ReportReasons", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Conversations", "ReceiverId", "dbo.Users");
            DropForeignKey("dbo.UserRatings", "RaterId", "dbo.Users");
            DropForeignKey("dbo.Observations", "ObserverId", "dbo.Users");
            DropForeignKey("dbo.Tags", "NewsItem_Id", "dbo.NewsItems");
            DropForeignKey("dbo.NewsItems", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.NewsItems", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.NewsComments", "NewsItemId", "dbo.NewsItems");
            DropForeignKey("dbo.NewsComments", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.NewsComments", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.NewsComments", "ReplyId", "dbo.NewsComments");
            DropForeignKey("dbo.ForumModerators", "ModeratorId", "dbo.Users");
            DropForeignKey("dbo.AuditLogs", "OperantId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.CollectionPosts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogDrafts", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Attachments", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Attachments", "ConversationId", "dbo.Conversations");
            DropForeignKey("dbo.ConversationReplies", "ConversationId", "dbo.Conversations");
            DropForeignKey("dbo.ConversationReplies", "ParentId", "dbo.ConversationReplies");
            DropForeignKey("dbo.AnnouncementComments", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.AnnouncementComments", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.AnnouncementComments", "ReplyId", "dbo.AnnouncementComments");
            DropForeignKey("dbo.Tags", "Announcement_Id", "dbo.Announcements");
            DropForeignKey("dbo.PollVoter", "PollId", "dbo.Users");
            DropForeignKey("dbo.PollVoter", "VoterId", "dbo.Polls");
            DropForeignKey("dbo.PollTag", "PollId", "dbo.Tags");
            DropForeignKey("dbo.PollTag", "TagId", "dbo.Polls");
            DropForeignKey("dbo.PollOptions", "PollId", "dbo.Polls");
            DropForeignKey("dbo.Polls", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.Polls", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.PollComments", "PollId", "dbo.Polls");
            DropForeignKey("dbo.PollComments", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.PollComments", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.PollComments", "ReplyId", "dbo.PollComments");
            DropForeignKey("dbo.Tags", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.ForumTopicTrackers", "TopicId", "dbo.ForumTopics");
            DropForeignKey("dbo.ForumTopicTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.ForumTopicTags", "ForumTopic_Id", "dbo.ForumTopics");
            DropForeignKey("dbo.ForumTopicSubscription", "ForumTopicId", "dbo.Users");
            DropForeignKey("dbo.ForumTopicSubscription", "SubscriberId", "dbo.ForumTopics");
            DropForeignKey("dbo.ForumPosts", "TopicId", "dbo.ForumTopics");
            DropForeignKey("dbo.ForumTopics", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.ForumTrackers", "ForumId", "dbo.Forums");
            DropForeignKey("dbo.ForumTopicTrackers", "ForumId", "dbo.Forums");
            DropForeignKey("dbo.ForumTopics", "ForumId", "dbo.Forums");
            DropForeignKey("dbo.ForumSubscriptions", "ForumId", "dbo.Users");
            DropForeignKey("dbo.ForumSubscriptions", "SubscriberId", "dbo.Forums");
            DropForeignKey("dbo.ForumPosts", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.ForumPosts", "ForumId", "dbo.Forums");
            DropForeignKey("dbo.ForumPosts", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ForumPosts", "ReplyId", "dbo.ForumPosts");
            DropForeignKey("dbo.Forums", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.ForumModerators", "ForumId", "dbo.Forums");
            DropForeignKey("dbo.Forums", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Forums", "ParentId", "dbo.Forums");
            DropForeignKey("dbo.ForumAnnouncements", "ForumId", "dbo.Forums");
            DropForeignKey("dbo.ForumAnnouncements", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.ForumAnnouncements", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ForumTopics", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Tags", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.CollectionTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.CollectionTags", "Collection_Id", "dbo.Collections");
            DropForeignKey("dbo.CollectionPosts", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.CollectionPosts", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.CollectionComments", "PostId", "dbo.CollectionPosts");
            DropForeignKey("dbo.CollectionComments", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.CollectionComments", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.CollectionComments", "ReplyId", "dbo.CollectionComments");
            DropForeignKey("dbo.CollectionPosts", "CollectionId", "dbo.Collections");
            DropForeignKey("dbo.Collections", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.Users", "Collection_Id", "dbo.Collections");
            DropForeignKey("dbo.Collections", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Attachments", "CollectionId", "dbo.Collections");
            DropForeignKey("dbo.BlogPostTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.BlogPostTags", "BlogPost_Id", "dbo.BlogPosts");
            DropForeignKey("dbo.BlogPosts", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.LinkBacks", "PostId", "dbo.BlogPosts");
            DropForeignKey("dbo.BlogPosts", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.BlogPostContributor", "ContributorId", "dbo.Users");
            DropForeignKey("dbo.BlogPostContributor", "BlogPostId", "dbo.BlogPosts");
            DropForeignKey("dbo.BlogComments", "PostId", "dbo.BlogPosts");
            DropForeignKey("dbo.BlogComments", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.BlogComments", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.BlogComments", "ReplyId", "dbo.BlogComments");
            DropForeignKey("dbo.Announcements", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.AnnouncementComments", "AnnouncementId", "dbo.Announcements");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropIndex("dbo.PollVoter", new[] { "PollId" });
            DropIndex("dbo.PollVoter", new[] { "VoterId" });
            DropIndex("dbo.PollTag", new[] { "PollId" });
            DropIndex("dbo.PollTag", new[] { "TagId" });
            DropIndex("dbo.ForumTopicTags", new[] { "Tag_Id" });
            DropIndex("dbo.ForumTopicTags", new[] { "ForumTopic_Id" });
            DropIndex("dbo.ForumTopicSubscription", new[] { "ForumTopicId" });
            DropIndex("dbo.ForumTopicSubscription", new[] { "SubscriberId" });
            DropIndex("dbo.ForumSubscriptions", new[] { "ForumId" });
            DropIndex("dbo.ForumSubscriptions", new[] { "SubscriberId" });
            DropIndex("dbo.CollectionTags", new[] { "Tag_Id" });
            DropIndex("dbo.CollectionTags", new[] { "Collection_Id" });
            DropIndex("dbo.BlogPostTags", new[] { "Tag_Id" });
            DropIndex("dbo.BlogPostTags", new[] { "BlogPost_Id" });
            DropIndex("dbo.BlogPostContributor", new[] { "ContributorId" });
            DropIndex("dbo.BlogPostContributor", new[] { "BlogPostId" });
            DropIndex("dbo.BannedWords", new[] { "CreatedById" });
            DropIndex("dbo.BannedWords", new[] { "ModifiedById" });
            DropIndex("dbo.BannedDomains", new[] { "CreatedById" });
            DropIndex("dbo.BannedDomains", new[] { "ModifiedById" });
            DropIndex("dbo.Pages", new[] { "CreatedById" });
            DropIndex("dbo.Pages", new[] { "ModifiedById" });
            DropIndex("dbo.Pages", new[] { "ParentId" });
            DropIndex("dbo.ReportReasons", new[] { "CreatedById" });
            DropIndex("dbo.ReportReasons", new[] { "ModifiedById" });
            DropIndex("dbo.Reports", new[] { "ReasonTypeId" });
            DropIndex("dbo.Reports", new[] { "ReporterId" });
            DropIndex("dbo.UserRatings", new[] { "RaterId" });
            DropIndex("dbo.Observations", new[] { "ObserverId" });
            DropIndex("dbo.NewsItems", new[] { "CreatedById" });
            DropIndex("dbo.NewsItems", new[] { "ModifiedById" });
            DropIndex("dbo.NewsComments", new[] { "CreatedById" });
            DropIndex("dbo.NewsComments", new[] { "ModifiedById" });
            DropIndex("dbo.NewsComments", new[] { "NewsItemId" });
            DropIndex("dbo.NewsComments", new[] { "ReplyId" });
            DropIndex("dbo.AuditLogs", new[] { "OperantId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.BlogDrafts", new[] { "OwnerId" });
            DropIndex("dbo.ConversationReplies", new[] { "ConversationId" });
            DropIndex("dbo.ConversationReplies", new[] { "SenderId" });
            DropIndex("dbo.ConversationReplies", new[] { "ParentId" });
            DropIndex("dbo.Conversations", new[] { "ReceiverId" });
            DropIndex("dbo.Conversations", new[] { "SenderId" });
            DropIndex("dbo.PollOptions", new[] { "PollId" });
            DropIndex("dbo.PollComments", new[] { "CreatedById" });
            DropIndex("dbo.PollComments", new[] { "ModifiedById" });
            DropIndex("dbo.PollComments", new[] { "PollId" });
            DropIndex("dbo.PollComments", new[] { "ReplyId" });
            DropIndex("dbo.Polls", new[] { "CreatedById" });
            DropIndex("dbo.Polls", new[] { "ModifiedById" });
            DropIndex("dbo.ForumTrackers", new[] { "ForumId" });
            DropIndex("dbo.ForumTrackers", new[] { "TrackerId" });
            DropIndex("dbo.ForumTopicTrackers", new[] { "ForumId" });
            DropIndex("dbo.ForumTopicTrackers", new[] { "TopicId" });
            DropIndex("dbo.ForumPosts", new[] { "CreatedById" });
            DropIndex("dbo.ForumPosts", new[] { "ModifiedById" });
            DropIndex("dbo.ForumPosts", new[] { "ForumId" });
            DropIndex("dbo.ForumPosts", new[] { "TopicId" });
            DropIndex("dbo.ForumPosts", new[] { "ReplyId" });
            DropIndex("dbo.ForumModerators", new[] { "ModeratorId" });
            DropIndex("dbo.ForumModerators", new[] { "ForumId" });
            DropIndex("dbo.ForumAnnouncements", new[] { "CreatedById" });
            DropIndex("dbo.ForumAnnouncements", new[] { "ModifiedById" });
            DropIndex("dbo.ForumAnnouncements", new[] { "ForumId" });
            DropIndex("dbo.Forums", new[] { "CreatedById" });
            DropIndex("dbo.Forums", new[] { "ModifiedById" });
            DropIndex("dbo.Forums", new[] { "ParentId" });
            DropIndex("dbo.ForumTopics", new[] { "CreatedById" });
            DropIndex("dbo.ForumTopics", new[] { "ModifiedById" });
            DropIndex("dbo.ForumTopics", new[] { "ForumId" });
            DropIndex("dbo.CollectionComments", new[] { "CreatedById" });
            DropIndex("dbo.CollectionComments", new[] { "ModifiedById" });
            DropIndex("dbo.CollectionComments", new[] { "ReplyId" });
            DropIndex("dbo.CollectionComments", new[] { "PostId" });
            DropIndex("dbo.CollectionPosts", new[] { "User_Id" });
            DropIndex("dbo.CollectionPosts", new[] { "CreatedById" });
            DropIndex("dbo.CollectionPosts", new[] { "ModifiedById" });
            DropIndex("dbo.CollectionPosts", new[] { "CollectionId" });
            DropIndex("dbo.Attachments", new[] { "ConversationId" });
            DropIndex("dbo.Attachments", new[] { "CollectionId" });
            DropIndex("dbo.Attachments", new[] { "OwnerId" });
            DropIndex("dbo.Collections", new[] { "CreatedById" });
            DropIndex("dbo.Collections", new[] { "ModifiedById" });
            DropIndex("dbo.LinkBacks", new[] { "PostId" });
            DropIndex("dbo.BlogComments", new[] { "CreatedById" });
            DropIndex("dbo.BlogComments", new[] { "ModifiedById" });
            DropIndex("dbo.BlogComments", new[] { "PostId" });
            DropIndex("dbo.BlogComments", new[] { "ReplyId" });
            DropIndex("dbo.BlogPosts", new[] { "CreatedById" });
            DropIndex("dbo.BlogPosts", new[] { "ModifiedById" });
            DropIndex("dbo.Tags", new[] { "NewsItem_Id" });
            DropIndex("dbo.Tags", new[] { "Announcement_Id" });
            DropIndex("dbo.Tags", new[] { "CreatedById" });
            DropIndex("dbo.Tags", new[] { "ModifiedById" });
            DropIndex("dbo.Announcements", new[] { "CreatedById" });
            DropIndex("dbo.AnnouncementComments", new[] { "CreatedById" });
            DropIndex("dbo.AnnouncementComments", new[] { "ModifiedById" });
            DropIndex("dbo.AnnouncementComments", new[] { "AnnouncementId" });
            DropIndex("dbo.AnnouncementComments", new[] { "ReplyId" });
            DropIndex("dbo.Users", new[] { "Collection_Id" });
            DropIndex("dbo.Users", "IX_UniqueUserName");
            DropIndex("dbo.Users", "IX_UniqueEmail");
            DropIndex("dbo.Users", "IX_UniqueNameForShow");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Roles", "IX_UniqueRoleName");
            DropTable("dbo.PollVoter");
            DropTable("dbo.PollTag");
            DropTable("dbo.ForumTopicTags");
            DropTable("dbo.ForumTopicSubscription");
            DropTable("dbo.ForumSubscriptions");
            DropTable("dbo.CollectionTags");
            DropTable("dbo.BlogPostTags");
            DropTable("dbo.BlogPostContributor");
            DropTable("dbo.Settings");
            DropTable("dbo.BannedWords");
            DropTable("dbo.BannedDomains");
            DropTable("dbo.Pages");
            DropTable("dbo.ReportReasons");
            DropTable("dbo.Reports");
            DropTable("dbo.UserRatings");
            DropTable("dbo.Observations");
            DropTable("dbo.NewsItems");
            DropTable("dbo.NewsComments");
            DropTable("dbo.AuditLogs");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.BlogDrafts");
            DropTable("dbo.ConversationReplies");
            DropTable("dbo.Conversations");
            DropTable("dbo.PollOptions");
            DropTable("dbo.PollComments");
            DropTable("dbo.Polls");
            DropTable("dbo.ForumTrackers");
            DropTable("dbo.ForumTopicTrackers");
            DropTable("dbo.ForumPosts");
            DropTable("dbo.ForumModerators");
            DropTable("dbo.ForumAnnouncements");
            DropTable("dbo.Forums");
            DropTable("dbo.ForumTopics");
            DropTable("dbo.CollectionComments");
            DropTable("dbo.CollectionPosts");
            DropTable("dbo.Attachments");
            DropTable("dbo.Collections");
            DropTable("dbo.LinkBacks");
            DropTable("dbo.BlogComments");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.Tags");
            DropTable("dbo.Announcements");
            DropTable("dbo.AnnouncementComments");
            DropTable("dbo.Users");
            DropTable("dbo.UserRole");
            DropTable("dbo.Roles");
        }
    }
}
