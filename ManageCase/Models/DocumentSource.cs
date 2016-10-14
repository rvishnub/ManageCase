using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManageCase.Models
{
    public class DocumentSource
    {
        [Key]
        public int sourceId { get; set; }
        public string sourceCode { get; set; }
        public string sourceName { get; set; }

    }
}