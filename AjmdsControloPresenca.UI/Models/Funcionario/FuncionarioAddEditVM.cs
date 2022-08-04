﻿using System.ComponentModel.DataAnnotations;

namespace AjmdsControloPresenca.UI.Models.Funcionario
{
    public class FuncionarioAddEditVM
    {
        public short Id { get; set; }
        [Required, StringLength(30)]
        public string Nome { get; set; }
        [Required, StringLength(30)]
        public string SobreNome { get; set; }
        [Display(Name = "Salário liquido")]
        public decimal SalarioLiquido { get; set; }
        public string Observacao { get; set; }
        [Required, StringLength(30), Display(Name = "Contacto Principal")]
        public string ContactoPrincipa { get; set; }
        [Display(Name = "Contacto Auxiliar")]
        public string ContactoAuxiliar { get; set; }
        public bool Estado { get; set; }
        [Required, Display(Name = "Genero")]
        public short GeneroId { get; set; }
        [Required, Display(Name = "Estado Civil")]
        public short EstadoCivilId { get; set; }
        [Required, Display(Name = "Departamento")]
        public short DepartamentoId { get; set; }
        [Required, Display(Name = "Cargo")]
        public short CargoId { get; set; }
    }
}