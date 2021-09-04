using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Data.Model
{
    public class Librarian
    {
        public string CollegeName { get; set; }
        [Key]
        public int LibId { get; set; }
    }
}
