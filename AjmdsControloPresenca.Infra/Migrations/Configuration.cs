namespace AjmdsControloPresenca.Infra.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AjmdsControloPresenca.Infra.Entity.Data.EntityDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AjmdsControloPresenca.Infra.Entity.Data.EntityDatabaseContext context)
        {
          /*  context.Database.ExecuteSqlCommand(
                " INSERT dbo.Cargo( Descricao) VALUES (N'GERENTE')               "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'PROGRAMADOR SENIOR')     "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'PROGRAMADOR JÚNIOR')     "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'PROGRAMADOR PLENO')      "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'VENDEDOR')               "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'AUXILIAR DE RH')         "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'DESIGNER GRÁFICO')       "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'TÉCNICO DE COMPRA')      "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'TÉCNICO DE REDE')        "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'RECEPCIONISTA')         "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'GESTOR DE VENDAS')      "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'GESTORA DE RH')         "
              + " INSERT dbo.Cargo( Descricao) VALUES( N'ESPECIALISTA DE VENDA'); ");

            context.Database.ExecuteSqlCommand("INSERT dbo.Departamento( Descricao, Estado) VALUES ( N'GERAL', CONVERT(bit, 'True'))                  "
                                             + "  INSERT dbo.Departamento(Descricao, Estado) VALUES( N'TÉCNICO E REPARAÇÕES', CONVERT(bit, 'True'))   "
                                             + "  INSERT dbo.Departamento (Descricao, Estado) VALUES( N'COMERCIAL', CONVERT(bit, 'True'))              "
                                             + "  INSERT dbo.Departamento(Descricao, Estado) VALUES( N'RECURSOS  HUMANOS', CONVERT(bit, 'True'))");

            context.Database.ExecuteSqlCommand("INSERT dbo.Turno( Entrada, Saida, Estado, TurnoToleranciaAtraso) VALUES  ('2022-07-12 08:00:00', '2022-07-12 17:30:00', CONVERT(bit, 'True'), 10) "
                                 + "  INSERT dbo.Turno( Entrada, Saida, Estado, TurnoToleranciaAtraso) VALUES( '2022-07-12 09:00:00', '2022-07-12 12:30:00', CONVERT(bit, 'True'), 0)"
                                 + "  INSERT dbo.Turno( Entrada, Saida, Estado, TurnoToleranciaAtraso) VALUES( '2022-07-12 00:00:00', '2022-07-12 00:00:00', CONVERT(bit, 'True'), 0)");

            context.Database.ExecuteSqlCommand("  INSERT INTO dbo.DepartamentoTurno "
                                               + " (TurnoSegundaId, DepartamentoId, TurnoTercaId,TurnoQuartaId, TurnoQuintaId, TurnoSextaId, TurnoSabadoId, TurnoDomingoId) "
                                               + " VALUES(1, 1, 1, 1, 1, 1, 2, 3); ");

            context.Database.ExecuteSqlCommand("  INSERT INTO dbo.DepartamentoTurno "
                                               + " (TurnoSegundaId, DepartamentoId, TurnoTercaId,TurnoQuartaId, TurnoQuintaId, TurnoSextaId, TurnoSabadoId, TurnoDomingoId) "
                                               + " VALUES(1, 2, 1, 1, 1, 1, 2, 3); ");

            context.Database.ExecuteSqlCommand(" INSERT INTO dbo.DepartamentoTurno "
                                               + " (TurnoSegundaId, DepartamentoId, TurnoTercaId,TurnoQuartaId, TurnoQuintaId, TurnoSextaId, TurnoSabadoId, TurnoDomingoId) "
                                               + " VALUES(1, 3, 1, 1, 1, 1, 2, 3); ");

            context.Database.ExecuteSqlCommand("INSERT dbo.EstadoCivil(Descricao) VALUES ( N'SOLTEIRO(A)')     "
                                               + " INSERT dbo.EstadoCivil(Descricao) VALUES( N'DIVORCIADO(A)')  "
                                               + " INSERT dbo.EstadoCivil(Descricao) VALUES(N'CASADO(A)')      "
                                               + " INSERT dbo.EstadoCivil(Descricao) VALUES( N'VIUVO(A)')");

            context.Database.ExecuteSqlCommand("INSERT dbo.Genero(Descricao) VALUES ( N'MASCULINO') "
                                               + " INSERT dbo.Genero(Descricao) VALUES( N'FEMENINO')");
            

            context.SaveChanges();*/
        }
    }
}
