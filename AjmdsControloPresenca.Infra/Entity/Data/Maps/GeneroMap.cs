using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    public class GeneroMap : EntityTypeConfiguration<Genero>
    {
        public GeneroMap()
        {
            ToTable("Genero");

            HasKey(pk => pk.Id);

            Property(c => c.Descricao)
                .HasMaxLength(15)
                .HasColumnAnnotation("IX_DESCRICAO", new IndexAnnotation(new System.ComponentModel.DataAnnotations.Schema.IndexAttribute()
                {
                    IsUnique = true
                }));
        }
    }
}
