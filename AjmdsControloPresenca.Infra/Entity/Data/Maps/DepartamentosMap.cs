using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    public class DepartamentosMap : EntityTypeConfiguration<Departamento>
    {
        public DepartamentosMap()
        {
            ToTable("Departamento");

            HasKey(pk => pk.DepartamentoId);

            Property(c => c.DepartamentoId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(c => c.Descricao)
                .HasMaxLength(100)
                .HasColumnAnnotation("IX_DESCRICAO", new IndexAnnotation(new System.ComponentModel.DataAnnotations.Schema.IndexAttribute()
                {
                    IsUnique = true
                }));

            Property(c => c.Estado);
        }
    }
}
