﻿using System;
using System.Collections.Generic;

namespace AjmdsControloPresenca.Domain.Entities
{
    public class Funcionario
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public decimal SalarioLiquido { get; set; }
        public string Observacao { get; set; }
        public string ContactoPrincipa { get; set; }
        public string ContactoAuxiliar { get; set; }
        public bool Estado { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public short CadastradorUsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public short GeneroId { get; set; }
        public virtual Genero Genero { get; set; }

        public short EstadoCivilId { get; set; }
        public virtual EstadoCivil EstadoCivil { get; set; }

        public short DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }

        public short CargoId { get; set; }
        public virtual Cargo  Cargo { get; set; }

        public virtual ICollection<Presenca> Presenca { get; set; }
    }
}
