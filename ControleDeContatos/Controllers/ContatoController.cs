using ControleDeContatos.Models;
using ControleDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepositorio;
        public ContatoController(IContatoRepository contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            var contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adcionar(contato);
            return RedirectToAction("Index");
        }
        public IActionResult Editar(int id)
        {
            var contato = _contatoRepositorio.BuscarPorId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            _contatoRepositorio.Editar(contato);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Deletar(int id)
        {
            _contatoRepositorio.Deletar(id);
            return RedirectToAction("Index");
        }
        
    }
}
