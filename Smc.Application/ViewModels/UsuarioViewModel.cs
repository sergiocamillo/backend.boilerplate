﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Smc.Application.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }
    }
}
