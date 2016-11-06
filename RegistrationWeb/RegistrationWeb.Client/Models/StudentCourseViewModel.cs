using RegistrationWeb.Domain.RegistrationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationWeb.Client.Models
{
    public class StudentCourseViewModel
    {
        public StudentsListViewModel StudentsListViewModel { get; set; }
        public IEnumerable<CourseScheduleDAO> CourseSchedules { get; set; }
    }
}