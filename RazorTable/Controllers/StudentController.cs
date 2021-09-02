using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCproject.Models;

namespace MVCproject.Controllers
{   
    public class RepositoryInstance
    {
        public static IStudentRepository repository;

        static RepositoryInstance()
        {
            repository = new StudentRepository();
        }
    }
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repository = null;
        private readonly IStudentRepository _repository1 = null;




        public StudentController(IStudentRepository repository,IStudentRepository repository1)
        {
             
            _repository = repository;
            _repository1 = repository1;
           
        }
        // GET: StudentController

        public ActionResult Index()
        {

            return View(_repository.GetStudents());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.GetStudentById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                _repository.CreateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.GetStudentById(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                _repository.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.GetStudentById(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                _repository.DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
