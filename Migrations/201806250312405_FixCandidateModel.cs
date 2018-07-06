namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCandidateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "CandidacyId", c => c.Byte(nullable: false));
            AddColumn("dbo.Candidates", "photoUrl", c => c.String(nullable: false));
            AlterColumn("dbo.Candidates", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Candidates", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidates", "ImageUrl", c => c.String());
            AlterColumn("dbo.Candidates", "Name", c => c.String());
            DropColumn("dbo.Candidates", "photoUrl");
            DropColumn("dbo.Candidates", "CandidacyId");
        }
    }
}
