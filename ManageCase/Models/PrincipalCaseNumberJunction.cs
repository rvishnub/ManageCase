using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageCase.Models
{
    public class PrincipalCaseNumberJunction
    {
        [Key]
        public int principalCaseNumberJunctionId { get; set; }

        [ForeignKey("Principal")]
        public int principalId { get; set; }
        public Principal Principal { get; set; }

        [ForeignKey("CaseNumber")]
        public int caseId { get; set; }
        public CaseNumber CaseNumber { get; set; }
    }
}