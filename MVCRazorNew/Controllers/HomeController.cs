using MVCRazorNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRazorNew.Controllers
{

    public class HomeController : Controller
    {
        private List<Employee> emp;
        public HomeController()
        {
            emp = new List<Employee>()
        {
            new Employee()
            { EmployeeId =1,FirstName="Rakesh",LastName="Kalluri", Email="raki.kalluri@gmail.com", Salary=30000, Company="Summit", Dept="IT" },
            new Employee()
            { EmployeeId =2,FirstName="Naresh",LastName="C", Email="Naresh.C@gmail.com", Salary=50000, Company="IBM", Dept="IT" },
            new Employee()
            { EmployeeId =3,FirstName="Madhu",LastName="K", Email="Madhu.K@gmail.com", Salary=20000, Company="HCl", Dept="IT" },
            new Employee()
            { EmployeeId =4,FirstName="Ali",LastName="MD", Email="Ali.MD@gmail.com", Salary=26700, Company="Tech Mahindra", Dept="BPO" },
            new Employee()
            { EmployeeId =5,FirstName="Chithu",LastName="Raju", Email="Chithu.Raju@gmail.com", Salary=25000, Company="Dell", Dept="BPO" },
            new Employee()
            { EmployeeId =6,FirstName="Nani",LastName="Kumar", Email="Nani.Kumar@gmail.com", Salary=24500, Company="Infosys", Dept="BPO" },

        };
        }
        public ActionResult Index()
        {

            return View(emp);
        }
    }
}