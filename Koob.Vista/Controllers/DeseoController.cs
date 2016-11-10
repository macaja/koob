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
        private DeseoRepository deseoRepository;
        private CategoriasRepository categoriaRepository;
        // GET: Deseo
        public ActionResult ListaDeseos()
        {
            categoriaRepository = new CategoriasRepository();
            deseoRepository = new DeseoRepository();
            var deseos = deseoRepository.listaDeDeseos(User.Identity.Name);
            foreach (var item in deseos)
            {
                item.lib_catNombre = categoriaRepository.ObtenerPorID(item.cat_codigo).cat_nombre;
            }
            
            return View(deseos);
        }

        // GET: Deseo/usuario/5
        public ActionResult usuario(string email)
        {
            categoriaRepository = new CategoriasRepository();
            deseoRepository = new DeseoRepository();
            var deseos = deseoRepository.listaDeDeseos(email);
            foreach (var item in deseos)
            {
                item.lib_catNombre = categoriaRepository.ObtenerPorID(item.cat_codigo).cat_nombre;
            }

            return View("ListaDeseos", deseos);
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
                    resultado.Data = 1;
                    return Json("1");
                }
                else
                {
                    resultado.Data = 0;
                    return Json("0");
                }
                //return resultado;

            }
            catch
            {
                resultado.Data = new { mensaje = "ocurrio un error al agregar el libro a su lista de intereses" };
                return Json("error");
            }
        }



        public ActionResult verifyDeseo()
        {
            return View();
        }

        // POST: Deseo/Create
        [HttpPost]
        public ActionResult verifyDeseo(Dominio.Deseo deseo)
        {
            var resultado = new JsonResult();
            try
            {
                deseoRepository = new DeseoRepository();

                int esta = deseoRepository.verificarDocumentReady(deseo.usu_email, deseo.lib_codigo);
                if (esta == 1)
                {
                    return Json("1");
                }
                else
                {
                    return Json("0");
                }


            }
            catch
            {
                resultado.Data = new { mensaje = "ocurrio un error al buscar si estaba en su lista de intereses" };
                return Json("Error");
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
