using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibrarySystem.DAL.Data.Model
{
    
   public class Borrow
    {

        [Key]
        public int ID { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public bool isReturned { get; set; }


        [ForeignKey(nameof(BookId))]
        [InverseProperty("Borrows")]
        public virtual Book Books { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Borrows")]
        public virtual User Users { get; set; }

    }
}
