using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    internal class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            HasKey(pk => pk.FuncionarioId);

            Property(c => c.Nome)
                .HasMaxLength(50)
                       .HasColumnAnnotation("IX_NOME", new IndexAnnotation(new System.ComponentModel.DataAnnotations.Schema.IndexAttribute()
                       {
                           IsUnique = true
                       }))
                .IsRequired();

            Property(c => c.Senha)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
