using AutoMapper;
using PetLover.Bl.Dtos;
using PetLover.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Bl.Profiles
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<CreateUserDto, AppUser>();
        }
    }
}
