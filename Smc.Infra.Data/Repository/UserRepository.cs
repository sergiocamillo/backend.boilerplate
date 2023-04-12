using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Smc.Domain.Interfaces;
using Smc.Domain.Models;
using Smc.Infra.Data.Session;
using Dapper;
using System.Linq;
using System.Xml.Linq;

namespace Smc.Infra.Data.Repository 
{


    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DbSession session) : base(session)
        {

        }

        public User GetById(int id)
        {
            return QueryFirstOrDefault<User>("SELECT Id, Name, Email, BirthDate, ProfileId FROM [Users] where id = @id", new { id });
        }

        public User Login(string username, string password)
        {
            return QueryFirstOrDefault<User>("exec dbo.uspUserLogin @email, @password", new { email = username, password }) ;
        }

        public  IEnumerable<User> GetAll()
        {
            return Query<User>("exec uspUserRead", null);
        }

        public void Add(User user)
        {
           int result = Execute("exec dbo.uspUserCreate @Name, @Email, @Password, @ProfileId, @Birthdate", new { Name = user.Name, Email  = user.Email, Password = user.Password, ProfileId = user.Profile.Id, Birthdate = user.BirthDate });
        }


        public void Update(User user)
        {
            Execute("UPDATE [USERS] SET NAME= @Name, EMAIL=@Email, BIRTHDATE = @BirthDate WHERE ID = @Id)", user);
        }

        public void Remove(User user)
        {
            Execute("DELETE FROM [Users] WHERE ID = @Id", new { Id = user.Id });
        }

        public void Dispose()
        {
           
        }
    }
}
