namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRoundModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rounds", "CategoryId", c => c.Byte(nullable: false));
            AddColumn("dbo.Rounds", "Closed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rounds", "Category_Id", c => c.Int());
            CreateIndex("dbo.Rounds", "Category_Id");
            AddForeignKey("dbo.Rounds", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Rounds", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rounds", "Category", c => c.String());
            DropForeignKey("dbo.Rounds", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Rounds", new[] { "Category_Id" });
            DropColumn("dbo.Rounds", "Category_Id");
            DropColumn("dbo.Rounds", "Closed");
            DropColumn("dbo.Rounds", "CategoryId");
        }
    }
}
