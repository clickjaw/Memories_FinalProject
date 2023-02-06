using System;
using Memories.Models;

namespace Memories.Interfaces
{
    public interface IFamilyMemberRepository
    {
        Task<IEnumerable<FamilyMember>> GetAll();
        Task<FamilyMember> GetByIdAsync(int id);
        Task<IEnumerable<FamilyMember>> GetAllMembersByFamily(string family);

        bool Add(FamilyMember familyMember);
        bool Update(FamilyMember familyMember);
        bool Delete(FamilyMember familyMember);
        bool Save();
    }
}

