namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRoundModelPeriod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rounds", "Period", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rounds", "Period", c => c.Byte(nullable: false));
        }
    }
}
