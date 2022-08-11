namespace AjmdsControloPresenca.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRestricao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Turno", "Descricao", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Turno", "Descricao", c => c.String(maxLength: 50));
        }
    }
}
