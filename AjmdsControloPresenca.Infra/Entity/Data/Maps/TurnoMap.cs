using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    public class TurnoMap : EntityTypeConfiguration<Turno>
    {
        public TurnoMap()
        {
            ToTable("Turno");

            HasKey(pk => pk.Id);

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(c => c.Entrada);
            Property(c => c.Saida);
            Property(c => c.Entrada);

            Property(c => c.Estado);
        }
    }
}
