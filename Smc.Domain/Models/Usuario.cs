using System;

namespace Smc.Domain.Models
{
    public class User
    {
        public User()
        {

        }

        public User(int id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; private set; }


    }
}
