using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DeviceManager.Web.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: Admin/Role
        public ActionResult Index()
        {
            return View(_roleService.GetAll().ToList());
        }

        // GET: Admin/Role/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _roleService.GetById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Admin/Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                _roleService.Add(role);
                _roleService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Admin/Role/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _roleService.GetById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Admin/Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                Role rol = _roleService.GetById(role.ID);
                rol.Name = role.Name;
                _roleService.Update(rol);
                _roleService.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Admin/Role/Delete/5
        public ActionResult Delete(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _roleService.GetById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Admin/Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = _roleService.Delete(id);
            _roleService.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
