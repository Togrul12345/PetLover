using PetLover.Bl.Dtos;
using PetLover.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Bl.Services.Abstraction
{
    public interface IMemberService
    {
        Task Create(CreateMemberDto createMemberDto);
        Task Update(UpdateMemberDto updateMemberDto);
        Task Delete(int id);
        Task<Member> GetById(int id);
        Task<IEnumerable<Member>> GetAll(); 

    }
}
