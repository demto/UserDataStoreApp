namespace UserDataStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableOwnerId2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "OwnerUserId" });
            AlterColumn("dbo.Products", "OwnerUserId", c => c.Int());
            CreateIndex("dbo.Products", "OwnerUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "OwnerUserId" });
            AlterColumn("dbo.Products", "OwnerUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "OwnerUserId");
        }
    }
}
