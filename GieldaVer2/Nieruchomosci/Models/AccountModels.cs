﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Nieruchomosci.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

       // public DbSet<UserProfile> UserProfiles { get; set; }
    }

   /* [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    } */
    public class RegisterExternalLoginModel
    {
      [Required(ErrorMessage = "Pole {0} jest wymagane")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
       [Required(ErrorMessage = "Pole {0} jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Aktualne hasło")]
        public string OldPassword { get; set; }

      [Required(ErrorMessage = "Pole {0} jest wymagane")]
        [StringLength(100, ErrorMessage = "Pole {0} musi mieć conajmniej {2} długości.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdzenia hasła")]
        [Compare("NewPassword", ErrorMessage = "Nowe hasło oraz potwierdzenie hasła nie zgadzaja się.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
     [Required(ErrorMessage = "Pole {0} jest wymagane")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

      [Required(ErrorMessage = "Pole {0} jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamietaj mnie?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
       [Required(ErrorMessage = "Pole {0} jest wymagane")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

      [Required(ErrorMessage = "Pole {0} jest wymagane")]
        [StringLength(100, ErrorMessage = "Pole {0} musi mieć conajmniej {2} długości.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdzenie hasła")]
        [Compare("Password", ErrorMessage = "Nowe hasło oraz potwierdzenie hasła nie zgadzaja się.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
