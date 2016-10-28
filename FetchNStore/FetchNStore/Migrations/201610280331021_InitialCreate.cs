namespace FetchNStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.URLs", "Request_Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.URLs", "Request_Time", c => c.DateTime(nullable: false));
        }
    }
}
