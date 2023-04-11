using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Smc.Application.ViewModels
{
    public class PersonViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The JobTitle is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("JobTitle")]
        public string JobTitle { get; set; }
        public long? Departament_Id { get; set; }

        [Required(ErrorMessage = "The Country_IsoCode is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Country_IsoCode")]
        public string Country_IsoCode { get; set; }
        public long? PrimaryPhone_Id { get; set; }
        public long? SecondaryPhone_Id { get; set; }
        public int EmailVerificationStatus { get; set; }
    }
}


//private UserToken CreateUserCredentials(string email, string password, TermsAcceptance termsAcceptance)