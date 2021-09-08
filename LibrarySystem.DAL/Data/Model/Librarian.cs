using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.DAL.Data.Model
{
    public class Librarian
    {
        [Key]
        public int LibId { get; set; }
        //  public int UserId { get; set; }
        public string CollegeName { get; set; }
    }
}
