using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryAddControllerWithView.Models
{
    public class TestStudentRepo: IStudentRepo
    {
        public List<Student> DataSource()
        {
            return new List<Student>()
            {
                new Student() { StudId = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudId = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
                new Student() { StudId = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudId = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
                new Student() { StudId = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
            };
        }
        public Student GetStudentById(int StudentId)
        {
            return DataSource().FirstOrDefault(e => e.StudId == StudentId);
        }
    }
}
    

