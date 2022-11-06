using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    public class AfastamentoMap : EntityTypeConfiguration<Afastamento>
    {
        public AfastamentoMap()
        {
            ToTable("Afastamento");

            HasKey(pk => pk.Id);

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(c => c.Observacao)
             .HasMaxLength(100)
            .HasColumnType("varchar");

            Property(c => c.DataAfastamento);

            Property(c => c.DataTermino);

            Property(c => c.Estado);

            Property(c => c.Apurado);

            Property(c => c.SituacaoId);

            Property(c => c.FuncionarioId);

            HasRequired(fk => fk.Situacao)
                 .WithMany(g => g.Afastamentos)
                .HasForeignKey(x => x.SituacaoId);

            HasRequired(fk => fk.Funcionario)
                 .WithMany(c => c.Afastamentos)
                 .HasForeignKey(x => x.FuncionarioId);
        }
    }
}
