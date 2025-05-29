using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuario.ToList();
        }
        public UsuarioModel BuscarPorId(int id)
        {
            return _bancoContext.Usuario.FirstOrDefault(X => X.Id == id);
        }
        public UsuarioModel BuscarPorEmail(string Email)
        {
            return _bancoContext.Usuario.FirstOrDefault(X => X.Email.Equals(Email));
        }
        public UsuarioModel Adcionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuario.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }
        public UsuarioModel Editar(UsuarioModel usuario)
        {
            var usuarioDB = BuscarPorId(usuario.Id) ?? throw new Exception("usuario nao encontrado");
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;
            _bancoContext.Update(usuarioDB);
            _bancoContext.SaveChanges();
            return usuario;
        }
        public bool Deletar(int id)
        {
            var usuarioDB = BuscarPorId(id);
            if (usuarioDB == null) throw new Exception("usuario nao encontrado");
            _bancoContext.Usuario.Remove(usuarioDB);
            _bancoContext.SaveChanges();
            return true;
        }

        public UsuarioModel ValidarSenha(string senha)
        {
            throw new NotImplementedException();
        }

        public bool BuscarAdm()
        {
            var achou = _bancoContext.Usuario.Any(X => X.Perfil == PerfilEnum.Admin);
            return achou;
        }

    }
}
