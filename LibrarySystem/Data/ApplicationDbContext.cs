using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LibrarySystem.Data.Model;

namespace LibrarySystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
    }
    public class MemberDbContext : DbContext
    {
        public MemberDbContext(DbContextOptions<MemberDbContext> options)
            : base(options)
        {
        }
        public DbSet<LibrarySystem.Data.Model.Member> Member { get; set; }
        public DbSet<LibrarySystem.Data.Model.Librarian> Librarian { get; set; }

    }


}
