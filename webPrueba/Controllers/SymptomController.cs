using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webPrueba.DataAccess.Catalogs;
using webPrueba.Models;

namespace webPrueba.Controllers
{
    public class SymptomController : Controller
    {
        // GET: Symptom
        public ActionResult Index()
        {
            List<SymptomVM> lvm = new List<SymptomVM>();
            lvm = daSymptom.GetSymptomsAll();
            return View(lvm);
        }

        public ActionResult Edit(string Id)
        {

            SymptomVM vm = new SymptomVM();
            vm = daSymptom.GetSymptomsById(int.Parse(Id));
            return View(vm);
        }
    }
}