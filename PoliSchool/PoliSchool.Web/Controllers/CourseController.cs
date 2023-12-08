using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Interfaces;

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
            var course = this.courseDao.GetCourses().Select(co => new Models.CourseListModel()
            {
                CourseId = co.CourseId,
                CreationDateDisplay = co.CreationDateDisplay,
                DepartmentId = co.DepartmentId,
                Credits = co.Credits,
                Department = co.DepartmentName,
                Name = co.Name,
            });


            return View(course);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
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

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
