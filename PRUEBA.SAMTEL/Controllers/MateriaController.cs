using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRUEBA.SAMTEL.Models;

namespace PRUEBA.SAMTEL.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult Index()
        {
            return View(Data.MateriaData.Listar());
        }

        // GET: Materia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Materia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materia/Create
        [HttpPost]
        public ActionResult Create(Materia materia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Data.MateriaData.Registrar(materia);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Materia/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Materia/Edit/5
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

        // GET: Materia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Materia/Delete/5
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
