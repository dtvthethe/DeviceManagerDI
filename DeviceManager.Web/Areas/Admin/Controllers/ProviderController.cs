using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DeviceManager.Web.Areas.Admin.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        // GET: Admin/Provider
        public ActionResult Index()
        {
            return View(_providerService.GetAll().ToList());
        }

        // GET: Admin/Provider/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = _providerService.GetById(id);

            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // GET: Admin/Provider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Provider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                _providerService.Add(provider);
                _providerService.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(provider);
        }

        // GET: Admin/Provider/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = _providerService.GetById(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: Admin/Provider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                var pro = _providerService.GetById(provider.ID);
                pro.Name = provider.Name;
                _providerService.Update(pro);
                _providerService.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(provider);
        }

        // GET: Admin/Provider/Delete/5
        public ActionResult Delete(int id = 0)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = _providerService.GetById(id);

            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: Admin/Provider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _providerService.Delete(id);
            _providerService.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
