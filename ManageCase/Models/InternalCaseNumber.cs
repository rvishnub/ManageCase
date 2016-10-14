using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageCase.Models
{
    public class InternalCaseNumber
    {
        [Key]
        public int internalCaseId { get; set; }
        public int internalCaseNumber { get; set; }

        [ForeignKey("CaseNumber")]
        public int caseId { get; set; }
        public CaseNumber CaseNumber { get; set; }
    }
}