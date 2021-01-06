using AutoMapper;
using HX.Rider.Entity;
using HX.Rider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HX.Rider.API.AutoMapper
{
    /// <summary>
    /// AutoMapperProfile: Use to map domain object ot View model and reverse map 
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// AutoMapperProfile
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<UserEntity, UserModel>();
            CreateMap<UserDto, UserEntity>().ForAllMembers(opt => opt.Condition((src, dest, sourceMember) => sourceMember != null));
        }
    }
}
