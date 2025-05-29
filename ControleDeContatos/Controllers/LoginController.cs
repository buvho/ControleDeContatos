using ControleDeContatos.Models;
using ControleDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepository usuarioRepository, ISessao sessao)
        {
            _usuarioRepository = usuarioRepository;
            _sessao = sessao;
        }   
        public IActionResult Index()
        {
           if (!_usuarioRepository.BuscarAdm()){
                UsuarioModel usuario = new() {
                    Nome = "Admin",
                    Email = "admin@email.com",
                    Senha = "Admin",
                    Perfil = PerfilEnum.Admin,
                    DataCadastro = DateTime.Now
                    
                };
                _usuarioRepository.Adcionar(usuario);
            }
           if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index","Home");
           return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index","Login");
        }

        [HttpPost]
        public IActionResult Logar(LoginModel login) {
            try {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioRepository.BuscarPorEmail(login.Email);
                    if (usuario != null && usuario.SenhaValida(login.Senha))
                    {
                        _sessao.CriarSessaoDoUsuario(usuario);
                        return RedirectToAction("Index", "Contato");
                    }
                }
                TempData["MensagemErro"] = "Usuario ou/e Senha invalidos";
                return View("Index");
            }
            catch (Exception ex) {
                TempData["MensagemErro"] = "algo deu errado";
                return View("Index");
            } 
        }

    }
}
