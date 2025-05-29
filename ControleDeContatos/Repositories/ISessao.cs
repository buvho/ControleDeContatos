using ControleDeContatos.Models;

namespace ControleDeContatos.Repositories
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel Usuario);
        void RemoverSessaoUsuario();
        UsuarioModel BuscarSessaoUsuario();
    }
}
