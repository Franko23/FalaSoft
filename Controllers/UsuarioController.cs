using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KingdomWeb.Models;
using System.Web.Security;


namespace KingdomWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private Kingdom db = new Kingdom();
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.Usuario user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.NombreUsuario, user.ContraseñaUsuario))
                {
                    FormsAuthentication.SetAuthCookie(user.NombreUsuario, false);
                    if (user.NombreUsuario == "admin")
                    {
                        return RedirectToAction("Index","Admin");   
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Login details are wrong.");
                }
            }
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("LogIn","Usuario");
            }

            return View(usuario);
        }


        private bool IsValid(string usuario, string password)
        {


            bool isValid = false;

            using (var db = new Kingdom())
            {
                var user = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == usuario);

                if (user != null)
                {
                    if (user.ContraseñaUsuario == password)
                    {
                        isValid = true;
                    }
                }

            }


            return isValid;
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
