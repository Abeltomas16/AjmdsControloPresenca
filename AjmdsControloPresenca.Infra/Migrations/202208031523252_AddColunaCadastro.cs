namespace AjmdsControloPresenca.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColunaCadastro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presenca", "Cadastro", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Presenca", "Cadastro");
        }
    }
}
