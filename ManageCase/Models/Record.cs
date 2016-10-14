using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace ManageCase.Models
{
    public class Record
    {

        [Key]
        public int recordId { get; set; }

        [ForeignKey("InternalCaseNumber")]
        public int internalCaseId { get; set; }//business associate
        public InternalCaseNumber InternalCaseNumber { get; set; }

        [ForeignKey("DocumentSource")]
        public int sourceId { get; set; }//plaintiff, defendant, insurance company, patient, provider
        public DocumentSource DocumentSource { get; set; }

        [ForeignKey("Department")]
        public int departmentId { get; set; }//ER, RAD, etc
        public Department Department { get; set; }

        [ForeignKey("DocumentType")]
        public int documentId { get; set; }//note, report, letter
        public DocumentType DocumentType { get; set; }

        [ForeignKey("Facility")]
        public int facilityId { get; set; }//maybe a dropdown
        public Facility Facility { get; set; }

        public string recordReferenceNumber { get; set; }//autofill
        public string pageNumber { get; set; }
        public DateTime recordEntryDate { get; set; }
        public string providerFirstName { get; set; }
        public string providerLastName { get; set; }
        public string memo { get; set; }
        public DateTime serviceDate { get; set; }//date of appt
        public string noteSubjective { get; set; }
        public string noteObjective { get; set; }
        public string noteAssessment { get; set; }
        public string notePlan { get; set; }

        public string fileContent { get; set; }


        public string ReadPdfFile(string fileName)
        {
            StringBuilder text = new StringBuilder();

            if (File.Exists(fileName))
            {
                PdfReader pdfReader = new PdfReader(fileName);

                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    text.Append(currentText);
                }
                pdfReader.Close();
            }
            return text.ToString();
        }
    }
}