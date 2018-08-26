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
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        // GET: Admin/Status
        public ActionResult Index()
        {
            return View(_statusService.GetAll().ToList());
        }

        // GET: Admin/Status/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = _statusService.GetById(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // GET: Admin/Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Status status)
        {
            if (ModelState.IsValid)
            {
                _statusService.Add(status);
                _statusService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(status);
        }

        // GET: Admin/Status/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = _statusService.GetById(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // POST: Admin/Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Status status)
        {
            if (ModelState.IsValid)
            {
                var stat = _statusService.GetById(status.ID);
                stat.Name = status.Name;

                _statusService.Update(stat);
                _statusService.SaveChanges();


                return RedirectToAction("Index");
            }
            return View(status);
        }

        // GET: Admin/Status/Delete/5
        public ActionResult Delete(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = _statusService.GetById(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // POST: Admin/Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _statusService.Delete(id);
            _statusService.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
