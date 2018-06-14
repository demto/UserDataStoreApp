namespace UserDataStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOwnerIdDbName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Products", name: "OwnerId", newName: "OwnerUserId");
            RenameIndex(table: "dbo.Products", name: "IX_OwnerId", newName: "IX_OwnerUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Products", name: "IX_OwnerUserId", newName: "IX_OwnerId");
            RenameColumn(table: "dbo.Products", name: "OwnerUserId", newName: "OwnerId");
        }
    }
}
