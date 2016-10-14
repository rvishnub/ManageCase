using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageCase.Models
{
    public class Department
    {
        [Key]
        public int departmentId { get; set; }
        public string departmentCode { get; set; }
        public string departmentName { get; set; }

    }
}