using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}