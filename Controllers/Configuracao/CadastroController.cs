using AspNetCoreHero.ToastNotification.Abstractions;
using RegistroClientes.Factorie;
using RegistroClientes.Model;
using RegistroClientes.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroClientes.Controllers
{
    public class CadastroController : Controller
    {
        private readonly CadastroViewModels model;
        private readonly INotyfService _notyf;

        public CadastroController(ConfiguracaoCadastro configuracao, INotyfService notyf)
        {
            model = new CadastroViewModels(configuracao);
            _notyf = notyf;
        }
        public IActionResult Index()
        {
            model.Cadastros = model.ListaDeCadastro();
            return View(model);
        }

        [HttpPost]
        public IActionResult Adicionar(Cliente cadastro)
        {
            if (model.InserirCadastro(cadastro))
            {
                _notyf.Success("Cadastro realizado com sucesso!");
                return RedirectToAction("Index");
            }
            _notyf.Warning("Não foi possivel realizar o cadastro");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            model.Cadastro = model.ListaDeCadastro().FirstOrDefault(x => x.Id == id);
            return View("Editar", model);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cadastro)
        {
            if (model.AtualizarCadastro(cadastro))
            {
                _notyf.Success("Cadastro atualizado com sucesso!");
                return RedirectToAction("Index");
            }
            _notyf.Warning("Não foi possivel atualizar o cadastro");
            return View("Editar", model);
        }

        public IActionResult Excluir(int id)
        {
            if (model.EcluirCadastro(id))
            {
                _notyf.Success("Cadastro excluído com sucesso!");
                return RedirectToAction("Index");
            }
            _notyf.Warning("Não foi pessivel excluir o cadastro");
            return View("Index");
        }
    }
}
