using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebbShopAPI.Interfaces;

namespace WebbShopAPI.Models
{
    /// <summary>
    /// Users (the customers).
    /// Containing: ID, first name, surname, full name, username, password, admin boolean, active user boolean, session timer, last log in timer, books bought.
    /// </summary>
    public class User :INamable, IUser, IDateAndTimeable, IModelable
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to enter a first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to enter a last name.")]
        public string Surname { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "You need to enter a username.")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You need to enter a password.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Password needs to be longer than 4 characters.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public string FullName { get => $"{FirstName} {Surname}"; }
        public bool Admin { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime SessionTimer { get; set; }
        public DateTime LastLogIn { get; set; }
        public List<Book> BooksBought { get; set; }
    }
}
