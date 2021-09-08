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
        //public DbSet<LibrarySystem.DAL.Data.Model.Member> Member { get; set; }
        //public DbSet<LibrarySystem.DAL.Data.Model.Librarian> Librarian { get; set; }
        //public DbSet<LibrarySystem.DAL.Data.Model.User> User { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=LibrarySystem;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

    }


}
