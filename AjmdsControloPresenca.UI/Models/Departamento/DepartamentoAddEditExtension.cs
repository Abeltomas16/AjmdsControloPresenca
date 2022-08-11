using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dept = AjmdsControloPresenca.Domain.Entities;
namespace AjmdsControloPresenca.UI.Models.Departamento
{
    public static class DepartamentoAddEditExtension
    {
        public static dept.Departamento ToDepartamento(this DepartamentoAddEditVM Entity)
        {
            return new dept.Departamento
            {
                DepartamentoId=Entity.Id,
                Descricao = Entity.Descricao.ToUpper(),
                Estado = Entity.Estado
            };
        }
        public static DepartamentoAddEditVM  ToDepartamentoVM(this dept.Departamento Entity)
        {
            return new DepartamentoAddEditVM
            {
                Id = Entity.DepartamentoId,
                Descricao = Entity.Descricao,
                Estado = Entity.Estado
            };
        }
    }
}