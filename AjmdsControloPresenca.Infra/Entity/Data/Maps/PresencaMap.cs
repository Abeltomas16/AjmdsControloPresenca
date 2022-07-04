using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    public class PresencaMap:EntityTypeConfiguration<Presenca>
    {
        public PresencaMap()
        {
            ToTable("Presenca");

            HasKey(pk => pk.Id);

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(c => c.Entrada);
            Property(c => c.Saida);

            Property(c => c.FuncionarioId);

            HasRequired(fk => fk.Funcionarios)
                 .WithMany()
                 .HasForeignKey(x => x.FuncionarioId);
                
        }
    }
}
