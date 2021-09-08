using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.DAL.Data;
using LibrarySystem.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services.Services
{
    //public interface ILibrarianService
    //{
    //    public Task<Librarian> GetLibId(int id);
    //    public Task<Librarian> GetCollegeName();
    //   // public Task<List<Librarian>> GetAll();
    //}
    //public class LibrarianService : ILibrarianService
    //{
    //    //public async Task<List<Librarian>> GetAll()
    //    //{
    //    //   using (var Context=new MemberDbContext)
    //    //    {
    //    //        return await Context.Librarian.ToListAsync();
    //    //    }
    //    //}

    //    public async Task<Librarian> GetCollegeName()
    //    {
    //        using (var context = new MemberDbContext())
    //        {
    //            return await context.Librarian.FirstOrDefaultAsync();
    //        }
    //    }

    //    public async Task<Librarian> GetLibId(int id)
    //    {
    //        using (var context = new MemberDbContext())
    //        {
    //            return await context.Librarian.FirstOrDefaultAsync(m => m.LibId == id);
    //        }
    //    }
    //}
}
