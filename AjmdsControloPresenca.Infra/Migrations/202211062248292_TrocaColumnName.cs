namespace AjmdsControloPresenca.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrocaColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Afastamento", "DataAfastamento", c => c.DateTime(nullable: false));
            DropColumn("dbo.Afastamento", "DataAfasmento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Afastamento", "DataAfasmento", c => c.DateTime(nullable: false));
            DropColumn("dbo.Afastamento", "DataAfastamento");
        }
    }
}
