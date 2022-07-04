using AjmdsControloPresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            Property(c => c.SalarioLiquido)
               .HasColumnType("money");

            Property(c => c.Observacao)
               .HasMaxLength(200)
               .HasColumnType("varchar");

            Property(c => c.ContactoAuxiliar)
                .HasMaxLength(25)
                .HasColumnType("varchar")
                .IsRequired();

            Property(c => c.ContactoAuxiliar)
               .HasMaxLength(50)
               .HasColumnType("varchar");

            Property(c => c.Estado);
            Property(c => c.DataCadastro);

            Property(c => c.DepartamentoId);

            HasRequired(fk => fk.Departamento)
                 .WithMany()
                 .HasForeignKey(x => x.DepartamentoId);

            Property(c => c.CargoId);

            HasRequired(fk => fk.Cargo)
                 .WithMany()
                 .HasForeignKey(x => x.CargoId);

            Property(c => c.GeneroId);

            HasRequired(fk => fk.Genero)
                 .WithMany()
                 .HasForeignKey(x => x.GeneroId);


            Property(c => c.EstadoCivilId);

            HasRequired(fk => fk.EstadoCivil)
                 .WithMany()
                 .HasForeignKey(x => x.EstadoCivilId);

            Property(c => c.CadastradorUsuarioId);

            HasRequired(fk => fk.Usuario)
                 .WithMany()
                 .HasForeignKey(x => x.CadastradorUsuarioId);
        }
    }
}
