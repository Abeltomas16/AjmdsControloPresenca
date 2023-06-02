using System;
using System.ComponentModel.DataAnnotations;


namespace AjmdsControloPresenca.UI.Models.Afastamento
{
    public class AfastamentoAddEditVM
    {
        public int Id { get; set; }


        [Required, Display(Name = "Funcionário")]
        public short FuncionarioId { get; set; }

        [Required]
        [Display(Name = "Observação"), StringLength(50)]
        public string Observacao { get; set; }

        [Required, Display(Name = "Situação")]
        public short SituacaoId { get; set; }

        [Required, Display(Name = "Data afastamento")]
        public string DataAfastamento { get; set; }

        [Required, Display(Name = "Data Término")]
        public string DataTermino { get; set; }

        [ Display(Name = "Remunerável?")]
        public bool Apurado { get; set; }

    }
}