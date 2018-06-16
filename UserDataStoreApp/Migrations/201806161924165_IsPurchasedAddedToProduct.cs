namespace UserDataStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsPurchasedAddedToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsPurchased", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsPurchased");
        }
    }
}
