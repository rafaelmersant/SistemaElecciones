namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidacies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageUrl = c.String(),
                        Candidacy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidacies", t => t.Candidacy_Id)
                .Index(t => t.Candidacy_Id);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateId = c.Byte(nullable: false),
                        RefNumber = c.Int(nullable: false),
                        Votes = c.Int(nullable: false),
                        Category = c.String(),
                        Period = c.Byte(nullable: false),
                        Candidate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .Index(t => t.Candidate_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rounds", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.Candidates", "Candidacy_Id", "dbo.Candidacies");
            DropIndex("dbo.Rounds", new[] { "Candidate_Id" });
            DropIndex("dbo.Candidates", new[] { "Candidacy_Id" });
            DropTable("dbo.Rounds");
            DropTable("dbo.Candidates");
            DropTable("dbo.Candidacies");
        }
    }
}
