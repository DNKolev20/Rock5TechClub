using AutoMapper;
using UserManagement.Data.Models;
using UserManagement.Shared.Models.Input;
using UserManagement.Shared.Models.View;

namespace UserManagement.WebHost.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<User, UserVM>();
            this.CreateMap<UserIM, User>();
        }
    }
}
