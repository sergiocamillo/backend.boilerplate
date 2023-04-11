using System;
using System.Threading.Tasks;
using Smc.Domain.Interfaces;
using Smc.Domain.Models;
using Smc.Infra.Data.Session;

namespace Smc.Infra.Data.Repository
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {

        public PersonRepository(DbSession session): base(session)
        {

        }

        public Person GetById(long id)
        {
            return QueryFirstOrDefault<Person>("SELECT * FROM PERSONS WHERE ID = @ID", new { ID = id });
        }
    }
}
