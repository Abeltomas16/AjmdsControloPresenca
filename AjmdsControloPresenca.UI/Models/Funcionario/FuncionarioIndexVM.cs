﻿using System;

namespace AjmdsControloPresenca.UI.Models.Funcionario
{
    public class FuncionarioIndexVM
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Bilhete { get; set; }
        public string ContactoPrincipal { get; set; }
        public string Estado { get; set; }
        public string DepartamentoDescricao { get; set; }
        public string CargoDescricao { get; set; }
    }
}