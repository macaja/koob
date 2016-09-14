using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using usuario = Koob.Dominio.Usuario;
using Koob.Repositorio;

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

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Register /FALTA CONECTAR LA VISTA QUE GENERA MVC5 PREDETERMINDA
        // CON ESTE METODO, ya funciona pero accediendo desde otra vista mas rudimentaria.
        [HttpPost]
        public ActionResult Create(usuario model)
        {
            try
            {
                usuarioRepository = new UsuarioRepository();
                //model.usu_codigo = 1;
                usuarioRepository.InsertarUsuario(model);

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
