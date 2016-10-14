using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManageCase.Models;
using System.IO;

namespace ManageCase.Controllers
{
    public class RecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Records
        public ActionResult Index()
        {
            var record = db.Record.Include(r => r.Department).Include(r => r.DocumentSource).Include(r => r.DocumentType).Include(r => r.Facility).Include(r => r.InternalCaseNumber);
            return View(record.ToList());
        }

        // GET: Records/Details/5
        public ActionResult Details(string filename)
        {
            filename = "C:/Users/Renuka/Dropbox/WORK/devcodecamp/CAPSTONE/Pages from OfficeRecords_1969952.pdf";
            
                if (filename == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = new Models.Record();
            string pdfText = record.ReadPdfFile(filename);

            if (record == null)
            {
                return HttpNotFound();
            }
            return View(pdfText);
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            ViewBag.departmentId = new SelectList(db.Department, "departmentId", "departmentCode");
            ViewBag.sourceId = new SelectList(db.DocumentSource, "sourceId", "sourceCode");
            ViewBag.documentId = new SelectList(db.DocumentType, "documentId", "documentCode");
            ViewBag.facilityId = new SelectList(db.Facility, "facilityId", "facilityName");
            ViewBag.internalCaseId = new SelectList(db.InternalCaseNumber, "internalCaseId", "internalCaseId");
            return View();
        }

        // POST: Records/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recordId,internalCaseId,sourceId,departmentId,documentId,facilityId,recordReferenceNumber,pageNumber,recordEntryDate,providerFirstName,providerLastName,memo,serviceDate,noteSubjective,noteObjective,noteAssessment,notePlan")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Record.Add(record);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.departmentId = new SelectList(db.Department, "departmentId", "departmentCode", record.departmentId);
            ViewBag.sourceId = new SelectList(db.DocumentSource, "sourceId", "sourceCode", record.sourceId);
            ViewBag.documentId = new SelectList(db.DocumentType, "documentId", "documentCode", record.documentId);
            ViewBag.facilityId = new SelectList(db.Facility, "facilityId", "facilityName", record.facilityId);
            ViewBag.internalCaseId = new SelectList(db.InternalCaseNumber, "internalCaseId", "internalCaseId", record.internalCaseId);
            return View(record);
        }

        // GET: Records/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Record.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            ViewBag.departmentId = new SelectList(db.Department, "departmentId", "departmentCode", record.departmentId);
            ViewBag.sourceId = new SelectList(db.DocumentSource, "sourceId", "sourceCode", record.sourceId);
            ViewBag.documentId = new SelectList(db.DocumentType, "documentId", "documentCode", record.documentId);
            ViewBag.facilityId = new SelectList(db.Facility, "facilityId", "facilityName", record.facilityId);
            ViewBag.internalCaseId = new SelectList(db.InternalCaseNumber, "internalCaseId", "internalCaseId", record.internalCaseId);
            return View(record);
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recordId,internalCaseId,sourceId,departmentId,documentId,facilityId,recordReferenceNumber,pageNumber,recordEntryDate,providerFirstName,providerLastName,memo,serviceDate,noteSubjective,noteObjective,noteAssessment,notePlan")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.departmentId = new SelectList(db.Department, "departmentId", "departmentCode", record.departmentId);
            ViewBag.sourceId = new SelectList(db.DocumentSource, "sourceId", "sourceCode", record.sourceId);
            ViewBag.documentId = new SelectList(db.DocumentType, "documentId", "documentCode", record.documentId);
            ViewBag.facilityId = new SelectList(db.Facility, "facilityId", "facilityName", record.facilityId);
            ViewBag.internalCaseId = new SelectList(db.InternalCaseNumber, "internalCaseId", "internalCaseId", record.internalCaseId);
            return View(record);
        }

        // GET: Records/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Record.Find(id);
            if (record == null)
            {
                return HttpNotFound();
            }
            return View(record);
        }

        // POST: Records/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Record record = db.Record.Find(id);
            db.Record.Remove(record);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void SendSearchRequest(string term)
        {
            WebRequest request = WebRequest.Create("https://wsearch.nlm.nih.gov/ws/query?db=healthTopics&term="+term);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                response.Close();
            }
            response.Close();
            
        }
    }

}
