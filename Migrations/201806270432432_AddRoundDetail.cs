namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoundDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoundDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdHeader = c.Int(nullable: false),
                        CandidateId = c.Byte(nullable: false),
                        Votes = c.Int(nullable: false),
                        Candidate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .ForeignKey("dbo.Rounds", r => r.IdHeader)
                .Index(t => t.Candidate_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoundDetails", "Candidate_Id", "dbo.Candidates");
            DropIndex("dbo.RoundDetails", new[] { "Candidate_Id" });
            DropTable("dbo.RoundDetails");
        }
    }
}
