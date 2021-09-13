using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibrarySystem.DAL.Data.Model
{
    
  public class User
    {
        public User()
        {
            Borrows = new HashSet<Borrow>();
        }
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        [InverseProperty("Users")]
        public virtual ICollection<Borrow> Borrows { get; set; }

    }
}
