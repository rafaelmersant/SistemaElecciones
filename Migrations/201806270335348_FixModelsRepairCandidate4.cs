namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModelsRepairCandidate4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidates", "Candidacy_Id", "dbo.Candidacies");
            DropIndex("dbo.Candidates", new[] { "Candidacy_Id" });
            DropColumn("dbo.Candidates", "CandidacyId");
            RenameColumn(table: "dbo.Candidates", name: "Candidacy_Id", newName: "CandidacyId");
            AlterColumn("dbo.Candidates", "CandidacyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidates", "CandidacyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Candidates", "CandidacyId");
            AddForeignKey("dbo.Candidates", "CandidacyId", "dbo.Candidacies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "CandidacyId", "dbo.Candidacies");
            DropIndex("dbo.Candidates", new[] { "CandidacyId" });
            AlterColumn("dbo.Candidates", "CandidacyId", c => c.Int());
            AlterColumn("dbo.Candidates", "CandidacyId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Candidates", name: "CandidacyId", newName: "Candidacy_Id");
            AddColumn("dbo.Candidates", "CandidacyId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Candidates", "Candidacy_Id");
            AddForeignKey("dbo.Candidates", "Candidacy_Id", "dbo.Candidacies", "Id");
        }
    }
}
