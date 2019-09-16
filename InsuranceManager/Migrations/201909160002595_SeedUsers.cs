namespace InsuranceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6551b613-e46a-47fa-8cda-02ef3edcd906', N'guest@guest.com', 0, N'AEDmzH1agcus65q85D+kmIOw98Imny8o2y0F6lsHuEEmvHLcLn/4bNTESH3Mtsm0RA==', N'e2bd38c5-dd15-4881-9d1a-8a9fa91ac95a', NULL, 0, 0, NULL, 1, 0, N'guest@guest.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd48a8902-0346-45fc-9ec6-87dc84c24837', N'admin@admin.com', 0, N'ALHng6zS3dR0kz9bLuQ+iTM1sCAO5InZEQWg+6sGe6RnH0W04iJBVb1rW/h8kVCX+Q==', N'665bac3a-5148-45e5-b070-f7a80338d69c', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b712d6b3-8cc2-4db7-8191-ce08f4d20bce', N'CanManagePolicies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd48a8902-0346-45fc-9ec6-87dc84c24837', N'b712d6b3-8cc2-4db7-8191-ce08f4d20bce')

");
        }
        
        public override void Down()
        {
        }
    }
}
