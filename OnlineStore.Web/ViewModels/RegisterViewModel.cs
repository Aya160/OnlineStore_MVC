﻿using OnlineStore.Core.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Web.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        public string PhoneNO1 { get; set; }
        public string PhoneNO2 { get; set; }
        public Address Address { get; set; }
    }
}