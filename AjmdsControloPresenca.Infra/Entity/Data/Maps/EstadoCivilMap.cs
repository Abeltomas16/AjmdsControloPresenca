using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    internal class EstadoCivilMap : EntityTypeConfiguration<EstadoCivil>
    {
        public EstadoCivilMap()
        {
            ToTable("EstadoCivil");

            HasKey(pk => pk.Id);

            Property(c => c.Descricao)
                .HasMaxLength(20)
                .HasColumnAnnotation("IX_DESCRICAO", new IndexAnnotation(new System.ComponentModel.DataAnnotations.Schema.IndexAttribute()
                {
                    IsUnique = true
                }));
        }
    }
}
