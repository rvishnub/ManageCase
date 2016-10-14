using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageCase.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public int userInternalId { get; set; }
        public string userLastName { get; set; }
        public string userFirstName { get; set; }
        public string userLogin { get; set; }
        public string userPassword { get; set; }
        public string userRole { get; set; }//doctor, nurse, attorney, etc
        public string userSecurityQuestion { get; set; }
        public string userSecurityAnswer { get; set; }
    }
}