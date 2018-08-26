using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeviceManager.Data;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;

namespace DeviceManager.Web.Areas.Admin.Controllers
{
    public class DeliveryDetailController : Controller
    {
        private readonly IDeliveryDetailService _deliveryDetailService;

        public DeliveryDetailController(IDeliveryDetailService deliveryDetailService)
        {
            _deliveryDetailService = deliveryDetailService;
        }

        private DeviceManagerDbContext db = new DeviceManagerDbContext();

        // GET: Admin/DeliveryDetail
        public ActionResult Index()
        {
            var deliveryDetails = db.DeliveryDetails.Include(d => d.Delivery).Include(d => d.Device);
            return View(deliveryDetails.ToList());
        }

        // GET: Admin/DeliveryDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryDetail deliveryDetail = db.DeliveryDetails.Find(id);
            if (deliveryDetail == null)
            {
                return HttpNotFound();
            }
            return View(deliveryDetail);
        }

        // GET: Admin/DeliveryDetail/Create
        public ActionResult Create()
        {
            ViewBag.IDDelivery = new SelectList(db.ProductCategories, "ID", "DeliveryToUser");
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name");
            return View();
        }

        // POST: Admin/DeliveryDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDDevice,IDDelivery,Quantity,DateExpires")] DeliveryDetail deliveryDetail)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryDetails.Add(deliveryDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDelivery = new SelectList(db.ProductCategories, "ID", "DeliveryToUser", deliveryDetail.IDDelivery);
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", deliveryDetail.IDDevice);
            return View(deliveryDetail);
        }

        // GET: Admin/DeliveryDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryDetail deliveryDetail = db.DeliveryDetails.Find(id);
            if (deliveryDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDelivery = new SelectList(db.ProductCategories, "ID", "DeliveryToUser", deliveryDetail.IDDelivery);
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", deliveryDetail.IDDevice);
            return View(deliveryDetail);
        }

        // POST: Admin/DeliveryDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDDevice,IDDelivery,Quantity,DateExpires")] DeliveryDetail deliveryDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDelivery = new SelectList(db.ProductCategories, "ID", "DeliveryToUser", deliveryDetail.IDDelivery);
            ViewBag.IDDevice = new SelectList(db.Devices, "ID", "Name", deliveryDetail.IDDevice);
            return View(deliveryDetail);
        }

        // GET: Admin/DeliveryDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryDetail deliveryDetail = db.DeliveryDetails.Find(id);
            if (deliveryDetail == null)
            {
                return HttpNotFound();
            }
            return View(deliveryDetail);
        }

        // POST: Admin/DeliveryDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryDetail deliveryDetail = db.DeliveryDetails.Find(id);
            db.DeliveryDetails.Remove(deliveryDetail);
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
