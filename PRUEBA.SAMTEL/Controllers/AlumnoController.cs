using System;
using System.Collections.Generic;
using System.Linq;
using PRUEBA.SAMTEL.Models;
    using System.Web.Mvc;

namespace PRUEBA.SAMTEL.Controllers
{
    public class AlumnoController : Controller
    {
        public ViewResult Index()
        {
            return View(Data.AlumnoData.Listar());
        }
        public ActionResult Create()
        {
            this.ViewBag.TipoIdentificacionId = new SelectList(Data.TipoIdentificacionData.Listar(), "TipoIdentificacionId", "TipoIdentificacionNombre");
            return View();
        }
        public ActionResult RegisterNote(Int64 alumnoId)
        {
            this.ViewBag.MateriaId = new SelectList(Data.MateriaData.Listar(), "MateriaId", "MateriaNombre");
            return View();
        }
        [HttpPost]
        public ActionResult RegisterNote(Int64 alumnoId, AlumnoMateria alumno)
        {
            if (ModelState.IsValid)
            {
                alumno.AlumnoId= alumnoId;
                Data.AlumnoMateriaData.Registrar(alumno);

                return RedirectToAction("Index");
            }
            this.ViewBag.MateriaId = new SelectList(Data.MateriaData.Listar(), "MateriaId", "MateriaNombre");
            return View(alumno);
        }
        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                Data.AlumnoData.Registrar(alumno);

                return RedirectToAction("Index");
            }

            this.ViewBag.TipoIdentificacionId = new SelectList(Data.TipoIdentificacionData.Listar(), "TipoIdentificacionId", "TipoIdentificacionNombre");
            return View(alumno);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}