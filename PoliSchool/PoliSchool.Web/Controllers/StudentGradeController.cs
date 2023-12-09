using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Interfaces;
using PoliSchool.Web.Models;

namespace PoliSchool.Web.Controllers
{
    public class StudentGradeController : Controller
    {
        private readonly IStudentGradeDao studentGradeDao;
        private readonly IStudentDao studentDao;
        private readonly ICourseDao courseDao;

        public StudentGradeController(IStudentGradeDao studentGradeDao, IStudentDao studentDao, ICourseDao courseDao)
        {
            this.studentGradeDao = studentGradeDao;
            this.studentDao = studentDao;
            this.courseDao = courseDao;
        }
        // GET: StudentGrandeController
        public ActionResult Index()
        {
            var grades = this.studentGradeDao.GetStudentGrades().Select(co => new Models.StudentGradeListModel()
            {
                EnrollmentId = co.EnrollmentId,
                StudentId = co.StudentId,
                CourseId = co.CourseId,
                Grade = co.Grade,
            });
            return View(grades);
        }

        // GET: StudentGrandeController/Details/5
        public ActionResult Details(int id)
        {
            var gradeModel = this.studentGradeDao.GetStudentGradeById(id);

            StudentGradeListModel grade = new StudentGradeListModel()
            {
                EnrollmentId = gradeModel.EnrollmentId,
                StudentId = gradeModel.StudentId,
                CourseId = gradeModel.CourseId,
                Grade = gradeModel.Grade,
            };
            return View(grade);
        }

        // GET: StudentGrandeController/Create
        public ActionResult Create()
        {
            var students = this.studentDao.GetStudents();
            ViewData["Students"] = new SelectList(students, "Id");

            var courses = this.courseDao.GetCourses();
            ViewData["Courses"] = new SelectList(courses, "CourseId");

            return View();
        }

        // POST: StudentGrandeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentGradeViewModel studentGradeViewModel)
        {
            try
            {
                StudentGrade gradeToAdd = new StudentGrade()
                {
                    StudentId = studentGradeViewModel.StudentId,
                    CourseId=studentGradeViewModel.CourseId,
                    Grade = studentGradeViewModel.Grade,
                };

                this.studentGradeDao.SaveGrade(gradeToAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentGrandeController/Edit/5
        public ActionResult Edit(int id)
        {
            var students = this.studentDao.GetStudents();
            ViewData["Students"] = new SelectList(students, "Id");

            var courses = this.courseDao.GetCourses();
            ViewData["Course"] = new SelectList(courses, "CourseId");

            return View();
        }

        // POST: StudentGrandeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentGradeViewModel studentGradeViewModel)
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
