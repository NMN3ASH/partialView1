//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelerikMvcApp1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhoneBook
    {
        public int PhoneBookId { get; set; }
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
