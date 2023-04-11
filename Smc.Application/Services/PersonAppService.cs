using AutoMapper;
using Smc.Application.Interfaces;
using Smc.Application.ViewModels;
using Smc.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Smc.Application.Services
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        public PersonAppService(IMapper mapper,
            IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public PersonViewModel GetById(long id)
        {
            return _mapper.Map<PersonViewModel>(_personRepository.GetById(id));

        }
    }
}
