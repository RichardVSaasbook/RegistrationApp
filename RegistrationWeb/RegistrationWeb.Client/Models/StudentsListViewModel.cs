using RegistrationWeb.Domain.RegistrationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationWeb.Client.Models
{
    public class StudentsListViewModel
    {
        public IEnumerable<StudentDAO> Students { get; set; }
        public int CurrentStudentId { get; set; }
        public MessageModel Message { get; set; }
        public string CurrentAction { get; set; }
    }
}