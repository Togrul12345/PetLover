using AutoMapper;
using PetLover.Bl.Dtos;
using PetLover.Bl.Services.Abstraction;
using PetLover.Core;
using PetLover.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Bl.Services.Implementation
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       
        public async Task Create(CreateMemberDto createMemberDto)
        {
           var result= _mapper.Map<Member>(createMemberDto);
           await _repository.CreateAsync(result);
           await _repository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
           var result=await _repository.GetById(id);
            _repository.Delete(result);
           await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Member>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Member> GetById(int id)
        {
           return await _repository.GetById(id);
        }

        public async Task Update(UpdateMemberDto updateMemberDto)
        {
            var result=_mapper.Map<Member>(updateMemberDto);
            _repository.Update(result);
           await _repository.SaveChangesAsync();
        }
    }
}
