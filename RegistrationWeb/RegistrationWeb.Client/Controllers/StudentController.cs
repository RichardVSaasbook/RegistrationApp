using RegistrationWeb.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationWeb.Client.Controllers
{
    /// <summary>
    /// Controller for Student functionality.
    /// </summary>
    public class StudentController : Controller
    {
        private IRegistrationRepository repository;

        /// <summary>
        /// Create the new StudentController.
        /// </summary>
        /// <param name="repository">The repository to use.</param>
        public StudentController(IRegistrationRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(int studentId = 1)
        {
            return View(repository.ListStudentSchedule(studentId));
        }
    }
}