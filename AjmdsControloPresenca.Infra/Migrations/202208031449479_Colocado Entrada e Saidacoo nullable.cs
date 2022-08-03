namespace AjmdsControloPresenca.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColocadoEntradaeSaidacoonullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Presenca", "Entrada", c => c.DateTime());
            AlterColumn("dbo.Presenca", "Saida", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Presenca", "Saida", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Presenca", "Entrada", c => c.DateTime(nullable: false));
        }
    }
}
