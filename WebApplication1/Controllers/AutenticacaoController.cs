using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using WebApplication1.Utils;
using System.Security.Claims;

namespace WebApplication1.Controllers  {
    public class AutenticacaoController : Controller {

        private UsuariosContext db = new UsuariosContext();

        //public string UrlRetorno { get; private set; }

        public ActionResult Cadastrar() { return View(); }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewModel) {

            if (!ModelState.IsValid) {
                return View(viewModel);
            }

            if (db.Usuario.Count(u => u.Login == viewModel.Login) > 0) {
                ModelState.AddModelError("Login", "Esse Login já esta em uso");
                return View(viewModel);
            }

            Usuario novoUsuario = new Usuario {
                Nome = viewModel.Nome,
                Login = viewModel.Login,
                Senha = Hash.GeraHash(viewModel.Senha)

            };


            db.Usuario.Add(novoUsuario);
            db.SaveChanges();
            TempData["Mensagem"] = "Cadastro Realizado com sucesso";
            return View();

        }


        public ActionResult Login(String ReturnUrl) {
            var viewmodel = new LoginViewModel{
               UrlRetorno = ReturnUrl
            };
            return View(viewmodel);
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel viewmodel){

            if (!ModelState.IsValid) { return View(viewmodel); }

            var usuario = db.Usuario.FirstOrDefault( u => u.Login == viewmodel.Login);

            if (usuario == null){
                ModelState.AddModelError("Senha", "Login ou senha incorreta");
                return View(viewmodel);
            }
            if (usuario.Senha != Hash.GeraHash(viewmodel.Senha))  {
                ModelState.AddModelError("Senha", "Login ou senha incorreta");
                return View(viewmodel);
            }


            var Identidade = new ClaimsIdentity(new[]{//cookie de credenciais
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Login)
              }, "ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(Identidade);
            if ((!String.IsNullOrWhiteSpace(viewmodel.UrlRetorno)) || (Url.IsLocalUrl(viewmodel.UrlRetorno)))
            {
                return Redirect(viewmodel.UrlRetorno);
            }
            else return RedirectToAction("Index", "Painel");
        }

       public ActionResult Logout() {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index","Home");
        }
    }
}