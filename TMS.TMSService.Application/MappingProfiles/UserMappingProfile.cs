using System;
using AutoMapper;
using TMS.TMSService.Application.DTOs;
using TMS.TMSService.Domain.Entities;

namespace TMS.TMSService.Application.MappingProfiles
{
	public class UserMappingProfile :Profile
	{
		public UserMappingProfile()
		{
			CreateMap<User, UserDto>().ReverseMap();
		}
	}
}

