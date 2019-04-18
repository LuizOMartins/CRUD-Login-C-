using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Utils;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class PerfilController : Controller
    {
        private UsuariosContext db = new UsuariosContext();
        
        [Authorize]
        // GET: Perfil
        public ActionResult AlterarSenha() {
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewmodel){

            if (!ModelState.IsValid)
            {
                return View();
            }
            var Identidade = User.Identity as ClaimsIdentity;

            //var Login  = db.identity.Claims.FirstOrDefault(u => u.login == login);

            var Login = Identidade.Claims.FirstOrDefault(
                  c => c.Type == "Login").Value;

            var usuario = db.Usuario.FirstOrDefault(
                u => u.Login == Login);

        if(Hash.GeraHash(viewmodel.SenhaAtual) != (usuario.Senha)){
                ModelState.AddModelError("SenhaAtual","Senha Incorreta");
                return View();
         }

            usuario.Senha = Hash.GeraHash(viewmodel.NovaSenha);
            db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Painel");
            

        }

    }
}