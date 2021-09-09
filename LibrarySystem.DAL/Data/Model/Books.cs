using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibrarySystem.DAL.Data.Model
{
   public class Books
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookGenre { get; set; }
        public string BookAuthor { get; set; }


    }
}
