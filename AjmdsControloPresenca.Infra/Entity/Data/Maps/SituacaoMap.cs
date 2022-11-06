using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
   public  class SituacaoMap : EntityTypeConfiguration<Situacao>
    {
        public SituacaoMap()
        {
            ToTable("Situacao");

            HasKey(pk => pk.Id);

            Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(c => c.Descricao)
                .HasMaxLength(100)
                .HasColumnAnnotation("ST_DESCRICAO", new IndexAnnotation(new System.ComponentModel.DataAnnotations.Schema.IndexAttribute()
                {
                    IsUnique = true
                }));
        }
    }
}

