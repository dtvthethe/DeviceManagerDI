using AutoMapper;
using DeviceManager.Model.Models;
using DeviceManager.Service.IServices;
using DeviceManager.Web.Areas.Admin.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace DeviceManager.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IDepartmentService _departmentService;

        public UserController(IUserService userService, IRoleService roleService, IDepartmentService departmentService)
        {
            _userService = userService;
            _roleService = roleService;
            _departmentService = departmentService;
        }

        // GET: Admin/User
        public ActionResult Index()
        {
            var users = _userService.GetAll().ToList();
            return View(users);
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userService.GetById(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            var user = new UserViewModel();
            user.Roles = _roleService.GetAll().ToList();
            user.Departments = _departmentService.GetAll().ToList();

            return View(user);
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,Email,FullName,Address,BirthDay,IDDepartment,IDRole")] UserViewModel userViewModel)
        {

            try
            {
                var user = Mapper.Map<User>(userViewModel);
                _userService.Add(user);
                _userService.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                userViewModel.Roles = _roleService.GetAll().ToList();
                userViewModel.Departments = _departmentService.GetAll().ToList();

                return View(userViewModel);
            }


        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userService.GetById(id);

            var userVM = Mapper.Map<UserViewModel>(user);

            if (user == null)
            {
                return HttpNotFound();
            }
            userVM.Roles = _roleService.GetAll().ToList();
            userVM.Departments = _departmentService.GetAll().ToList();

            return View(userVM);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Email,FullName,Address,BirthDay,IDDepartment,IDRole")] UserViewModel userViewModel)
        {
            try
            {
                var user = _userService.GetById(userViewModel.Username);
                user.Email = userViewModel.Email;
                user.FullName = userViewModel.FullName;
                user.Address = userViewModel.Address;
                user.BirthDay = userViewModel.BirthDay;
                user.IDDepartment = userViewModel.IDDepartment;
                user.IDRole = userViewModel.IDRole;

                _userService.Update(user);
                _userService.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                userViewModel.Roles = _roleService.GetAll().ToList();
                userViewModel.Departments = _departmentService.GetAll().ToList();

                return View(userViewModel);
            }

        }

        // GET: Admin/User/Edit/5
        public ActionResult ChangePassword(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userService.GetById(id);

            var userVM = Mapper.Map<UserViewModel>(user);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword([Bind(Include = "Username,Password,PasswordConfirm")] UserViewModel userViewModel)
        {
            try
            {
                var user = _userService.GetById(userViewModel.Username);
                user.Password = userViewModel.Password;
                
                _userService.Update(user);
                _userService.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(userViewModel);
            }

        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userService.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = _userService.Delete(id);
            _userService.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
