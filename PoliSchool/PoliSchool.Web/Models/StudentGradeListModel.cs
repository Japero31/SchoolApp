﻿namespace PoliSchool.Web.Models
{
    public class StudentGradeListModel
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set;}
        public int CourseId { get; set; }
        public decimal? Grade { get; set; }

    }
}
