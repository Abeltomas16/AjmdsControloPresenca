using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    public class TurnoMap : EntityTypeConfiguration<Turno>
    {
        public TurnoMap()
        {
            ToTable("Turno");

            HasKey(pk => pk.Id);

            Property(c => c.Descricao)
              .IsRequired()
              .HasMaxLength(50)
              .HasColumnAnnotation("IX_DESCRICAO", new IndexAnnotation(new System.ComponentModel.DataAnnotations.Schema.IndexAttribute()
              {
                  IsUnique = true
              }));

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(c => c.Entrada).IsRequired();
            Property(c => c.Saida).IsRequired();
            Property(c => c.Estado);

        }
    }
}
