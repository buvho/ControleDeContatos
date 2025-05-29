using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Repositories
{
    public interface IUsuarioRepository
    {
        List<UsuarioModel> BuscarTodos();
        UsuarioModel ValidarSenha(string senha);
        UsuarioModel? BuscarPorEmail(string email);
        bool BuscarAdm();
        UsuarioModel BuscarPorId(int id);
        UsuarioModel Adcionar(UsuarioModel usuario);
        UsuarioModel Editar(UsuarioModel usuario);
        bool Deletar(int id);
    }
}
