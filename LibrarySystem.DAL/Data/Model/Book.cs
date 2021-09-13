using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibrarySystem.DAL.Data.Model
{
    
    public class Book
    {
        public Book()
        {
            Borrows  = new HashSet<Borrow>();
        }
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookGenre { get; set; }
        public string BookAuthor { get; set; }
        [InverseProperty("Books")]
        public virtual ICollection<Borrow> Borrows { get; set; }

    }
}
