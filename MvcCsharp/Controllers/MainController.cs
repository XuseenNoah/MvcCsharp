using MvcCsharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCsharp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        
        public ActionResult Index(string id)
        {
            //var person = new Persons();
            //var listPerons = person.GetListpersons();
            return View();
            //return PartialView("_Partial");
            //return Json();
            //var content = "Id=" + id;
            
          //  return Content(content);
            //return View();
            //return HttpNotFound();
        }

        public ActionResult ListPersons()
        {
            var person = new Persons();
            var listPerons = person.GetListpersons();
            return View(listPerons);
        }
    }
}