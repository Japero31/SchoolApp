using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Interfaces;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class OnlineCourseController : Controller
    {
        private readonly IOnlineCourseDao onlineCourseDao;
        private readonly ICourseDao courseDao;

        public OnlineCourseController(IOnlineCourseDao onlineCourseDao, ICourseDao courseDao)
        {
            this.onlineCourseDao = onlineCourseDao;
            this.courseDao = courseDao;
        }
        // GET: OnlineCourseController
        public ActionResult Index()
        {
            var onlineCourses = this.onlineCourseDao.GetOnlineCourses().Select(co => new Models.OnlineCourseListModel()
            {
                CourseId = co.CourseId,
                URL = co.URL,
            }).ToList();
            return View(onlineCourses);
        }

        // GET: OnlineCourseController/Details/5
        public ActionResult Details(int id)
        {
            var onlineModel = this.onlineCourseDao.GetOnlineCourseById(id);

            OnlineCourseListModel online = new OnlineCourseListModel()
            {
                CourseId =onlineModel.CourseId,
                URL = onlineModel.URL,
            };
            return View(online);
        }

        // GET: OnlineCourseController/Create
        public ActionResult Create()
        {
            var courses = this.courseDao.GetCourses();
            ViewData["Courses"] = new SelectList(courses, "CourseId");

            return View();
        }

        // POST: OnlineCourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OnlineCourseViewModel onlineCourseView)
        {
            try
            {
                OnlineCourse onlineToAdd = new OnlineCourse()
                {
                    CourseId = onlineCourseView.CourseId,
                    Url = onlineCourseView.URL,
                };
                this.onlineCourseDao.SaveOnlineCourse(onlineToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OnlineCourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var courses = this.courseDao.GetCourses();
            ViewData["Courses"] = new SelectList(courses, "CourseId");

            var onlineModel = this.onlineCourseDao.GetOnlineCourseById(id);

            OnlineCourseViewModel onlineCourseView = new OnlineCourseViewModel()
            {
                CourseId= onlineModel.CourseId,
                URL = onlineModel.URL,
            };
            return View(onlineCourseView);
        }

        // POST: OnlineCourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OnlineCourseViewModel onlineCourseView)
        {
            try
            {
                OnlineCourse onlineToUpdate = new OnlineCourse
                {
                    CourseId=onlineCourseView.CourseId,
                    Url = onlineCourseView.URL,
                };
                this.onlineCourseDao.UpdateOnlineCourse(onlineToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
