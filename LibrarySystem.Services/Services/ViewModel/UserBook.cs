using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.DAL.Data.Model;

namespace LibrarySystem.ViewModel
{
    public class UserBook
    {
        //User
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        //Book
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookGenre { get; set; }
        public string BookAuthor { get; set; }

    }
}
