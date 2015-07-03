//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PhonebookUsingMVC.Models
{
    
    
    public partial class PhoneBook
    {
        public int PhoneBookId { get; set; }

        [Required(ErrorMessage = "Number is required.")]
        [StringLength(10, MinimumLength = 2,ErrorMessage = "Please keep the username between 2 and ten character.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Number must be a natural number")]
        [Remote("IsNumberExist", "PhoneBook", ErrorMessage = "This Number already Exits")]
        [Display(Name = "User Number")]
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int GroupNameId { get; set; }
        public System.DateTime DateEntry { get; set; }
    
        public virtual GroupName GroupName { get; set; }
    }
}