using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DeviceManager.Web.Areas.Admin.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        // GET: Admin/Unit
        public ActionResult Index()
        {
            return View(_unitService.GetAll().ToList());
        }

        // GET: Admin/Unit/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = _unitService.GetById(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // GET: Admin/Unit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Unit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                _unitService.Add(unit);
                _unitService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(unit);
        }

        // GET: Admin/Unit/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = _unitService.GetById(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Admin/Unit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Unit unit)
        {
            if (ModelState.IsValid)
            {
                var un = _unitService.GetById(unit.ID);
                un.Name = unit.Name;

                _unitService.Update(un);
                _unitService.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(unit);
        }

        // GET: Admin/Unit/Delete/5
        public ActionResult Delete(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit unit = _unitService.GetById(id);
            if (unit == null)
            {
                return HttpNotFound();
            }
            return View(unit);
        }

        // POST: Admin/Unit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitService.Delete(id);
            _unitService.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
