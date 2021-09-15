using LibrarySystem.DAL.Data;
using LibrarySystem.DAL.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LibrarySystem.Services.Services
{
    public interface IBookService
    {
        public Task<List<Book>> GetAllBooks();
        public Task<Book> GetBookById(int? id);
        public Task<bool> CreateBook(Book book);
        public Task Updatebook(Book book);
        public Task DeleteBook(int id);
        public bool BookExist(int id);
    }
    public class BookService : IBookService
    {
        public bool BookExist(int id)
        {
           using(var _context=new UserDbContext())
            {
                return _context.Books.Any(m => m.Id == id);
            }
        }

        public async Task<bool> CreateBook(Book book)
        {
            using(var _context=new UserDbContext())
            {
                try
                {
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task DeleteBook(int id)
        {
            using(var _context=new UserDbContext())
            {
                var book = await GetBookById(id);
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Book>> GetAllBooks()
        {
            using(var _context =new UserDbContext())
            {
                return await _context.Books.ToListAsync();
            }
        }

        public async Task<Book> GetBookById(int? id)
        {
            using(var _context=new UserDbContext())
            {
                return await _context.Books.FirstOrDefaultAsync(m => m.Id == id);
            }
        }

        public async Task Updatebook(Book book)
        {
            using(var _context=new UserDbContext())
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
