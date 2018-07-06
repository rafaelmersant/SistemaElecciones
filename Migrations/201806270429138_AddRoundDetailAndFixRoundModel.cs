namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoundDetailAndFixRoundModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rounds", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.Rounds", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Rounds", new[] { "Candidate_Id" });
            DropIndex("dbo.Rounds", new[] { "Category_Id" });
            DropColumn("dbo.Rounds", "CategoryId");
            RenameColumn(table: "dbo.Rounds", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Rounds", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Rounds", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rounds", "CategoryId");
            AddForeignKey("dbo.Rounds", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Rounds", "CandidateId");
            DropColumn("dbo.Rounds", "Votes");
            DropColumn("dbo.Rounds", "Candidate_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rounds", "Candidate_Id", c => c.Int());
            AddColumn("dbo.Rounds", "Votes", c => c.Int(nullable: false));
            AddColumn("dbo.Rounds", "CandidateId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Rounds", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Rounds", new[] { "CategoryId" });
            AlterColumn("dbo.Rounds", "CategoryId", c => c.Int());
            AlterColumn("dbo.Rounds", "CategoryId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Rounds", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.Rounds", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Rounds", "Category_Id");
            CreateIndex("dbo.Rounds", "Candidate_Id");
            AddForeignKey("dbo.Rounds", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Rounds", "Candidate_Id", "dbo.Candidates", "Id");
        }
    }
}
