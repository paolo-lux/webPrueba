using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webPrueba.DataAccess.Catalogs;
using webPrueba.Models;

namespace webPrueba.Controllers
{
    public class MeditionController : Controller
    {
        // GET: Metition
        public ActionResult Index()
        {
            Meditions model = new Meditions();
            model.lSintomas =  daSymptom.GetSymptomsAllRev();
            return View(model);
        }
    }
}