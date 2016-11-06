using RegistrationWeb.Domain.RegistrationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationWeb.Client.Models
{
    public class CourseListViewModel
    {
        public IEnumerable<CourseScheduleDAO> CourseSchedules { get; set; }
        public int CurrentCourseId { get; set; }
        public MessageModel Message { get; set; }
        public string CurrentAction { get; set; }
    }
}