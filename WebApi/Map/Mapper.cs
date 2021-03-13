using AutoMapper;
using Entity.DTOS;
using Entity.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Map
{
    public class Mapper : Profile
    {
        public Mapper()
        {

            CreateMap<Users, UserListDto>();
            CreateMap<UserListDto, Users>();

            CreateMap<Users, UserAddDto>();
            CreateMap<UserAddDto, Users>();

            CreateMap<Users, UserUpdateDto>();
            CreateMap<UserUpdateDto, Users>();

        }
    }
}
