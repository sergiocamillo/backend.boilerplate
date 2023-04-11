using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Smc.Domain.Interfaces;
using Smc.Domain.Models;
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
            return QueryFirstOrDefault<User>("SELECT * FROM [Users] where id = @id", new { id });
        }

        public User Login(string username, string password)
        {
            return QueryFirstOrDefault<User>("SELECT * FROM [Users] where EMAIL = @username and PASSWORD = @password", new { username, password });
        }

        public  IEnumerable<User> GetAll()
        {
            return Query<User>("SELECT * FROM [Users]", null);
        }

        public void Add(User user)
        {
            Execute("INSERT INTO [Users] VALUES(@Name, @Email, @BirthDate, @Password)", user);
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
