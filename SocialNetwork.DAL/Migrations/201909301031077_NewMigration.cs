namespace SocialNetwork.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "TextMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "TextMessage");
        }
    }
}
