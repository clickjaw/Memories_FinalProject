
using System;
using Memories.Data;
using Memories.Interfaces;
using Memories.Models;
using Microsoft.EntityFrameworkCore;

namespace Memories.Repository
{
    public class FamilyMemberRepository : IFamilyMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public FamilyMemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(FamilyMember familyMember)
        {
            _context.Add(familyMember);
            return Save();
        }

        public bool Update(FamilyMember familyMember)
        {
            _context.Update(familyMember);
            return Save();
        }

        public bool Delete(FamilyMember familyMember)
        {
            _context.Remove(familyMember);
            return Save();
        }

        public async Task<IEnumerable<FamilyMember>> GetAll()
        {
            return await _context.FamilyMembers.ToListAsync();
        }

        public async Task<IEnumerable<FamilyMember>> GetAllMembersByFamily(string family)
        {
            return await _context.FamilyMembers.Where(c => c.LastName.Contains(family)).ToListAsync();
        }

        public async Task<FamilyMember> GetByIdAsync(int id)
        {
            return await _context.FamilyMembers.FirstOrDefaultAsync(i => i.Id == id);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }


    }
}

