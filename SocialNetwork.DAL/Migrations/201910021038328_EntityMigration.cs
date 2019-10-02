namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationshipId = c.Int(nullable: false),
                        From = c.String(),
                        To = c.String(),
                        SendTime = c.DateTime(nullable: false),
                        TextMessage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Relationship",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.UserId, t.FriendId });
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LastName = c.String(nullable: false, maxLength: 150),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        RegisteredDate = c.DateTime(nullable: false, storeType: "date"),
                        MiddleName = c.String(maxLength: 150),
                        Photo = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => new { t.Id, t.LastName, t.FirstName, t.BirthDate, t.RegisteredDate });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Relationship");
            DropTable("dbo.Message");
        }
    }
}
