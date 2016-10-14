using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageCase.Models
{
    public class Principal
    {
        [Key]
        public int principalId { get; set; }
        public string principalCode { get; set; }
        public string principalFirstName { get; set; }
        public string principalLastName { get; set; }

    }
}