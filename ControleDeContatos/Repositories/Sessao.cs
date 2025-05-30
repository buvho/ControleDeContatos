﻿using ControleDeContatos.Models;
using Newtonsoft.Json;

namespace ControleDeContatos.Repositories
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Sessao (IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public void CriarSessaoDoUsuario(UsuarioModel Usuario)
        {
            string valor = JsonConvert.SerializeObject(Usuario);
            _contextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }

        public UsuarioModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

        }
    }
}
