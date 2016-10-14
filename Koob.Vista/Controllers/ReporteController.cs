using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using reporte = Koob.Dominio.Reporte;
using Koob.Repositorio;

namespace Koob.Vista.Controllers
{
    public class ReporteController : Controller
    {
        private ReporteRepository reporteRepository;
        // GET: Reporte
        public ActionResult Index()
        {
            reporteRepository = new ReporteRepository();
            var reportes = reporteRepository.ObtenerReportes();
            return View(reportes);
        }




        public ActionResult Reportar()
        {
            return View();
        }

        // POST: Deseo/Create
        [HttpPost]
        public ActionResult Reportar(Dominio.Reporte reporte)
        {
            var resultado = new JsonResult();
            try
            {
                reporteRepository = new ReporteRepository();
                reporte.adm_codigo = 1;
                bool seagrego = reporteRepository.agregarReporte(reporte);
                if (seagrego)
                {
                    resultado.Data = new { mensaje = "El libro ha sido reportado" };
                }
                else
                {
                    resultado.Data = new { mensaje = "Ya habia hecho un reporte de este libro" };
                }
                return resultado;

            }
            catch
            {
                resultado.Data = new { mensaje = "ocurrio un error al reportar el libro" };
                return resultado;
            }
        }

        // GET: Reporte/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reporte/Create
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

        // GET: Reporte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reporte/Edit/5
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

        // GET: Reporte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reporte/Delete/5
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
