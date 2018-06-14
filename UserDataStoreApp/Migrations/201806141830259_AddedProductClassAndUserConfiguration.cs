namespace UserDataStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductClassAndUserConfiguration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductPrice = c.Double(nullable: false),
                        IsSalesProduct = c.Boolean(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        Owner_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Users", t => t.Owner_UserId)
                .Index(t => t.Owner_UserId);
            
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "NickName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Owner_UserId", "dbo.Users");
            DropIndex("dbo.Products", new[] { "Owner_UserId" });
            AlterColumn("dbo.Users", "NickName", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            DropTable("dbo.Products");
        }
    }
}
