using Aula01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Aula01.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = new Cliente()
            {
                Nome = "Asp",
                SobreNome = "Net",
                DataCadastro = DateTime.Now
            };

            ViewBag.Cliente = cliente;

            return View("Index", cliente);
        }

        public ActionResult Lista()
        {
            var ListaClientes = new List<Cliente>()
            {
                new Cliente(){Nome="João", SobreNome="Pedro", Id=1},
                new Cliente(){Nome="Fulano", SobreNome="De tal", Id=2},

            };

            return View(ListaClientes);
        }

        public ActionResult Pesquisa(int? idCliente, string nomeCliente)
        {
            var ListaClientes = new List<Cliente>()
            {
                new Cliente(){Nome="João", SobreNome="Pedro", Id=1},
                new Cliente(){Nome="Fulano", SobreNome="De tal", Id=2},
                new Cliente(){Nome="Eduardo", SobreNome="De tal", Id=3},
                new Cliente(){Nome="Maria", SobreNome="De tal", Id=4},

            };

            var retorno = ListaClientes.Where(c => c.Nome == nomeCliente && c.Id == idCliente).ToList();

            if (!retorno.Any())
            {
                TempData["erro"] = "Nenhum cliente selecionado, com os parametros informados!";
                return RedirectToAction("ErroPesquisa");

            }

            return View("Lista", retorno);
        }
        public ActionResult ErroPesquisa()
        {
            return View("_Error");
        }
    }
}