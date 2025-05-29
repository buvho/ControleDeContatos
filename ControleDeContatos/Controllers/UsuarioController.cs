using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            return View(_usuarioRepository.BuscarTodos());
        }

        public IActionResult Criar() {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Adcionar(usuario);
                    TempData["MensagemSucesso"] = "Contato adcionado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (Exception ex) {
                TempData["MensagemErro"] = "algo deu errado!" + ex;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id) {
            if (_usuarioRepository.Deletar(id))
            {
                TempData["MensagemSucesso"] = "Contato Deletado com sucesso";
            }
            else
            {
                TempData["MensagemErro"] = "Algo deu errado!";
            }

                return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var usuario = _usuarioRepository.BuscarPorId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try {
                UsuarioModel? usuario = null;

                if (ModelState.IsValid){
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil,
                    };
                    _usuarioRepository.Editar(usuario);
                    TempData["MensagemSussesso"] = "adicionado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch
            {
                TempData["MensagemErro"] = "Ops, algo de errado aconteceu!";
                return RedirectToAction("Index");
            }
        }
    }

}
