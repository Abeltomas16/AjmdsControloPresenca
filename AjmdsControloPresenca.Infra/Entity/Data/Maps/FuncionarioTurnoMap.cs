using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    public class FuncionarioTurnoMap : EntityTypeConfiguration<FuncionarioTurno>
    {
        public FuncionarioTurnoMap()
        {
            ToTable("FuncionarioTurno");

            HasKey(pk => pk.FuncionarioId);

            Property(c => c.TurnoSegundaId)
                .HasColumnOrder(1);


            HasRequired(fk => fk.TurnoSegunda)
                  .WithMany(c => c.FuncionarioTurnoSegunda)
                  .HasForeignKey(x => x.TurnoSegundaId)
                  .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoTerca)
              .WithMany(c => c.FuncionarioTurnoTerca)
              .HasForeignKey(x => x.TurnoTercaId)
              .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoQuarta)
               .WithMany(c => c.FuncionarioTurnoQuarta)
               .HasForeignKey(x => x.TurnoQuartaId)
               .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoQuinta)
              .WithMany(c => c.FuncionarioTurnoQuinta)
              .HasForeignKey(x => x.TurnoQuintaId)
              .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoSexta)
               .WithMany(c => c.FuncionarioTurnoSexta)
               .HasForeignKey(x => x.TurnoSextaId)
               .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoSabado)
               .WithMany(c => c.FuncionarioTurnoSabado)
               .HasForeignKey(x => x.TurnoSabadoId)
               .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoDomingo)
               .WithMany(c => c.FuncionarioTurnoDomingo)
               .HasForeignKey(x => x.TurnoDomingoId)
               .WillCascadeOnDelete(false);
        }

    }
}

