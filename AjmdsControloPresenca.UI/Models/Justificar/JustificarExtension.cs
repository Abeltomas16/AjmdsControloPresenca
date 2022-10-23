using System;
using System.Collections.Generic;
using System.Linq;
using js = AjmdsControloPresenca.Domain.Entities;

namespace AjmdsControloPresenca.UI.Models.Justificar
{
    public static class JustificarExtension
    {
        public static JustificarVM ToJustificativaVM(this js.Presenca Entity)
        {
            return new JustificarVM
            {
                Id = Entity.Id,
                Data = Entity.Cadastro.ToString("yyyy-MM-dd"),
                HoraInicial = Entity.Entrada == null ? "" : Entity.Entrada.Value.ToString("HH:mm:ss"),
                HoraFinal = Entity.Saida == null ? "" : Entity.Saida.Value.ToString("HH:mm:ss"),
            };
        }
        public static js.Presenca ToJustificativaPresenca(this JustificarVM Entity, short FuncionarioId)
        {
            var HoraEntrada = string.Concat(Entity.Data, " ", Entity.HoraInicial);
            var HoraSaida = string.Concat(Entity.Data, " ", Entity.HoraFinal);
            DateTime DataEntrada = DateTime.Parse(HoraEntrada);
            DateTime DataSaida = DateTime.Parse(HoraSaida);
            return new js.Presenca
            {
                Id = Entity.Id,
                Entrada = DataEntrada,
                Saida = DataSaida,
                Cadastro = DataSaida,
                FuncionarioId = FuncionarioId
            };
        }
    }
}