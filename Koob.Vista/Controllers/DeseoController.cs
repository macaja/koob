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
    public class DeseoController : Controller
    {
        DeseoRepository deseoRepository;
        // GET: Deseo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Deseo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Deseo/Create
        public ActionResult ingresarDeseo()
        {
            return View();
        }

        // POST: Deseo/Create
        [HttpPost]
        public ActionResult ingresarDeseo(Dominio.Deseo deseo)
        {
            var resultado = new JsonResult();
            try
            {
                deseoRepository = new DeseoRepository();
                bool seagrego=deseoRepository.agregarDeseo(deseo);
                if (seagrego)
                {
                    resultado.Data = new { mensaje = "Se ha agregado a su lista de deseos" };
                }
                else
                {
                    resultado.Data = new { mensaje = "El libro ya se encuentra en su lista de deseos" };
                }
                return resultado;

            }
            catch
            {
                resultado.Data = new { mensaje = "ocurrio un error al agregar el libro a su lista de deseos" };
                return resultado;
            }
        }

        // GET: Deseo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deseo/Edit/5
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

        // GET: Deseo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deseo/Delete/5
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
