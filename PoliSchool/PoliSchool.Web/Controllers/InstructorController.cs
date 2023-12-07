using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Entities;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorDao instructorDao;

        public InstructorController(IInstructorDao instructorDao)
        {
            this.instructorDao = instructorDao;
        }
        // GET: InstructorController
        public ActionResult Index()
        {
            var instructors = this.instructorDao.GetInstructors().Select(cd => new Models.InstructorListModel()
            {
                CreationDate = cd.CreationDateDisplay,
                HireDate = cd.HireDate,
                HireDateDisplay = cd.HireDateDisplay,
                Id = cd.Id,
                Name = cd.Name,
            }).ToList();

            return View(instructors);   
        }

        // GET: InstructorController/Details/5
        public ActionResult Details(int id)
        {
            var instructorModel = this.instructorDao.GetInstructorById(id);

            InstructorListModel instructors = new InstructorListModel()
            {
                HireDate = instructorModel.HireDate,
                Id = instructorModel.Id,
                Name = instructorModel.Name,
            };
            return View(instructors);
        }

        // GET: InstructorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstructorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorController/Edit/5
        public ActionResult Edit(int id)
        {
            var instructorModel = this.instructorDao.GetInstructorById(id);

            InstructorViewModel instructorViewModel = new InstructorViewModel()
            {
               HireDate = instructorModel.HireDate,
               Id = instructorModel.Id,
               FirstName = instructorModel.FirstName,
               LastName = instructorModel.LastName,
            };
            return View(instructorViewModel);
        }

        // POST: InstructorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstructorViewModel instructorView)
        {
            try
            {
                Instructor instructorToUpdate = new Instructor()
                {
                    Id = instructorView.Id,
                    FirstName = instructorView.FirstName,
                    LastName = instructorView.LastName,
                    HireDate = instructorView.HireDate,
                    ModifyDate = DateTime.Now,
                    UserMod = 1
                };

                this.instructorDao.UpdateInstructor(instructorToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
