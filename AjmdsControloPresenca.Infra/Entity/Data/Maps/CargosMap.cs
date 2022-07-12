using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    public class CargosMap:EntityTypeConfiguration<Cargo>
    {
        public CargosMap()
        {
            ToTable("Cargo");

            HasKey(pk => pk.CargoId);

            Property(c => c.CargoId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(c => c.Descricao)
                .HasMaxLength(50)
                .HasColumnAnnotation("IX_DESCRICAO", new IndexAnnotation(new System.ComponentModel.DataAnnotations.Schema.IndexAttribute()
                {
                    IsUnique=true           
                }));
        }
    }
}
