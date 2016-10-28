 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Koob.Repositorio;

namespace Koob.Vista.Controllers
{
    public class PopularesController : Controller

    {

        private DeseoRepository deseoRepository;
        private CategoriasRepository categoriaRepository;

        // GET: Populares
        public ActionResult Index()
        {

            categoriaRepository = new CategoriasRepository();
            deseoRepository = new DeseoRepository();
            var libros = deseoRepository.librosPopulares();
            foreach (var item in libros)
            {
                item.lib_catNombre = categoriaRepository.ObtenerPorID(item.cat_codigo).cat_nombre;
            }
            return View(libros);
        }

        // GET: Populares/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Populares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Populares/Create
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

        // GET: Populares/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Populares/Edit/5
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

        // GET: Populares/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Populares/Delete/5
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
