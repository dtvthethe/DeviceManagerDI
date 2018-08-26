using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DeviceManager.Web.Areas.Admin.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: Admin/Department
        public ActionResult Index()
        {
            return View(_departmentService.GetAll().ToList());
        }

        // GET: Admin/Department/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentService.GetById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Admin/Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.Add(department);
                _departmentService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Admin/Department/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentService.GetById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Admin/Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                var depart = _departmentService.GetById(department.ID);
                depart.Name = department.Name;
                _departmentService.Update(depart);

                _departmentService.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Admin/Department/Delete/5
        public ActionResult Delete(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentService.GetById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Admin/Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _departmentService.Delete(id);
            _departmentService.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
