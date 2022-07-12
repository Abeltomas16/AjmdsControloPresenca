using AjmdsControloPresenca.Domain.Entities;
using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    public class DepartamentosTurnoMap : EntityTypeConfiguration<DepartamentoTurno>
    {
        public DepartamentosTurnoMap()
        {
            ToTable("DepartamentoTurno");

            HasKey(pk => pk.DepartamentoId);
            Property(c => c.TurnoSegundaId)
                .HasColumnOrder(1);

            HasRequired(fk => fk.TurnoSegunda)
                  .WithMany(c => c.DepartamentoTurno)
                  .HasForeignKey(x => x.TurnoSegundaId)
                  .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoTerca)
              .WithMany(c => c.DepartamentoTurnoTerca)
              .HasForeignKey(x => x.TurnoTercaId)
              .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoQuarta)
               .WithMany(c => c.DepartamentoTurnoQuarta)
               .HasForeignKey(x => x.TurnoQuartaId)
               .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoQuinta)
              .WithMany(c => c.DepartamentoTurnoQuinta)
              .HasForeignKey(x => x.TurnoQuintaId)
              .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoSexta)
               .WithMany(c => c.DepartamentoTurnoSexta)
               .HasForeignKey(x => x.TurnoSextaId)
               .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoSabado)
               .WithMany(c => c.DepartamentoTurnoSabado)
               .HasForeignKey(x => x.TurnoSabadoId)
               .WillCascadeOnDelete(false);

            HasRequired(fk => fk.TurnoDomingo)
               .WithMany(c => c.DepartamentoTurnoDomingo)
               .HasForeignKey(x => x.TurnoDomingoId)
               .WillCascadeOnDelete(false);
        }
    }
}
