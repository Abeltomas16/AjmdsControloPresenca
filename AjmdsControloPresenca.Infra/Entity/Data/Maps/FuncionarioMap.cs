using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            ToTable("Funcionario");

            HasKey(pk => pk.Id);

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(c => c.Nome)
             .HasMaxLength(30)
            .HasColumnType("varchar")
            .IsRequired();

            Property(c => c.SobreNome)
                 .HasMaxLength(30)
                .HasColumnType("varchar")
                .IsRequired();

            Property(c => c.Bilhete)
                  .HasMaxLength(15)
                 .HasColumnType("varchar")
                 .IsRequired()
                 .HasColumnAnnotation(
                    "IX_BILHETE",
                    new IndexAnnotation(
                        new System.ComponentModel.DataAnnotations.Schema.IndexAttribute()
                        { IsUnique = true }
                        ));

            Property(c => c.SalarioLiquido)
               .HasColumnType("money");

            Property(c => c.Observacao)
               .HasMaxLength(200)
               .HasColumnType("varchar");

            Property(c => c.ContactoPrincipal)
                .HasMaxLength(9)
                .HasColumnType("varchar")
                .IsRequired();

            Property(c => c.ContactoAuxiliar)
               .HasMaxLength(50)
               .HasColumnType("varchar");

            Property(c => c.Estado);
            Property(c => c.DataCadastro);
            Property(c => c.EstadoCivilId);
            Property(c => c.DepartamentoId);
            Property(c => c.CargoId);
            Property(c => c.GeneroId);

            HasRequired(s => s.Cargo)
            .WithMany(g => g.Funcionarios)
            .HasForeignKey<int>(s => s.CargoId);

            HasRequired(fk => fk.Departamento)
                 .WithMany(g => g.Funcionarios)
                .HasForeignKey(x => x.DepartamentoId);

            HasRequired(fk => fk.Cargo)
                 .WithMany(c => c.Funcionarios)
                 .HasForeignKey(x => x.CargoId);

            HasRequired(fk => fk.Genero)
                  .WithMany(c => c.Funcionarios)
                  .HasForeignKey(x => x.GeneroId);

            HasRequired(fk => fk.EstadoCivil)
                 .WithMany(c => c.Funcionarios)
                 .HasForeignKey(x => x.EstadoCivilId);


            //One by one
            HasOptional(a => a.Usuario)
           .WithRequired(ab => ab.Funcionario);

            HasOptional(a => a.FuncionarioTurno)
            .WithRequired(ab => ab.Funcionario);
        }
    }
}
