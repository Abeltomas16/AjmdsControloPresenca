using AjmdsControloPresenca.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AjmdsControloPresenca.Infra.Entity.Data.Maps
{
    public class DepartamentosTurnoMap : EntityTypeConfiguration<DepartamentoTurno>
    {
        public DepartamentosTurnoMap()
        {
            ToTable("DepartamentoTurno");

            HasKey(pk => pk.Id);

            //FK 1-1??

            Property(c => c.Segunda);
            Property(c => c.Terca);
            Property(c => c.Quarta);
            Property(c => c.Quinta);
            Property(c => c.Sexta);
            Property(c => c.Sabado);
            Property(c => c.Domingo);
            Property(c => c.Sabado);

            HasRequired(fk => fk.TurnoS)
                .WithMany()
                .HasForeignKey(f => f.Segunda);

            HasRequired(fk => fk.TurnoT)
                .WithMany()
                .HasForeignKey(f => f.Terca);


            HasRequired(fk => fk.TurnoQ)
                .WithMany()
                .HasForeignKey(f => f.Quarta);


            HasRequired(fk => fk.TurnoQT)
                .WithMany()
                .HasForeignKey(f => f.Quinta);

            HasRequired(fk => fk.TurnoS)
                .WithMany()
                .HasForeignKey(f => f.Sexta);


            HasRequired(fk => fk.TurnoSB)
                .WithMany()
                .HasForeignKey(f => f.Sabado);


            HasRequired(fk => fk.TurnoDM)
                .WithMany()
                .HasForeignKey(f => f.Domingo);

        }
    }
}
