using AutoMapper;
using Smc.Application.ViewModels;
using Smc.Domain.Models;

namespace Smc.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>()
                .ConstructUsing(c => new User(c.Id, c.Name, c.Email, c.BirthDate, c.ProfileId));
        }
    }
}
