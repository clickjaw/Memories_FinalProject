//using System;
//using Memories.Data;
//using Memories.Interfaces;
//using Memories.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Memories.Repository
//{
//	public class FamilyRepository:IFamilyRepository
//	{
//        private readonly ApplicationDbContext _context;

//        public FamilyRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }
//        public bool Add(Family family)
//        {
//            _context.Add(family);
//            return Save();
//        }

//        public bool Update(Family family)
//        {
//            throw new NotImplementedException();
//        }

//        public bool Delete(Family family)
//        {
//            _context.Remove(family);
//            return Save();
//        }

//        public bool Save()
//        {
//            var saved = _context.SaveChanges();
//            return saved > 0 ? true: false; 
//        }

//        public async Task<IEnumerable<Family>> GetMemberByName(string familymembername)
//        {
//            return await _context.Families.Where(c => c.FamilyMemberName.Contains(familymembername)).ToListAsync();
//        }

//        public async Task<IEnumerable<Family>> GetAll()
//        {
//            //return await _context.Families.ToListAsync();
//            return await _context.Families.ToListAsync();


//        }

//        public async Task<Family> GetByIdAsync(int id)
//        {
//            return await _context.Families.Include(m => m.FamilyMember.Id).FirstOrDefaultAsync(i => i.Id == id);
//        }


//    }
//}

