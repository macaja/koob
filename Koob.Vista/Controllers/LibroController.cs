using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using libro = Koob.Dominio.Libro;
using Koob.Repositorio;
using fachada = Koob.Vista.Models;


namespace Koob.Vista.Controllers
{
    public class LibroController : Controller
    {
        private LibrosRepository libroRepository;
        private CategoriasRepository categoriaRepository;

        // GET: Libro
        public ActionResult Index()
        {

            categoriaRepository = new CategoriasRepository();
            libroRepository = new LibrosRepository();
            var libros = libroRepository.ObtenerLibros();
            foreach (var item in libros)
            {
                item.lib_catNombre = categoriaRepository.ObtenerPorID(item.cat_codigo).cat_nombre;
            }
            return View(libros);
        }

        // GET: Libro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Libro/Create
        public ActionResult Ingresar()
        {
            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Ingresar(fachada.Libro model)
        {
            try
            {
                var t = User.Identity.Name;
                model.usu_email = t;
                libroRepository = new LibrosRepository();
                //model.usu_codigo = 1;
                AutoMapper.Mapper.CreateMap<fachada.Libro, libro>();
                var lib = AutoMapper.Mapper.Map<libro>(model);
                libroRepository.InsertarLibro(lib);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Libro/Edit/5
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

        // GET: Libro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Libro/Delete/5
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
