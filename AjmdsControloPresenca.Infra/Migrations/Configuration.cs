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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Database.ExecuteSqlCommand("ALTER TABLE DepartamentoTurno " +
                                    "ADD FOREIGN KEY(Id) REFERENCES Departamento(Id)");
        }
    }
}
