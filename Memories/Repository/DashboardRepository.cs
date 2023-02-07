using System;
using Memories.Data;
using Memories.Interfaces;
using Memories.Models;

namespace Memories.Repository
{
	public class DashboardRepository: IDashboardRepository
	{
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Family>> GetAllUserFamilies()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userFamilies = _context.Families.Where(r => r.ApplicationUser.Id == curUser);
            return userFamilies.ToList();
        }
        public async Task<List<FamilyMember>> GetAllUserFamilyMembers()
        {
            var curUser = _httpContextAccessor.HttpContext?.User;
            var userFamilyMembers = _context.FamilyMembers.Where(r => r.ApplicationUser.Id == curUser.ToString());
            return userFamilyMembers.ToList();
        }
    }
}

