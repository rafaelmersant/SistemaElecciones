namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCandidateAndRoundModelsPeriod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "Period", c => c.String(maxLength: 6));
            AlterColumn("dbo.Rounds", "Period", c => c.String(nullable: false, maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rounds", "Period", c => c.Int(nullable: false));
            DropColumn("dbo.Candidates", "Period");
        }
    }
}
