using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageCase.Models
{
    public class UserCaseNumberJunction
    {
        [Key]
        public int userCaseNumberJunctionId { get; set; }

        [ForeignKey("User")]
        public int userId { get; set; }
        public User User { get; set; }

        [ForeignKey("CaseNumber")]
        public int caseId { get; set; }
        public CaseNumber CaseNumber { get; set; }
    }
}