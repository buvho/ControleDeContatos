using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contato.ToList();
        }
        public ContatoModel Adcionar(ContatoModel contato)
        {
            _bancoContext.Contato.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }
        public ContatoModel BuscarPorId(int id) {
            return _bancoContext.Contato.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            ContatoModel contatoDB = BuscarPorId(contato.Id) ?? throw new Exception("Contato não encontrado");
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;
            _bancoContext.Update(contatoDB);
            _bancoContext.SaveChanges();
            return contatoDB;
        }

        public bool Deletar(int id)
        {
            ContatoModel contatoDB = BuscarPorId(id);
            if (contatoDB == null) throw new Exception("Contato não encontrado");
            _bancoContext.Contato.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
