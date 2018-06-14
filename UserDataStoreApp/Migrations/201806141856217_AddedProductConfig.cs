namespace UserDataStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductConfig : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "Owner_UserId" });
            DropColumn("dbo.Products", "OwnerId");
            RenameColumn(table: "dbo.Products", name: "Owner_UserId", newName: "OwnerId");
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "OwnerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "OwnerId" });
            AlterColumn("dbo.Products", "OwnerId", c => c.Int());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            RenameColumn(table: "dbo.Products", name: "OwnerId", newName: "Owner_UserId");
            AddColumn("dbo.Products", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Owner_UserId");
        }
    }
}
