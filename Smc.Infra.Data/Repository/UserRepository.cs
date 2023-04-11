using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Smc.Domain.Interfaces;
using Smc.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Smc.Infra.Data.Session;
using Dapper;
using System.Linq;

namespace Smc.Infra.Data.Repository 
{


    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DbSession session) : base(session)
        {

        }

        public User GetById(int id)
        {
            return QueryFirstOrDefault<User>("SELECT * FROM [Users] where id = ", null);
        }

        public User Login(string username, string password)
        {
            return QueryFirstOrDefault<User>("SELECT * FROM [Users] where username = @username and password = @password", new { username, password });
        }

        public  IEnumerable<User> GetAll()
        {
            return Query<User>("SELECT * FROM [Users]", null);
        }

        public void Add(User User)
        {
            Execute("INSERT INTO [Notifications] VALUES(NEWID(), 'Title', 'URL', GETDATE())", null);
        }

        public void Update(User User)
        {
            Execute("INSERT INTO [Notifications] VALUES(NEWID(), 'Title', 'URL', GETDATE())", null);
        }

        public void Remove(User User)
        {
            Execute("INSERT INTO [Notifications] VALUES(NEWID(), 'Title', 'URL', GETDATE())", null);
        }

        public void Dispose()
        {
           
        }
    }
}
