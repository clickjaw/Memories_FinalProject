using System;
using Memories.Models;

namespace Memories.Interfaces
{
	public interface IDashboardRepository
	{
		Task<List<Family>> GetAllUserFamilies();
		Task<List<FamilyMember>> GetAllUserFamilyMembers();
	}
}

