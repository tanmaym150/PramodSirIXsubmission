using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.DAL.Data;
using LibrarySystem.DAL.Data.Model;
using static LibrarySystem.DAL.Data.UserDbContext;
using LibrarySystem.Services.Services;
using LibrarySystem.ViewModel;

namespace LibrarySystem.Views
{
    public class UsersController : Controller
    {
        private readonly UserDbContext _context;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IBorrowService _borrowService;

        public UsersController(UserDbContext context, IUserService userService,IBookService bookService,IBorrowService borrowService)
        {
            _context = context;
            _userService = userService;
            _bookService = bookService;
            _borrowService = borrowService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllUser());
            
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            //var user = await _context.Users
            //    .FirstOrDefaultAsync(m => m.UserId == id);
            // var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);


            var user = await _borrowService.GetBorrowDetailsByUserId(id);
            //var book = await _borrowService.GetBorrowDetailsByBookId(id);
            

            //user view model for book name,genre
             //var book = await _userService.GetBookById(id);
            


            //viewmodel
            UserBook userBook = new UserBook()
            {
                BookName = user.Books.BookName,
                BookGenre = user.Books.BookGenre,
                UserId = user.Users.UserId,
                FirstName=user.Users.FirstName,
                LastName=user.Users.LastName,
                Email=user.Users.Email,
                Gender=user.Users.Gender


                    

            };


            if (userBook == null)
            {
                return NotFound();
            }

            return View(userBook);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,Email,Gender")] User user)
        {
            if (ModelState.IsValid)
            {
                bool result = await _userService.CreateUser(user);
                //_context.Add(user);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,Email,Gender")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(user);
                    //await _context.SaveChangesAsync();
                    await _userService.UpdateUser(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var user = await _context.Users
            //    .FirstOrDefaultAsync(m => m.UserId == id);
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var user = await _context.Users.FindAsync(id);
            //_context.Users.Remove(user);
            //await _context.SaveChangesAsync();
            await _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            // return _context.Users.Any(e => e.UserId == id);
            return _userService.UserExist(id);
        }
    }
}
