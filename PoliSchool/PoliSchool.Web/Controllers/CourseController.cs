using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Interfaces;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseDao courseDao;
        private readonly IDepartmentDao departmentDao;

        public CourseController(ICourseDao courseDao, IDepartmentDao departmentDao)
        {
            this.courseDao = courseDao;
            this.departmentDao = departmentDao;
        }
        public ActionResult Index()
        {
            var courses = this.courseDao.GetCourses().Select(co => new Models.CourseListModel()
            {
                CourseId = co.CourseId,
                CreationDateDisplay = co.CreationDateDisplay,
                Department = co.DepartmentName,
                Name = co.Name,
            });


            return View(courses);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var courseModel = this.courseDao.GetCourseById(id);

            CourseListModel course = new CourseListModel()
            {
                CreationDateDisplay = courseModel.CreationDateDisplay,
                CourseId=courseModel.CourseId,
                Name = courseModel.Name,
                Department = courseModel.DepartmentName
            };
            return View(course);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            var departments = this.departmentDao.GetDepartments();
            ViewData["Departments"] = new SelectList(departments, "DepartmentId", "Name");

            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel courseViewModel)
        {
            try
            {
                Course courseToAdd = new Course()
                {
                    Title = courseViewModel.Title,
                    Credits = courseViewModel.Credits,
                    CreationDate = courseViewModel.CreationDate,
                    CreationUser = 1
                    
                };

                //this.courseDao.SaveCourse(courseToAdd);
                this.courseDao.SaveCourse(courseToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var departments = this.departmentDao.GetDepartments();
            ViewData["Departments"] = new SelectList(departments, "DepartmentId", "Name");


            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseViewModel courseViewModel)
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

       
    }
}
