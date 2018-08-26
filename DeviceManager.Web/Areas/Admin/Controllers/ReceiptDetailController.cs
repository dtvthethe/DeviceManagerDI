using DeviceManager.Data;
using DeviceManager.Model.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DeviceManager.Web.Areas.Admin.Controllers
{
    public class ReceiptDetailController : Controller
    {
        private DeviceManagerDbContext db = new DeviceManagerDbContext();

        // GET: Admin/ReceiptDetail
        public ActionResult Index()
        {
            var receiptDetails = db.ReceiptDetails.Include(r => r.Device).Include(r => r.Receipt);
            return View(receiptDetails.ToList());
        }

        // GET: Admin/ReceiptDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptDetail receiptDetail = db.ReceiptDetails.Find(id);
            if (receiptDetail == null)
            {
                return HttpNotFound();
            }
            return View(receiptDetail);
        }

        // GET: Admin/ReceiptDetail/Create
        public ActionResult Create()
        {
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name");
            ViewBag.IDReceipt = new SelectList(db.Receipts, "ID", "CreatedBy");
            return View();
        }

        // POST: Admin/ReceiptDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDReceipt,IDDevice,Quantity")] ReceiptDetail receiptDetail)
        {
            if (ModelState.IsValid)
            {
                db.ReceiptDetails.Add(receiptDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", receiptDetail.IDDevice);
            ViewBag.IDReceipt = new SelectList(db.Receipts, "ID", "CreatedBy", receiptDetail.IDReceipt);
            return View(receiptDetail);
        }

        // GET: Admin/ReceiptDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptDetail receiptDetail = db.ReceiptDetails.Find(id);
            if (receiptDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", receiptDetail.IDDevice);
            ViewBag.IDReceipt = new SelectList(db.Receipts, "ID", "CreatedBy", receiptDetail.IDReceipt);
            return View(receiptDetail);
        }

        // POST: Admin/ReceiptDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDReceipt,IDDevice,Quantity")] ReceiptDetail receiptDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receiptDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", receiptDetail.IDDevice);
            ViewBag.IDReceipt = new SelectList(db.Receipts, "ID", "CreatedBy", receiptDetail.IDReceipt);
            return View(receiptDetail);
        }

        // GET: Admin/ReceiptDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptDetail receiptDetail = db.ReceiptDetails.Find(id);
            if (receiptDetail == null)
            {
                return HttpNotFound();
            }
            return View(receiptDetail);
        }

        // POST: Admin/ReceiptDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReceiptDetail receiptDetail = db.ReceiptDetails.Find(id);
            db.ReceiptDetails.Remove(receiptDetail);
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
    }
}
