using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.DAL.Data;
using LibrarySystem.DAL.Data.Model;
using LibrarySystem.ViewModel;
using LibrarySystem.Services.Services;

namespace LibrarySystem.Controllers
{
    
    public class MembersController : Controller
    {
        private readonly MemberDbContext _context;
        private readonly IMemberService _memberService;
        private readonly ILibrarianService _librarianService;


        

        


        public MembersController(MemberDbContext context,IMemberService memberService,ILibrarianService librarianService)
        {
            _context = context;
            _memberService = memberService;
            _librarianService = librarianService;
            
            
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _memberService.GetAllMembers() );
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            //var member = await _context.Member
            //    .FirstOrDefaultAsync(m => m.UserId == id);
            //var librarian = await _context.Librarian
            //    .FirstOrDefaultAsync(m => m.LibId == id);

            var member = await _memberService.GetMemberById( id);
            var librarian = await _librarianService.GetLibId(id);
            MemberLibrarianViewModel memberLibrarianViewModel = new MemberLibrarianViewModel() { Member=member,Librarian=librarian};
           
            if ((member == null))
            {
                return NotFound();
            }

            return View(memberLibrarianViewModel);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,Gender,ContactNumber,Email,password")] Member member,[Bind("LibId,CollegeName")] Librarian librarian )
        {
            if (ModelState.IsValid)
            {

                _context.Librarian.Add(librarian);



                 _context.Member.Add(member);
                var memberRes = await _memberService.CreateMember(member);
              
                

               // await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,LastName,Gender,ContactNumber,Email,password")] Member member, [Bind("CollegeName")] Librarian librarian)
        {
            if (id != member.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(member);
                    //_context.Update(librarian);
                    //await _context.SaveChangesAsync();
                    var memberRes = await _memberService.UpdateMember(member);
                
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.UserId))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.UserId == id);
            var libraian = await _context.Librarian
                .FirstOrDefaultAsync(m => m.LibId == id);
            MemberLibrarianViewModel memberLibrarianViewModel = new MemberLibrarianViewModel() { Member=member,Librarian=libraian};
            if (member == null)
            {
                return NotFound();
            }

            return View(memberLibrarianViewModel);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Member.FindAsync(id);
            _context.Member.Remove(member);
            var librarian = await _context.Librarian.FindAsync(id);
            _context.Librarian.Remove(librarian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.UserId == id);
        }
    }
}
