using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Koob.Vista.Controllers
{
    public class FotoController : Controller
    {
        // GET: Foto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Foto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Foto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Foto/Create
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

        // GET: Foto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Foto/Edit/5
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

        // GET: Foto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Foto/Delete/5
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
