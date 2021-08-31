using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCproject.Models
{
   public interface IStudentRepository
    {
        public List<Student> GetStudents();

        public Student GetStudentById(int id);

        public bool CreateStudent(Student student);
        public bool UpdateStudent(Student student);

            
    }
}
