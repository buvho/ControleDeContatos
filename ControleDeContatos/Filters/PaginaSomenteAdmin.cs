﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using ControleDeContatos.Models;
using Newtonsoft.Json;
namespace ControleDeContatos.Filters
{
    public class PaginaSomenteAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Login" }, { "action", "Index" } });

                }
                else if (usuario.Perfil != ControleDeContatos.PerfilEnum.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Contato" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
