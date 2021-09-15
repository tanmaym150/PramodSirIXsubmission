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
    public class BorrowsController : Controller
    {
        private readonly UserDbContext _context;
        private readonly IBorrowService _borrowService;

        public BorrowsController(UserDbContext context,IBorrowService borrowService)
        {
            _context = context;
            _borrowService = borrowService;
        }

        // GET: Borrows
        public async Task<IActionResult> Index()
        {
            // var userDbContext = _context.Borrows.Include(b => b.Users).Include(b => b.Books);

            // return View(await userDbContext.ToListAsync());
            return View(await _borrowService.GetAllBorrows());
        }

        // GET: Borrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var borrow = await _borrowService.GetBorrowById(id); 
             
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // GET: Borrows/Create
        public IActionResult Create()
        {
          
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FirstName");
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "BookName");
            return View();
        }

        // POST: Borrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BookId,UserId,isReturned")] Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                bool result = await _borrowService.CreateBorrow(borrow);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                //_context.Add(borrow);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FirstName",borrow.ID);
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "BookName",borrow.ID);

            return View(borrow);
        }

        // GET: Borrows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", borrow.UserId);
           
            return View(borrow);
        }

        // POST: Borrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BookId,UserId,isReturned")] Borrow borrow)
        {
            if (id != borrow.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(borrow);
                    //await _context.SaveChangesAsync();
                    await _borrowService.UpdateBorrow(borrow);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowExists(borrow.ID))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", borrow.UserId);
           
            return View(borrow);
        }

        // GET: Borrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var borrow = await _context.Borrows
            //    .Include(b => b.Users)
            //    .FirstOrDefaultAsync(m => m.ID == id);
            var borrow = await _borrowService.GetBorrowById(id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrow = await _context.Borrows.FindAsync(id);
            _context.Borrows.Remove(borrow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowExists(int id)
        {
           // return _context.Borrows.Any(e => e.ID == id);
           return _borrowService.BorrowExits(id);
        }
    }
}
