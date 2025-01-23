using AutoMapper;
using PetLover.Bl.Dtos;
using PetLover.Bl.FileManager;
using PetLover.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Bl.Profiles
{
    public class MemberProfile:Profile
    {
        public MemberProfile()
        {
            CreateMap<CreateMemberDto, Member>().ForMember(a => a.ImgUrl, b => b.MapFrom(a => a.Img.ChangeToUrl("C:\\Users\\I Novbe\\source\\repos\\PetLover.Mvc\\PetLover.Mvc\\wwwroot\\", "Imgs")));
            CreateMap<UpdateMemberDto,Member>().ForMember(a => a.ImgUrl, b => b.MapFrom(a => a.Img.ChangeToUrl("C:\\Users\\I Novbe\\source\\repos\\PetLover.Mvc\\PetLover.Mvc\\wwwroot\\", "Imgs")));
            CreateMap<Member, UpdateMemberDto>().ForMember(a => a.Img, a => a.Ignore());
        }
    }
}
