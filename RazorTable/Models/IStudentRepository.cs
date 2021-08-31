using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCproject.Models
{
    interface IStudentRepository
    {
        public List<Student> GetStudents();

        public Student GetStudentById(int id);
    }
}
