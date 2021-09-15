using LibrarySystem.DAL.Data;
using LibrarySystem.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.ViewModel;
using System.Linq;

namespace LibrarySystem.Services.Services
{
    public interface IBorrowService
    {
        public Task <List<Borrow>>GetAllBorrows();
        public Task <Borrow> GetBorrowById(int? id);
        public Task<bool> CreateBorrow(Borrow borrow);
        public Task UpdateBorrow(Borrow borrow);
        public Task DeleteBorrow(int id);
        public bool BorrowExits(int id);
        public Task<Borrow> GetBorrowDetailsByBookId(int? id);
        public Task<Borrow> GetBorrowDetailsByUserId(int? id);
        
    }
    public class BorrowService : IBorrowService
    {
        public bool BorrowExits(int id)
        {
            using(var _context=new UserDbContext())
            {
                return _context.Borrows.Any(m => m.ID == id);
            }
        }

        public async Task<bool> CreateBorrow(Borrow borrow)
        {
            using(var _context=new UserDbContext())
            {
                try
                {
                    _context.Add(borrow);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
            
        }

        public async Task DeleteBorrow(int id)
        {
            var borrow = await GetBorrowById(id);
            using(var _context =new UserDbContext())
            {
                _context.Borrows.Remove(borrow);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Borrow>> GetAllBorrows()
        {
            using (var _context =new UserDbContext())
            {
                var joinContext = _context.Borrows.Include(a => a.Books).Include(a => a.Users);
                return await joinContext.ToListAsync();
               // return await _context.Borrows.ToListAsync();
            }
        }

        public async Task<Borrow> GetBorrowById(int? id)
        {
            using(var _context=new UserDbContext())
            {
                var joinContext = _context.Borrows.Include(a => a.Books).Include(a => a.Users);
                return await joinContext.FirstOrDefaultAsync(a => a.ID == id);
               // return await _context.Borrows.FirstOrDefaultAsync(m => m.ID == id);
            }
        }

        public async Task<Borrow> GetBorrowDetailsByBookId(int? id)
        {
            using(var _context=new UserDbContext())
            {
                var joinContext = _context.Borrows.Include(a => a.Books);
                return await joinContext.FirstOrDefaultAsync(a => a.Books.Id == id);
            }
        }

        public async Task<Borrow> GetBorrowDetailsByUserId(int? id)
        {
           using(var _context=new UserDbContext())
            {
                var joinContext = _context.Borrows.Include(a => a.Users).Include(a=>a.Books);
                return await joinContext.FirstOrDefaultAsync(a=>a.Users.UserId==id);
            }
        }

        public async Task UpdateBorrow(Borrow borrow)
        {
            using(var _context=new UserDbContext())
            {
                _context.Update(borrow);
                await _context.SaveChangesAsync();
            }
        }
    }
}
