using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageCase.Models
{
    public class CaseNumber
    {
        [Key]
        public int caseId { get; set; }
        public string caseName { get; set; }
        public string caseNumber { get; set; }

    }
}