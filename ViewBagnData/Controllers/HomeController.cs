using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewBagnData.Models;

namespace ViewBagnData.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult EmployeeList()
        {
            var employeeModel = new List<EmployeeModel>();
            employeeModel.Add(new EmployeeModel() { EmpID = 101, EmpFirstName = "Surya", EmpLastName = "Kranthi" });
            employeeModel.Add(new EmployeeModel() { EmpID = 102, EmpFirstName = "Aditya", EmpLastName = "Roy" });
            employeeModel.Add(new EmployeeModel() { EmpID = 103, EmpFirstName = "Ravi", EmpLastName = "Kanth" });
            employeeModel.Add(new EmployeeModel() { EmpID = 104, EmpFirstName = "Anshuman", EmpLastName = "Sagara" });
            employeeModel.Add(new EmployeeModel() { EmpID = 105, EmpFirstName = "Jhansi", EmpLastName = "Naari" });

            //Example 1 Using ViewBag
            ViewBag.EmployeeList1 = employeeModel;

            ////Example 2 Using ViewData
            //ViewData["EmployeeList2"] = employeeModel;

            ////Example 3 Using TempData
            //TempData["EmployeeList3"] = employeeModel;

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
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