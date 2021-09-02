using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCproject.Models
{

    public class StudentRepository:IStudentRepository
    {
       
     


        private List<Student> students = new List<Student>()   {
                new Student(){StudId=1,Name="TANMAY",Branch="CS",City="satara",Age=22},
                new Student(){StudId=2,Name="VINAYAK",Branch="CS",City="pune",Age=22},
                new Student(){StudId=3,Name="ATHARVA",Branch="CS",City="pune",Age=22},
                new Student(){StudId=4,Name="VEENA",Branch="CS",City="pune",Age=22},
                new Student(){StudId=5,Name="PRAJKTA",Branch="CS",City="sangli",Age=22},
                new Student(){StudId=6,Name="NIKET",Branch="CS",City="pune",Age=22}

            };
         


        public StudentRepository()
        {
            Console.WriteLine("Object Created.");

        }
        






        public bool CreateStudent(Student student)
        {
            try
            {
                int maxId = students.Select(s => s.StudId).Max();
                student.StudId = maxId + 1;
                students.Add(student);
            }catch(Exception E)
            {
                return false;
            }
            return true;
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                Student s = students.FirstOrDefault(s => s.StudId == id);
             



                students.Remove(s);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public Student GetStudentById(int id)
        {
             return students.FirstOrDefault(s => s.StudId == id);
            //FirstOrDefault returns the first element of the sequence that satisfies a condition or a default value if no such element found

            // return students.LastOrDefault(s => s.StudId == id);
            //LastOrDefault returns the last element of the sequence.  

           // return students.Last(s => s.StudId == id);
           //Last returns the last element of the sequence.



        }

        public List<Student> GetStudents()
        {
            return students;
            
        }

        public bool UpdateStudent(Student student)
        {
            try
            {
                Student s = students.FirstOrDefault(stu => stu.StudId == student.StudId);
              
                s.StudId = student.StudId;
                s.Name = student.Name;
                s.Branch = student.Branch;
                s.City = student.City;
                s.Age = student.Age;


            }
            catch (Exception)
            {
                return false;

            }
            return false;
        }
    }
}
