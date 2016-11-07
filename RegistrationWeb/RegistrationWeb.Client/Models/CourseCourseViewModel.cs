using RegistrationWeb.Domain.RegistrationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationWeb.Client.Models
{
    public class CourseCourseViewModel
    {
        public CourseListViewModel CourseListViewModel { get; set; }
        public IEnumerable<CourseScheduleDAO> CourseSchedules { get; set; }
        public SelectList SchedulesList { get; set; }
        public SelectList PeopleList { get; set; }
        public string Capacity { get; set; }
        public int CourseScheduleId { get; set; }
        public IEnumerable<StudentDAO> RegisteredStudents { get; set; }
    }
}