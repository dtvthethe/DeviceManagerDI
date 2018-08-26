using DeviceManager.Data;
using DeviceManager.Model.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DeviceManager.Web.Areas.Admin.Controllers
{
    public class DeviceController : Controller
    {
        private DeviceManagerDbContext db = new DeviceManagerDbContext();

        //private IDeviceService _deviceService;

        //public DeviceController(IDeviceService deviceService)
        //{
        //    _deviceService = deviceService;
        //}

        // GET: Admin/Device
        public ActionResult Index()
        {
            var devices = db.Devices.Include(d => d.Category).Include(d => d.Status).Include(d => d.Unit);
            return View(devices.ToList());
        }

        // GET: Admin/Device/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // GET: Admin/Device/Create
        public ActionResult Create()
        {
            ViewBag.IDCategory = new SelectList(db.Categories, "ID", "Name");
            ViewBag.IDStatus = new SelectList(db.Statuses, "ID", "Name");
            ViewBag.IDUnit = new SelectList(db.Units, "ID", "Name");
            return View();
        }

        // POST: Admin/Device/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Quantity,IDCategory,IDUnit,IDStatus,Price,Info,CreatedBy,UpdatedBy,Note,CreatedDate,UpdatedDate")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Devices.Add(device);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCategory = new SelectList(db.Categories, "ID", "Name", device.IDCategory);
            ViewBag.IDStatus = new SelectList(db.Statuses, "ID", "Name", device.IDStatus);
            ViewBag.IDUnit = new SelectList(db.Units, "ID", "Name", device.IDUnit);
            return View(device);
        }

        // GET: Admin/Device/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategory = new SelectList(db.Categories, "ID", "Name", device.IDCategory);
            ViewBag.IDStatus = new SelectList(db.Statuses, "ID", "Name", device.IDStatus);
            ViewBag.IDUnit = new SelectList(db.Units, "ID", "Name", device.IDUnit);
            return View(device);
        }

        // POST: Admin/Device/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Quantity,IDCategory,IDUnit,IDStatus,Price,Info,CreatedBy,UpdatedBy,Note,CreatedDate,UpdatedDate")] Device device)
        {
            if (ModelState.IsValid)
            {
                db.Entry(device).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCategory = new SelectList(db.Categories, "ID", "Name", device.IDCategory);
            ViewBag.IDStatus = new SelectList(db.Statuses, "ID", "Name", device.IDStatus);
            ViewBag.IDUnit = new SelectList(db.Units, "ID", "Name", device.IDUnit);
            return View(device);
        }

        // GET: Admin/Device/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return HttpNotFound();
            }
            return View(device);
        }

        // POST: Admin/Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Device device = db.Devices.Find(id);
            db.Devices.Remove(device);
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
