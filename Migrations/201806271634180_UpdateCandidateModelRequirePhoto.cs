namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCandidateModelRequirePhoto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Candidates", "photoUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Candidates", "photoUrl", c => c.String());
        }
    }
}
