using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Data;

namespace MVCDemo.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            PersonData personData = new PersonData();
            ModelState.Clear();
            return View(personData.GetPersons());

        }
        // GET: Perosn/GetAllPerosons    
        //public ActionResult Detail()
        //{
        //    var personData = new MVCDemo.Data.PersonData();

        //    //PersonData personData = new PersonData();
        //    //ModelState.Clear();
        //    return View(PrData.GetAllEmployees());
        //}

        // GET: Employee/AddEmployee    
        public ActionResult Create()
        {
            return View();
        }



        // POST: Employee/AddEmployee    
        //  [HttpPost]
        //public ActionResult Create(Employee Emp)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            EmployeeData EmpData = new EmployeeData();

        //            if (EmpData.AddEmployee(Emp))
        //            {
        //                ViewBag.Message = "Employee details added successfully";
        //            }
        //        }

        //        return View();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}



    }
}