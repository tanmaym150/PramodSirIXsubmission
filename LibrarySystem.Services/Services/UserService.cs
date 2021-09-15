using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.DAL.Data.Model;
using System.Linq;
using LibrarySystem.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUser();
        public Task<User> GetUserById(int? id);
        
        public Task<bool> CreateUser(User user);
        public Task UpdateUser(User user);
        public Task DeleteUser(int id);
        public bool UserExist(int id);
        


    }
    public class UserService : IUserService
    {
        public async Task<bool> CreateUser(User user)
        {
            using(var _context=new UserDbContext())
            {
                try
                {
                    _context.Add(user);
                   // _context.Add(book);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task DeleteUser(int id)
        {
            var user = await GetUserById(id);
            using(var _context=new UserDbContext())
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            using(var _context=new UserDbContext())
            {
                return await _context.Users.ToListAsync();
            }
        }



        public async Task<User> GetUserById(int? id)
        {
           using(var _context=new UserDbContext())
            {
                return await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
            }
        }

        public async Task UpdateUser(User user)
        {
            using(var _context=new UserDbContext())
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        public bool UserExist(int id)
        {
            using(var _context=new UserDbContext())
            {
                return _context.Users.Any(m => m.UserId == id);
            }
        }
    }
}
