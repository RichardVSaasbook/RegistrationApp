using RegistrationWeb.Domain.RegistrationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationWeb.Client.Models
{
    public class RegistrarViewModel
    {
        public string CurrentAction { get; set; }
        public IEnumerable<StudentDAO> Students { get; set; }
        public MessageModel Message { get; set; }
        public IEnumerable<CourseScheduleDAO> CourseSchedules { get; set; }
        public SelectList DepartmentsList { get; set; }
    }
}