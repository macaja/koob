using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Koob.Repositorio;
using logInFacade = Koob.Vista.Models.LoginAdmViewModel;
using System.Web.Security;

namespace Koob.Vista.Controllers
{
    public class AdministradorController : Controller
    {

        private AdministradorRepository adminRepositroy;

        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult logIn()
        {
            return View();
        }

        //POST: Usuario/LogIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(logInFacade login)
        {
            if (ModelState.IsValid) //Verificar que el modelo de datos sea valido en cuanto a la definición de las propiedades
            {
                adminRepositroy = new AdministradorRepository();
                var model = adminRepositroy.logueo(login.adm_nombre, login.adm_password);

                if (model == true)//Verificar que el email y clave exista utilizando el método privado 
                {
                    FormsAuthentication.SetAuthCookie("admin", false); //crea variable de usuario 
                    return RedirectToAction("Index", "Reporte");  //dirigir controlador home vista Index una vez se a autenticado en el sistema
                }
                else
                {
                    ModelState.AddModelError("", "Datos incorrectos"); //adicionar mensaje de error al model 
                }
            }
            return View(login);
        }

        //GET: Usuario/LogOff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Libro");
        }





        // GET: Administrador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administrador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrador/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Administrador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
