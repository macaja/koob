using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Koob.Repositorio;

namespace Koob.Vista.Controllers
{
    public class BusquedaController : Controller
    {
        private DeseoRepository deseoRepository;
        private LibrosRepository libroRepository;
        private CategoriasRepository categoriaRepository;
        // GET: Busqueda
        public ActionResult Index()
        {
            return View();
        }

        // GET: Busqueda/PorTitulo/<titulo>
        public ActionResult PorTitulo(String titulo)
        {
            libroRepository = new LibrosRepository();
            var libro = libroRepository.obtenerLibroPorTitulo(titulo);
            return View(libro);
        }

        // GET: Busqueda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Busqueda/Create
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

        // GET: Busqueda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Busqueda/Edit/5
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

        // GET: Busqueda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Busqueda/Delete/5
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
