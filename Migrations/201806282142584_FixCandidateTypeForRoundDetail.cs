namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCandidateTypeForRoundDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoundDetails", "Candidate_Id", "dbo.Candidates");
            DropIndex("dbo.RoundDetails", new[] { "Candidate_Id" });
            DropColumn("dbo.RoundDetails", "CandidateId");
            RenameColumn(table: "dbo.RoundDetails", name: "Candidate_Id", newName: "CandidateId");
            AlterColumn("dbo.RoundDetails", "CandidateId", c => c.Int(nullable: false));
            AlterColumn("dbo.RoundDetails", "CandidateId", c => c.Int(nullable: false));
            CreateIndex("dbo.RoundDetails", "CandidateId");
            AddForeignKey("dbo.RoundDetails", "CandidateId", "dbo.Candidates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoundDetails", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.RoundDetails", new[] { "CandidateId" });
            AlterColumn("dbo.RoundDetails", "CandidateId", c => c.Int());
            AlterColumn("dbo.RoundDetails", "CandidateId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.RoundDetails", name: "CandidateId", newName: "Candidate_Id");
            AddColumn("dbo.RoundDetails", "CandidateId", c => c.Byte(nullable: false));
            CreateIndex("dbo.RoundDetails", "Candidate_Id");
            AddForeignKey("dbo.RoundDetails", "Candidate_Id", "dbo.Candidates", "Id");
        }
    }
}
