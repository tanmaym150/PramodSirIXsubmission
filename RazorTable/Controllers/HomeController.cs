using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RazorTable.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<Member> members;
        public HomeController(ILogger<HomeController> logger)
        {
            members = new List<Member>();
            members.Add(new Member { ID=1,Name="tanmay",Branch="CSE", City="Satara" });
            members.Add(new Member { ID=2,Name="atharva",Branch="CSE", City="Pune" });
            members.Add(new Member { ID=3,Name="vinayak", Branch="CSE", City="Pune" });
            members.Add(new Member { ID=4,Name="veena", Branch="CSE", City="Ratnagiri" });
            members.Add(new Member { ID=5, Name="prajakta", Branch="CSE", City="Karad" });



            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(members);
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
