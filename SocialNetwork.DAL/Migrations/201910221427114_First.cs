namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdCategory = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.IdCategory);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        IdComment = c.Int(nullable: false, identity: true),
                        CommentText = c.String(),
                        IdPost = c.Int(),
                        IdUser = c.Int(),
                        CommentDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.IdComment);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        IdCountry = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.IdCountry);
            
            CreateTable(
                "dbo.PostLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPost = c.Int(),
                        IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        IdPost = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PostContent = c.String(),
                        TypePublic = c.Boolean(),
                        IdCategory = c.Int(),
                        PostDate = c.DateTime(),
                        PostImage = c.Binary(),
                        IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdPost);
            
            CreateTable(
                "dbo.UserFollowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser1 = c.Int(),
                        IdUser2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateBirth = c.DateTime(),
                        Email = c.String(),
                        IdCountry = c.Int(),
                        Gender = c.String(),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        UserImage = c.Binary(),
                        FirstLogin = c.Int(),
                        NotificationEmails = c.Boolean(),
                        NotificationPostLikers = c.Boolean(),
                        NotificationPostComments = c.Boolean(),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.IdUser)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.UserFollowers");
            DropTable("dbo.Posts");
            DropTable("dbo.PostLikes");
            DropTable("dbo.Countries");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
