namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCandidacyToRoundModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rounds", "CandidacyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rounds", "CandidacyId");
            AddForeignKey("dbo.Rounds", "CandidacyId", "dbo.Candidacies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rounds", "CandidacyId", "dbo.Candidacies");
            DropIndex("dbo.Rounds", new[] { "CandidacyId" });
            DropColumn("dbo.Rounds", "CandidacyId");
        }
    }
}
