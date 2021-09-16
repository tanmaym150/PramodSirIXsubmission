using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.DAL.Data;
using LibrarySystem.DAL.Data.Model;
using LibrarySystem.Services.Services;

namespace LibrarySystem.Views
{
    public class BooksController : Controller
    {
        private readonly UserDbContext _context;
        private readonly IBookService _bookService;
        

        public BooksController(UserDbContext context,IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
            
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            // return View(await _context.Books.ToListAsync());
            ViewBag.Books =await _bookService.GetAllBooks();//passed data through viewbag
            return View(await _bookService.GetAllBooks());
            
        } 

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var books = await _context.Books
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var books = await _bookService.GetBookById(id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPostAttribute]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookName,BookGenre,BookAuthor")] Book books)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(books);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                bool result = await _bookService.CreateBook(books);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(books);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var books = await _context.Books.FindAsync(id);
            var books = await _bookService.GetBookById(id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookName,BookGenre,BookAuthor")] Book books)
        {
            if (id != books.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(books);
                    //await _context.SaveChangesAsync();
                    await _bookService.Updatebook(books);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.Id))
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
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var books = await _context.Books
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var books = await _bookService.GetBookById(id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var books = await _context.Books.FindAsync(id);
            //_context.Books.Remove(books);
            //await _context.SaveChangesAsync();
            await _bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
            //return _context.Books.Any(e => e.Id == id);
            return _bookService.BookExist(id);
        }
    }
}
