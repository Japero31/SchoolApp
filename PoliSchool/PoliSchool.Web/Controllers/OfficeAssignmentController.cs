using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Interfaces;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class OfficeAssignmentController : Controller
    {
        private readonly IOfficeAssignmentDao officeAssignmentDao;

        public OfficeAssignmentController(IOfficeAssignmentDao officeAssignmentDao)
        {
            this.officeAssignmentDao = officeAssignmentDao;
        }
        // GET: OfficeAssignmentController
        public ActionResult Index()
        {
            var offices = this.officeAssignmentDao.GetOfficeAssignments().Select(co => new Models.OfficeAssignmentListModel()
            {
                InstructorId = co.InstructorId,
                Location = co.Location,
            });
            return View(offices);
        }

        // GET: OfficeAssignmentController/Details/5
        public ActionResult Details(int id)
        {
            var officeModel = this.officeAssignmentDao.GetOfficeAssignmentById(id);

            OfficeAssignmentListModel office = new OfficeAssignmentListModel()
            {
                InstructorId = officeModel.InstructorId,
                Location = officeModel.Location,
            };
            return View(office);
        }

        // GET: OfficeAssignmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfficeAssignmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OfficeAssignmentViewModel officeAssignmentView)
        {
            try
            {
                OfficeAssignment officeToAdd = new OfficeAssignment()
                {
                    InstructorID = officeAssignmentView.InstructorId,
                    Location = officeAssignmentView.Location,
                };
                this.officeAssignmentDao.SaveOfficeAssignment(officeToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OfficeAssignmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var officeAssignmentModel = this.officeAssignmentDao.GetOfficeAssignmentById(id);

            OfficeAssignmentViewModel officeAssignmentViewModel = new OfficeAssignmentViewModel()
            {
                InstructorId = officeAssignmentModel.InstructorId,
                Location = officeAssignmentModel.Location,
            };
            return View(officeAssignmentViewModel);
        }

        // POST: OfficeAssignmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OfficeAssignmentViewModel officeAssignmentView)
        {
            try
            {
                OfficeAssignment officeToUpdate = new OfficeAssignment()
                {
                    InstructorID = officeAssignmentView.InstructorId,
                    Location = officeAssignmentView.Location,
                };
                this.officeAssignmentDao.UpdateOfficeAssignment(officeToUpdate);    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
