using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smc.Domain.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public long? Departament_Id { get; set; }
        public string Country_IsoCode { get; set; }
        public long? PrimaryPhone_Id { get; set; }
        public long? SecondaryPhone_Id { get; set; }
        public int EmailVerificationStatus { get; set; }
    }
}
