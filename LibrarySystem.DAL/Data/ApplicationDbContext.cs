using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LibrarySystem.DAL.Data.Model;

namespace LibrarySystem.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


    }


    

    public class UserDbContext : DbContext
    {
        public UserDbContext()
        {

        }
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }
            public DbSet<User> Users { get; set; }
            public DbSet<Book> Books { get; set; }
            public DbSet<Borrow> Borrows { get; set; }
            //public DbSet<LibrarySystem.DAL.Data.Model.Member> Member { get; set; }
            //public DbSet<LibrarySystem.DAL.Data.Model.Librarian> Librarian { get; set; }
            //public DbSet<LibrarySystem.DAL.Data.Model.User> User { get; set; }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {

                    optionsBuilder.UseSqlServer("Server=LAPTOP-PTL9D25U\\SQLEXPRESS;Database=LibrarySystem;User Id=tanmay;Password=250830;");
                }
            }

        }


    }

