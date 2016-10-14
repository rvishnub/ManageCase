using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageCase.Models
{
    public class DocumentType
    {
        [Key]
        public int documentId { get; set; }
        public string documentCode { get; set; }
        public string documentName { get; set; }

    }
}