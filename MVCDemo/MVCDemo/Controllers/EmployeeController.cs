using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/GetAllEmpDetails    
        public ActionResult Detail()
        {

            EmployeeData EmpData = new EmployeeData();
            ModelState.Clear();
            return View(EmpData.GetAllEmployees());
        }

        // GET: Employee/AddEmployee    
        public ActionResult Create()
        {
            return View();
        }



        // POST: Employee/AddEmployee    
        [HttpPost]
        public ActionResult Create(Employee Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeData EmpData = new EmployeeData();

                    if (EmpData.AddEmployee(Emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/EditEmpDetails/5    
        public ActionResult Edit(int id)
        {
            EmployeeData EmpData = new EmployeeData();

            return View(EmpData.GetAllEmployees().Find(Employee => Employee.EmpId == id));

        }

        // POST: Employee/EditEmpDetails/5    
        [HttpPost]

        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                EmployeeData EmpData = new EmployeeData();

                EmpData.UpdateEmployee(obj);

                return RedirectToAction("Detail");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5    
        public ActionResult Delete(int id)
        {
            try
            {
                EmployeeData EmpData = new EmployeeData();
                if (EmpData.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("Detail");

            }
            catch
            {
                return View();
            }
        }

    }
}