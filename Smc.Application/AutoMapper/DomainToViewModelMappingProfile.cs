using AutoMapper;
using Smc.Application.ViewModels;
using Smc.Domain.Models;

namespace Smc.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Person, PersonViewModel>();
        }
    }
}
