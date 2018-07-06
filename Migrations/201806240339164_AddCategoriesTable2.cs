namespace SistemaElecciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesTable2 : DbMigration
    {
        public override void Up()
        {
            //AlterTable(
            //    "dbo.Categories",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        Description = c.String(nullable: false, maxLength: 50),
            //    })
            //    .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            
            
        }
    }
}
