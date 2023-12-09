using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Interfaces;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentDao departmentDao;

        public DepartmentController(IDepartmentDao departmentDao)
        {
            this.departmentDao = departmentDao;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var departments = this.departmentDao.GetDepartments().Select(cd => new Models.DepartmentListModel()
            {
                StartDateDisplay = cd.StartDateDisplay,
                Name = cd.Name,
                DepartmentId = cd.DepartmentId,
                Budget = cd.Budget,
                Administrator = cd.Administrator,
            }).ToList();
            return View(departments);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            var departmentModel = this.departmentDao.GetDepartmentById(id);

            DepartmentListModel departments = new DepartmentListModel()
            {
                StartDateDisplay = departmentModel.StartDateDisplay,
                Name = departmentModel.Name,
                DepartmentId = departmentModel.DepartmentId,
                Budget = departmentModel.Budget,
                Administrator= departmentModel.Administrator,
            };
            return View(departments);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel departmentView)
        {
            try
            {
                Department departmentToAdd = new Department()
                {
                    Name = departmentView.Name,
                    Budget = departmentView.Budget,
                    StartDate = departmentView.StartDate,
                    Administrator = departmentView.Administrator,
                    CreationDate = DateTime.Now,
                    CreationUser = 1


                };

                this.departmentDao.SaveDepartment(departmentToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var departmentModel = this.departmentDao.GetDepartmentById(id);

            DepartmentViewModel departmentViewModel = new DepartmentViewModel()
            {
                StartDate = departmentModel.StartDate,
                DepartmentId = departmentModel.DepartmentId,
                Name = departmentModel.Name,
                Budget= departmentModel.Budget,
                Administrator= departmentModel.Administrator,
            };
            return View(departmentViewModel);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentViewModel departmentView)
        {
            try
            {
                Department departmentToUpdate = new Department()
                {
                    DepartmentId = departmentView.DepartmentId,
                    Name = departmentView.Name,
                    Budget = departmentView.Budget,
                    StartDate = departmentView.StartDate,
                    Administrator = departmentView.Administrator
                };
                this.departmentDao.UpdateDepartment(departmentToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
