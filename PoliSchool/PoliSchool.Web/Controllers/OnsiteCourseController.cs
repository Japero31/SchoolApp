using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Interfaces;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class OnsiteCourseController : Controller
    {
        private readonly IOnsiteCourseDao onsiteCourseDao;

        public OnsiteCourseController(IOnsiteCourseDao onsiteCourseDao)
        {
            this.onsiteCourseDao = onsiteCourseDao;
        }
        public ActionResult Index()
        {
            var onsiteCourses = this.onsiteCourseDao.GetOnsiteCourses().Select(co => new Models.OnsiteCourseListModel()
            {
                CourseId = co.CourseId,
                Location = co.Location,
                Days = co.Days,
                Time = co.Time,
                TimeDisplay = co.TimeDisplay,
            }).ToList(); 
            return View(onsiteCourses);
        }

        // GET: OnsiteCourseController/Details/5
        public ActionResult Details(int id)
        {
            var onsiteModel = this.onsiteCourseDao.GetOnsiteCourseById(id);

            OnsiteCourseListModel onsite = new OnsiteCourseListModel()
            {
                CourseId =onsiteModel.CourseId,
                Location =onsiteModel.Location,
                Days =onsiteModel.Days,
                Time =onsiteModel.Time,
            };
            return View(onsite);
        }

        // GET: OnsiteCourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OnsiteCourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OnsiteCourseViewModel onsiteCourseView)
        {
            try
            {
                OnsiteCourse onsiteToAdd = new OnsiteCourse()
                {
                    Location = onsiteCourseView.Location,
                    Days = onsiteCourseView.Days,
                    Time = onsiteCourseView.Time,
                    CourseId=onsiteCourseView.CourseId,
                };
                this.onsiteCourseDao.SaveOnsiteCourse(onsiteToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OnsiteCourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var onsiteModel = this.onsiteCourseDao.GetOnsiteCourseById(id);

            OnsiteCourseViewModel onsiteCourseView = new OnsiteCourseViewModel()
            {
                Location = onsiteModel.Location,
                Days = onsiteModel.Days,
                Time = onsiteModel.Time,
                CourseId = onsiteModel.CourseId,
            };
            return View(onsiteCourseView);
        }

        // POST: OnsiteCourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OnsiteCourseViewModel onsiteCourseView)
        {
            try
            {
                OnsiteCourse onsiteToUpdate = new OnsiteCourse
                {
                  Location = onsiteCourseView.Location,
                  Days = onsiteCourseView.Days,
                  Time = onsiteCourseView.Time,
                  CourseId = onsiteCourseView.CourseId
                };

                this.onsiteCourseDao.UpdateOnsiteCourse(onsiteToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
