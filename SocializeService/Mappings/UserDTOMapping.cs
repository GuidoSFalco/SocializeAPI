using AutoMapper;
using SocializeData.Entities;
using SocializeService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocializeService.Mappings
{
    internal class UserDTOMapping : Profile
    {
        public UserDTOMapping()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
