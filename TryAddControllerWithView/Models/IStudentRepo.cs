using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryAddControllerWithView.Models
{
    interface IStudentRepo
    {
        Student GetStudentById(int StudentId);
    }
}
