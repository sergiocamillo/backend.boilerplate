using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Smc.Domain.Models;

namespace Smc.Domain.Interfaces
{
    public interface IUserRepository 
    {

        User GetById(int id);

        IEnumerable<User> GetAll();

        User Login(string username, string password);

        void Add(User User);

        void Update(User User);

        void Remove(User User);
       
    }
}
