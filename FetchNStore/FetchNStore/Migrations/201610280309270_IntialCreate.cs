namespace FetchNStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.URLs",
                c => new
                    {
                        URLId = c.Int(nullable: false, identity: true),
                        URL_Address = c.String(),
                        Status_Code = c.Int(nullable: false),
                        Response_Time = c.Int(nullable: false),
                        Method = c.String(),
                        Request_Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.URLId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.URLs");
        }
    }
}
