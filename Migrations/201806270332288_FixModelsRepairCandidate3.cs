namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModelsRepairCandidate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "Candidacy_Id", c => c.Int());
            CreateIndex("dbo.Candidates", "Candidacy_Id");
            AddForeignKey("dbo.Candidates", "Candidacy_Id", "dbo.Candidacies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "Candidacy_Id", "dbo.Candidacies");
            DropIndex("dbo.Candidates", new[] { "Candidacy_Id" });
            DropColumn("dbo.Candidates", "Candidacy_Id");
        }
    }
}
