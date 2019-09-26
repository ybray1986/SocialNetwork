namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DALMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.UserId, t.FriendId });
            
            CreateTable(
                "dbo.Users",
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
            DropTable("dbo.Users");
            DropTable("dbo.Friends");
        }
    }
}
