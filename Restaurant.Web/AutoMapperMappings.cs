using System;
using AutoMapper;
using Restaurant.Data.Entities;

namespace Restaurant.Web
{
	public class AutoMapperMappings : Profile
	{
		public AutoMapperMappings()
		{
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<Role, RoleViewModel>().ReverseMap();

        }
    }
}

