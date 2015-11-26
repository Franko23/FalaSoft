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
    public class AdminController : Controller
    {
        private Kingdom db = new Kingdom();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
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
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login details are wrong.");
                }               
            }
            return View(user);
        }
            

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
               
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

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
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
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