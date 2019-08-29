using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;
using WebApi.ViewModel;

namespace WebApi
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dto => dto.UserRoles, opt => opt.MapFrom(x => x.UserRoles.Select(y => y.Role).ToList()));
            CreateMap<Role, RoleViewModel>()
                .ForMember(dto => dto.Permissions, opt => opt.MapFrom(x => x.RolePermissions.Select(y => y.Permission).ToList()));
            CreateMap<Permission, PermissionViewModel>();
            CreateMap<UserStatus, UserStatusViewModel>();
      //      Mapper.CreateMap<GoodEntity, GoodDTO>()
      //.ForMember(dto => dto.providers, opt => opt.MapFrom(x => x.GoodsAndProviders.Select(y => y.Providers).ToList()));

        }
    }
}
