using AutoMapper;
using GestaoUsuario.API.Models;
using GestaoUsuario.Domain.Entities;

namespace GestaoUsuario.API.Mappings
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserRequest, User>();
            CreateMap<UserResponse, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
