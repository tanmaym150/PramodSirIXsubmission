using System.Collections.Generic;
using System.Linq;

namespace MVCproject.Models
{

    public class StudentRepository:IStudentRepository
    {
        private List<Student> students;
        

        public StudentRepository()
        {
            students = new List<Student>
            {
                new Student(){StudId=1,Name="TANMAY",Branch="CS",City="satara",Age=22},
                new Student(){StudId=2,Name="VINAYAK",Branch="CS",City="pune",Age=22},
                new Student(){StudId=3,Name="ATHARVA",Branch="CS",City="pune",Age=22},
                new Student(){StudId=4,Name="VEENA",Branch="CS",City="pune",Age=22},
                new Student(){StudId=5,Name="PRAJKTA",Branch="CS",City="sangli",Age=22},
                new Student(){StudId=6,Name="NIKET",Branch="CS",City="pune",Age=22}

            };
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.StudId == id);
        }

        public List<Student> GetStudents()
        {
            return students;
            
        }
    }
}
