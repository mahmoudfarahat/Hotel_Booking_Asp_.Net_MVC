namespace HotelBooking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2d451dae-7c62-4dbd-bfbd-6347d6a77c2a', N'admin@admin.com', 0, N'AIdZ7Iyy4MOZuLwigBkErlC8Cd0UNbkEq5CCYrDNI4CWA+CarbNJQiuxPnMId+YKYQ==', N'7a8bd314-fb22-4a0d-8f81-fecd1cf46fce', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'383d85dc-0518-4cb5-b69a-9c89b0e6d541', N'AdminRole')
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2d451dae-7c62-4dbd-bfbd-6347d6a77c2a', N'383d85dc-0518-4cb5-b69a-9c89b0e6d541')

"

);
        }
        
        public override void Down()
        {
        }
    }
}
