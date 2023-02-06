using System;
using Memories.Models;

namespace Memories.Interfaces
{
	public interface IFamilyRepository
	{
		Task<IEnumerable<Family>> GetAll();

		Task<Family> GetByIdAsync(int id);

		Task<IEnumerable<Family>> GetFamilyByName(string familyName);

		bool Add(Family family);
		bool Update(Family family);
		bool Delete(Family family);
		bool Save();
	}
}

