using RegistrationWeb.Client.Models;
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

        /// <summary>
        /// View the Student index.
        /// </summary>
        /// <returns>The View for the Student Index.</returns>
        public ViewResult Index()
        {
            return View(new StudentsListViewModel
            {
                CurrentStudentId = 0,
                Students = repository.ListStudents()
            });
        }

        /// <summary>
        /// Show the CourseSchedule for the Student and display some links for functionality.
        /// </summary>
        /// <param name="studentId">The Id of the Student to show.</param>
        /// <returns>The View for the Student Show.</returns>
        public ViewResult Show(int studentId)
        {
            return View(new StudentCourseViewModel {
                StudentsListViewModel = new StudentsListViewModel
                {
                    CurrentStudentId = studentId,
                    Students = repository.ListStudents()
                },
                CourseSchedules = repository.ListStudentSchedule(studentId)
            });
        }
    }
}