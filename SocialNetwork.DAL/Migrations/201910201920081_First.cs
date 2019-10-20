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
                        CommentDate = c.DateTime(nullable: false),
                        IdPost_IdPost = c.Int(),
                        IdUser_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdComment)
                .ForeignKey("dbo.Posts", t => t.IdPost_IdPost)
                .ForeignKey("dbo.Users", t => t.IdUser_IdUser)
                .Index(t => t.IdPost_IdPost)
                .Index(t => t.IdUser_IdUser);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        IdPost = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PostContent = c.String(),
                        TypePublic = c.Boolean(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        PostImage = c.Binary(),
                        IdCategory_IdCategory = c.Int(),
                        IdUser_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.IdPost)
                .ForeignKey("dbo.Categories", t => t.IdCategory_IdCategory)
                .ForeignKey("dbo.Users", t => t.IdUser_IdUser)
                .Index(t => t.IdCategory_IdCategory)
                .Index(t => t.IdUser_IdUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateBirth = c.DateTime(),
                        Email = c.String(),
                        Gender = c.String(),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        UserImage = c.Binary(),
                        FirstLogin = c.Int(),
                        NotificationEmails = c.Boolean(),
                        NotificationPostLikers = c.Boolean(),
                        NotificationPostComments = c.Boolean(),
                        IdCountry_IdCountry = c.Int(),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.IdUser)
                .ForeignKey("dbo.Countries", t => t.IdCountry_IdCountry)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.IdCountry_IdCountry)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        IdCountry = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.IdCountry);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.PostLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPost_IdPost = c.Int(),
                        IdUser_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.IdPost_IdPost)
                .ForeignKey("dbo.Users", t => t.IdUser_IdUser)
                .Index(t => t.IdPost_IdPost)
                .Index(t => t.IdUser_IdUser);
            
            CreateTable(
                "dbo.UserFollowers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser1_IdUser = c.Int(),
                        IdUser2_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser1_IdUser)
                .ForeignKey("dbo.Users", t => t.IdUser2_IdUser)
                .Index(t => t.IdUser1_IdUser)
                .Index(t => t.IdUser2_IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFollowers", "IdUser2_IdUser", "dbo.Users");
            DropForeignKey("dbo.UserFollowers", "IdUser1_IdUser", "dbo.Users");
            DropForeignKey("dbo.PostLikes", "IdUser_IdUser", "dbo.Users");
            DropForeignKey("dbo.PostLikes", "IdPost_IdPost", "dbo.Posts");
            DropForeignKey("dbo.Comments", "IdUser_IdUser", "dbo.Users");
            DropForeignKey("dbo.Comments", "IdPost_IdPost", "dbo.Posts");
            DropForeignKey("dbo.Posts", "IdUser_IdUser", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "IdCountry_IdCountry", "dbo.Countries");
            DropForeignKey("dbo.Posts", "IdCategory_IdCategory", "dbo.Categories");
            DropIndex("dbo.UserFollowers", new[] { "IdUser2_IdUser" });
            DropIndex("dbo.UserFollowers", new[] { "IdUser1_IdUser" });
            DropIndex("dbo.PostLikes", new[] { "IdUser_IdUser" });
            DropIndex("dbo.PostLikes", new[] { "IdPost_IdPost" });
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            DropIndex("dbo.Users", new[] { "IdCountry_IdCountry" });
            DropIndex("dbo.Posts", new[] { "IdUser_IdUser" });
            DropIndex("dbo.Posts", new[] { "IdCategory_IdCategory" });
            DropIndex("dbo.Comments", new[] { "IdUser_IdUser" });
            DropIndex("dbo.Comments", new[] { "IdPost_IdPost" });
            DropTable("dbo.UserFollowers");
            DropTable("dbo.PostLikes");
            DropTable("dbo.Roles");
            DropTable("dbo.Countries");
            DropTable("dbo.Users");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
