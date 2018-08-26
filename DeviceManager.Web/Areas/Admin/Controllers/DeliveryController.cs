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
    public class DeliveryController : Controller
    {
        private DeviceManagerDbContext db = new DeviceManagerDbContext();

        private IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        // GET: Admin/Delivery
        public ActionResult Index()
        {
            var productCategories = db.ProductCategories.Include(d => d.UserDeliveryFrom).Include(d => d.UserDeliveryTo);
            return View(productCategories.ToList());
        }

        // GET: Admin/Delivery/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.ProductCategories.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // GET: Admin/Delivery/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryFromUser = new SelectList(db.Users, "Username", "Password");
            ViewBag.DeliveryToUser = new SelectList(db.Users, "Username", "Password");
            return View();
        }

        // POST: Admin/Delivery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DeliveryToUser,DeliveryFromUser,CreatedBy,UpdatedBy,Note,CreatedDate,UpdatedDate")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(delivery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryFromUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryFromUser);
            ViewBag.DeliveryToUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryToUser);
            return View(delivery);
        }

        // GET: Admin/Delivery/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.ProductCategories.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryFromUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryFromUser);
            ViewBag.DeliveryToUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryToUser);
            return View(delivery);
        }

        // POST: Admin/Delivery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DeliveryToUser,DeliveryFromUser,CreatedBy,UpdatedBy,Note,CreatedDate,UpdatedDate")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delivery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryFromUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryFromUser);
            ViewBag.DeliveryToUser = new SelectList(db.Users, "Username", "Password", delivery.DeliveryToUser);
            return View(delivery);
        }

        // GET: Admin/Delivery/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.ProductCategories.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // POST: Admin/Delivery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Delivery delivery = db.ProductCategories.Find(id);
            db.ProductCategories.Remove(delivery);
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
