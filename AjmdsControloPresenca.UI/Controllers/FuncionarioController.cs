﻿using AjmdsControloPresenca.Domain.Entities;
using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models;
using AjmdsControloPresenca.UI.Models.Funcionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        FuncionarioRepositoryEF repositoryEF = new FuncionarioRepositoryEF();
        DepartamentoRepositoryEF _departamentoRepository = new DepartamentoRepositoryEF();
        CargoRepositoryEF _cargosRepositoryEF = new CargoRepositoryEF();
        GeneroRepositoryEF _generoRepositoryEF = new GeneroRepositoryEF();
        EstadoCivilRepositoryEF _estadoCivilRepository = new EstadoCivilRepositoryEF();
        public ActionResult Index()
        {
            var funcionarios = repositoryEF.ListarTodos().ToFuncionarioVM();
            return View(funcionarios);
        }
        public ActionResult Add()
        {
            FuncionarioIndexVM funcionario = new FuncionarioIndexVM();

            var departamento = _departamentoRepository.ListarTodos();
            var cargos = _cargosRepositoryEF.ListarTodos();
            var genero = _generoRepositoryEF.ListarTodos();
            var estadoCivil = _estadoCivilRepository.ListarTodos();
            ViewBag.Departamentos = departamento;
            ViewBag.Cargos = cargos;
            ViewBag.Genero = genero;
            ViewBag.EstadoCivil = estadoCivil;
            return View(funcionario);
        }
    }
}