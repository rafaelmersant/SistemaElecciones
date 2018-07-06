namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCandidacyModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidacies", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidacies", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.Candidacies", "CategoryId");
            AddForeignKey("dbo.Candidacies", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Candidacies", "Category");
            DropColumn("dbo.Rounds", "RefNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rounds", "RefNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Candidacies", "Category", c => c.Int(nullable: false));
            DropForeignKey("dbo.Candidacies", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Candidacies", new[] { "CategoryId" });
            AlterColumn("dbo.Candidacies", "Description", c => c.String());
            DropColumn("dbo.Candidacies", "CategoryId");
        }
    }
}
