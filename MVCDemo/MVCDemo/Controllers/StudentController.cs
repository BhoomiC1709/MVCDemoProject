using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Data;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get All student details
        /// GET: Student/GetAllStudentDetails 
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {

            StudentData StuData = new StudentData();
            ModelState.Clear();
            return View(StuData.GetAllStudents());
        }

        // GET: Student/AddStudent   
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// To add Student Detail in DB
        /// </summary>
        /// <param name="Emp"></param>
        /// <returns></returns>

        // POST: Student/AddStudent 
     //   [HttpPost]
        //public ActionResult Create(Student Stu)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            StudentData StuData = new StudentData();

        //            if (StuData.AddStudent(Stu))
        //            {
        //                ViewBag.Message = "Student details added successfully";
        //            }
        //        }

        //        return View();
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        // POST: Student/EditStudentDetails/5    
       // [HttpPost]

        //public ActionResult Edit(int id, Student obj)
        //{
        //    try
        //    {
        //        StudentData StuData = new StudentData();

        //        StuData.UpdateStudent(obj);

        //        return RedirectToAction("Detail");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Student/DeleteStudent/5    
        public ActionResult Delete(int id)
        {
            try
            {
                StudentData StuData = new StudentData();
                if (StuData.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student details deleted successfully";

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