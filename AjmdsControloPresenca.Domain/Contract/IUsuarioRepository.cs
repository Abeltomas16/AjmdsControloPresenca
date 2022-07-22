﻿using AjmdsControloPresenca.Domain.Entities;

namespace AjmdsControloPresenca.Domain.Contract
{
    public interface IUsuarioRepository : IRepositoryCrud<Usuario>
    {
        Usuario ListarPorNome(string nome);
    }
}
