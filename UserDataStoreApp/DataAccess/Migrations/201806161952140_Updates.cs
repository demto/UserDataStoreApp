namespace UserDataStoreApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "User_UserId", c => c.Int());
            CreateIndex("dbo.Products", "User_UserId");
            AddForeignKey("dbo.Products", "User_UserId", "dbo.Users", "UserId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Products", "User_UserId", "dbo.Users");
            DropIndex("dbo.Products", new[] { "User_UserId" });
            DropColumn("dbo.Products", "User_UserId");
        }
    }
}
