using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using usuario = Koob.Dominio.Usuario;
using Koob.Repositorio;
using fachada = Koob.Vista.Models.RegisterViewModel;
using logInFacade = Koob.Vista.Models.LoginViewModel;
using System.Web.Security;

namespace Koob.Vista.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioRepository usuarioRepository;

        // GET: Usuario
        
        public ActionResult Index()
        {
            usuarioRepository = new UsuarioRepository();
            var usuarios = usuarioRepository.ObtenerUsuarios();
            return View(usuarios);
        }

        // GET: Usuario/Details/5
        
        public ActionResult Details(int id)
        {
            usuarioRepository = new UsuarioRepository();
            var empleado = usuarioRepository.ObtenerPorID(id);
            return View(empleado);
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
                usuarioRepository = new UsuarioRepository();
                var model = usuarioRepository.logueo(login.usu_correo, login.usu_password);

                if (model==true)//Verificar que el email y clave exista utilizando el método privado 
                {
                    FormsAuthentication.SetAuthCookie(login.usu_correo, false); //crea variable de usuario 
                    return RedirectToAction("Index", "Home");  //dirigir controlador home vista Index una vez se a autenticado en el sistema
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
            return RedirectToAction("Index", "Home");
        }


        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(fachada model)
        {
            try
            {
                usuarioRepository = new UsuarioRepository();
                //model.usu_codigo = 1;
                AutoMapper.Mapper.CreateMap<fachada, Dominio.Usuario>();
               var usu = AutoMapper.Mapper.Map<Dominio.Usuario>(model);
                usuarioRepository.InsertarUsuario(usu);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
