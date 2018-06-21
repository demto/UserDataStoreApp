namespace UserDataStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTraceMessageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TraceMessages",
                c => new
                    {
                        TraceMessageId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        MessageText = c.String(),
                        Severity = c.Int(nullable: false),
                        UtcDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TraceMessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TraceMessages");
        }
    }
}
