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
    public interface IMemberService
    {
        public Task<List<Member>> GetAllMembers();
        public Task<Member> GetMemberById(int id);
        public Task<int> CreateMember(Member member);
        public Task<Member> UpdateMember(Member member);
    }
   public class MemberService : IMemberService
    {
        public async Task<int> CreateMember(Member member)
        {
            using (var Context = new MemberDbContext())
            {
                Context.Member.Add(member);

                return await Context.SaveChangesAsync();

            }

        }

        public async Task<List<Member>> GetAllMembers()
        {
            using (var context = new MemberDbContext())
            {

                return await context.Member.ToListAsync();
            }
        }

        public async Task<Member> GetMemberById(int id)
        {
            using (var Context = new MemberDbContext())
            {
                return await Context.Member.FirstOrDefaultAsync(s => s.UserId == id);
            }
        }

        public async Task<Member> UpdateMember(Member member)
        {
            using (var Context = new MemberDbContext())
            {
               
                Context.Update(member);
                await Context.SaveChangesAsync();
                return member;
            }
        }
    }
}
