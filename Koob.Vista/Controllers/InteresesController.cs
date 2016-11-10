using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Koob.Dominio;
using Koob.Repositorio;
using fachada = Koob.Vista.Models;

namespace Koob.Vista.Controllers
{
    public class InteresesController : Controller
    {

        private InteresesRepository interesesRepository;

        // GET: Intereses
        public ActionResult Index()
        {
            interesesRepository = new InteresesRepository();
            var interesados = interesesRepository.quienSeIntereso(User.Identity.Name);
            return View(interesados);
        }

        // GET: Intereses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Intereses/Create
        public ActionResult ingresarInteres()
        {
            return View();
        }

        // POST: Deseo/Create
        [HttpPost]
        public ActionResult ingresarInteres(Dominio.Intereses interes)
        {
            var resultado = new JsonResult();
            try
            {
                interesesRepository = new InteresesRepository();

                bool seagrego = interesesRepository.agregarInteres(interes);
                if (seagrego)
                {
                    resultado.Data = new { mensaje = "Se ha agregado a su lista de interes" };
                }
                else
                {
                    resultado.Data = new { mensaje = "El libro se ha quitado de su lista de interes" };
                }
                return resultado;

            }
            catch
            {
                resultado.Data = new { mensaje = "ocurrio un error al agregar el libro a su lista de deseos" };
                return resultado;
            }
        }
        // GET: Intereses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Intereses/Edit/5
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

        // GET: Intereses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Intereses/Delete/5
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
