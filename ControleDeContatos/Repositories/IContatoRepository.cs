using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Repositories
{
    public interface IContatoRepository
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel Adcionar(ContatoModel contato);
        ContatoModel BuscarPorId(int id);
        ContatoModel Editar(ContatoModel contato);
        bool Deletar(int id);
    }
}
