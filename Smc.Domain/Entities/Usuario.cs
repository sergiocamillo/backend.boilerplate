using Smc.Domain.Entities;
using System;

namespace Smc.Domain.Models
{
    public class User
    {
        public User()
        {

        }

        public User(Guid id, string name, string email, DateTime birthDate, Guid ProfileId)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Profile = new Profile() { Id = ProfileId };
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; set; }

        public Profile Profile{ get; set; }
        public DateTime BirthDate { get; private set; }


    }
}
