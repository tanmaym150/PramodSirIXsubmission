using System;
using System.Collections.Generic;
using System.Linq;

namespace Student
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Standard { get; set; }

    }
    class Program

    {
     
        static void Main(string[] args)
        {
            List<StudentInfo> students = new List<StudentInfo>()
            {
                new StudentInfo(){Id=1,Name="TANMAY",Age=21,Standard=10},
                new StudentInfo(){Id=2,Name="VINAYAK",Age=22,Standard=12},
                new StudentInfo(){Id=3,Name="ATHARVA",Age=23,Standard=13},
            };
            int count = 0;
            
            
                foreach (var E in students)
                {
                    if (E.Age > 8)
                    {
                        Console.WriteLine("{0} greater than 8 years", E.Name);
                        count = count + 1;

                    }
                }
            


            Console.WriteLine("The total no of count of students greater than age  8 is {0}",count);

            var info = students.Where(s => s.Standard > 8).Select(s => new { Name = s.Name, Age = s.Age, Id = s.Id });
            foreach(var i in info)
            {
                Console.WriteLine(i.Name);
                Console.WriteLine(i.Id);
                Console.WriteLine(i.Age);
                Console.WriteLine(" ");
            }

            var res = students.Where(s => s.Standard > 11).Select(a => new { Name = a.Name, Id = a.Id }).OrderBy(o => o.Name);
            foreach(var e in res)
            {
                Console.WriteLine(e.Name);
                Console.WriteLine(e.Id);
            }
                
            
        }
    }
}
