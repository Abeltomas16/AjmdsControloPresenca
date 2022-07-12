namespace AjmdsControloPresenca.Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AjmdsControloPresenca.Infra.Entity.Data.EntityDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AjmdsControloPresenca.Infra.Entity.Data.EntityDatabaseContext context)
        {
            context.Database.ExecuteSqlCommand(
              " INSERT dbo.Cargo(CargoId, Descricao) VALUES (1, N'GERENTE')               "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(2, N'PROGRAMADOR SENIOR')     "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(3, N'PROGRAMADOR JÚNIOR')     "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(4, N'PROGRAMADOR PLENO')      "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(5, N'VENDEDOR')               "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(6, N'AUXILIAR DE RH')         "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(7, N'DESIGNER GRÁFICO')       "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(8, N'TÉCNICO DE COMPRA')      "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(9, N'TÉCNICO DE REDE')        "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(10, N'RECEPCIONISTA')         "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(11, N'GESTOR DE VENDAS')      "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(12, N'GESTORA DE RH')         "
              + " INSERT dbo.Cargo(CargoId, Descricao) VALUES(13, N'ESPECIALISTA DE VENDA')");
        }
    }
}
