using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using libro = Koob.Dominio.Libro;
using Koob.Repositorio;
using System.Net;
using Newtonsoft.Json;
using fachada = Koob.Vista.Models;
using servicio = Koob.Vista.Models.API;


namespace Koob.Vista.Controllers
{
    public class LibroController : Controller
    {
        private DeseoRepository deseoRepository;
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
            categoriaRepository = new CategoriasRepository();
            libroRepository = new LibrosRepository();
            var libro = libroRepository.obtenerLibPorID(id);
            return View(libro);
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
            string url = @"https://www.googleapis.com/books/v1/volumes?q=isbn:9788479538200";
            var json = new WebClient().DownloadString(url);
            servicio.Libro libros = JsonConvert.DeserializeObject<servicio.Libro>(json);
            try
            {
                int totalItems = libros.totalItems;
                if (totalItems < 1)
                {
                    return View(model);
                }
                else
                {
                    var t = User.Identity.Name;
                    var autores = libros.items[0].volumeInfo.authors[0];
                    var imagen = libros.items[0].volumeInfo.imageLinks.thumbnail;
                    var sinopsis = libros.items[0].volumeInfo.description;
                    model.usu_email = t;                    
                    libroRepository = new LibrosRepository();
                    AutoMapper.Mapper.CreateMap<fachada.Libro, libro>();
                    var lib = AutoMapper.Mapper.Map<libro>(model);
                    lib.lib_autores = autores;
                    lib.lib_imagen = imagen;
                    lib.lib_sinopsis = sinopsis;
                    libroRepository.InsertarLibro(lib);
                    return RedirectToAction("Index");
                }                
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
            try
            {
                // TODO: Add update logic here
                libroRepository = new LibrosRepository();
                deseoRepository = new DeseoRepository();
                ReporteRepository reporteRepo = new ReporteRepository();
                deseoRepository.eliminarDeseosPorLibReportado(id);
                reporteRepo.eliminarReporteID(id);
                libroRepository.eliminarLibroID(id);
                return RedirectToAction("Index", "Reporte");
            }
            catch
            {
                return RedirectToAction("Index", "Reporte");
            }
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
