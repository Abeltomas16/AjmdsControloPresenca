using AjmdsControloPresenca.Domain.Entities;
using AjmdsControloPresenca.Infra.Entity.Data.Maps;
using System.Data.Entity;

namespace AjmdsControloPresenca.Infra.Entity.Data
{
    public class EntityDatabaseContext : DbContext
    {
        public EntityDatabaseContext() : base("Password=049222Xp12;Persist Security Info=True;User ID=sa;Initial Catalog=ALAYSBABel;Data Source=.")
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CargosMap());
            modelBuilder.Configurations.Add(new DepartamentosMap());
            modelBuilder.Configurations.Add(new DepartamentosTurnoMap());
            modelBuilder.Configurations.Add(new EstadoCivilMap());
            modelBuilder.Configurations.Add(new FuncionarioMap());
            modelBuilder.Configurations.Add(new GeneroMap());
            modelBuilder.Configurations.Add(new PresencaMap());
            modelBuilder.Configurations.Add(new TurnoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
