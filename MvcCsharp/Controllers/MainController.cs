using MvcCsharp.Models;
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
        Repository _repository = new Repository();
        //public ActionResult Index(string id)
        //{
        //    //var person = new Persons();
        //    //var listPerons = person.GetListpersons();
        //    return View();
        //    //return PartialView("_Partial");
        //    //return Json();
        //    //var content = "Id=" + id;
            
        //  //  return Content(content);
        //    //return View();
        //    //return HttpNotFound();
        //}

        public ActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomer(Customers customer)
        {
            if (ModelState.IsValid)
            {
                var getPhoneExist = _repository.GetCustomerPhone(customer.CustomerPhone);
                if (getPhoneExist == null)
                {
                    _repository.CreateCustomer(customer);
                    TempData["SuccesfullySaved"] = "Succesfully Saved Record";
                    return RedirectToAction("ListCustomers");
                }
                else
                {
                    TempData["PHoneExist"] = "Your phone is exist try to use another phone number";
                }
            }
            return View();
        }

        public ActionResult ListPersons()
        {
            var person = new Persons();
            var listPerons = person.GetListpersons();
            return View(listPerons);
        }
        
        public ActionResult ListCustomers(string customerName)
        {
            var listCustomers = _repository.ListPersons(customerName);
            return View(listCustomers);
        }
    }
}