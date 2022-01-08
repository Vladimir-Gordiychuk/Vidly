namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'41828e75-b10e-413b-8f7c-6cdea2e7d006', N'admin@vidly.com', 0, N'AHhEd3gxGc7/3I9hUvdVIxAZ1cVTastzX2wlYAm2F7VDS+xMs0/Agl9bQcVgwOHqXQ==', N'b243fca7-7a93-4858-ad38-f4c4ef7c9bad', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab125fda-d147-4e98-8007-d289eea70d07', N'guest@vidly.com', 0, N'AIhrClc2jENkG9nmTegTaBFg8M2mrms69qSPWY9+BRCgm/oVEusRSPGDmA/8QKfCHQ==', N'b04c16d6-99fc-4879-87c5-28d31bfcfd2a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0a7b3473-61fe-41c5-8b65-167c9df1059b', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'41828e75-b10e-413b-8f7c-6cdea2e7d006', N'0a7b3473-61fe-41c5-8b65-167c9df1059b')

                ");
        }
        
        public override void Down()
        {
            Sql(@"
                DELETE FROM [dbo].[AspNetUserRoles] WHERE [UserId] = '41828e75-b10e-413b-8f7c-6cdea2e7d006';

                DELETE FROM [dbo].[AspNetRoles] WHERE [Name] = 'CanManageMovies';

                DELETE FROM [dbo].[AspNetUsers] WHERE Email = 'admin@vidly.com';
                DELETE FROM [dbo].[AspNetUsers] WHERE Email = 'guest@vidly.com';
                ");

        }
    }
}
