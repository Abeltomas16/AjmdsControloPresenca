using AjmdsControloPresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjmdsControloPresenca.Infra.Entity.Data
{
    public class EntityDatabaseContext : DbContext
    {
        public EntityDatabaseContext() : base("ConnectionStringSQL")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<DepartamentoTurno> DepartamentoTurnos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
