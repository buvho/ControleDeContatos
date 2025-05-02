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
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adcionar(contato);
                    TempData["MensagemSucesso"] = "Contato adicionado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos adicionar seu contato. Tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }
        public IActionResult Editar(int id)
        {
            var contato = _contatoRepositorio.BuscarPorId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Editar(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos editar seu contato. Tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }
        [HttpPost]
        public IActionResult Deletar(int id)
        {
              
            bool apagado = _contatoRepositorio.Deletar(id);
            if (apagado)
            {
                TempData["MensagemSucesso"] = "Contato deletado com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = "Ops, não conseguimos deletar seu contato. Tente novamente.";
            }
            return RedirectToAction("Index");
        }
        
    }
}
