using PetLover.Core;
using PetLover.Data.Context;
using PetLover.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Data.Repositories.Implementation
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(AppDbContext context) : base(context)
        {
        }
    }
}
