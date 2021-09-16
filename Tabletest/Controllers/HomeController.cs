using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tabletest.Models;

namespace Tabletest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<Employee> employees;

        public object ConfigurationManager { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            employees = new List<Employee>();
            employees.Add(new Employee { EmpId = 1, Name = "TANMAY", Cname = "IX", Salary = 8000, City = "Pune" });
            employees.Add(new Employee { EmpId = 2, Name = "NIKET", Cname = "BIENCAPS", Salary = 33000, City = "Pune" });
            employees.Add(new Employee { EmpId = 3, Name = "DAMODAR", Cname = "PERSISTENT", Salary = 32000, City = "Pune" });
            employees.Add(new Employee { EmpId = 4, Name = "ANIKET", Cname = "CAOGNIZANT", Salary = 30000, City = "SATARA" });
            employees.Add(new Employee { EmpId = 5, Name = "PREM", Cname = "BITWISE", Salary = 28000, City = "KOREGAON" });

            _logger = logger;
        }
        string Name = "Tanmay";
        public IActionResult Index()
        {


            ViewData["employeees"] = employees;
            ViewBag.TotalEmployees = employees.Count();
            ViewBag.Name = Name;
            return View(employees);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        }
    }


