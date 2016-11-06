using RegistrationWeb.Client.Models;
using RegistrationWeb.Domain.Abstract;
using RegistrationWeb.Domain.RegistrationServiceReference;
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
            return View(new StudentCourseViewModel
            {
                StudentsListViewModel = new StudentsListViewModel
                {
                    CurrentStudentId = studentId,
                    Students = repository.ListStudents(),
                    Message = GetMessage(),
                    CurrentAction = "Show"
                },
                CourseSchedules = repository.ListStudentSchedule(studentId)
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public ViewResult CourseBookmarks(int studentId)
        {
            return View(new StudentCourseViewModel
            {
                StudentsListViewModel = new StudentsListViewModel
                {
                    CurrentStudentId = studentId,
                    Students = repository.ListStudents(),
                    Message = GetMessage(),
                    CurrentAction = "CourseBookmarks"
                },
                CourseSchedules = repository.ListStudentBookmarks(studentId)
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public ViewResult ShowCourses(int studentId)
        {
            List<StudentScheduleDAO> courseSchedules = new List<StudentScheduleDAO>();

            foreach (CourseScheduleDAO courseSchedule in repository.ListCourses())
            {
                courseSchedules.Add(new StudentScheduleDAO()
                {
                    CourseSchedule = courseSchedule,
                    Student = repository.GetStudent(studentId),
                    Enrolled = false
                });
            }

            return View(new StudentCourseViewModel
            {
                StudentsListViewModel = new StudentsListViewModel
                {
                    CurrentStudentId = studentId,
                    Students = repository.ListStudents(),
                    Message = GetMessage(),
                    CurrentAction = "ShowCourses"
                },
                CourseSchedules = courseSchedules
            });
        }

        /// <summary>
        /// Drop a Student's schedule.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="scheduleId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult DropCourse(int studentId, int courseScheduleId, string redirectSuccess, string redirectFailure)
        {
            if (repository.DropCourse(studentId, courseScheduleId))
            {
                TempData["message"] = new MessageModel { Text = "Succesfully dropped course!", Type = "success" };
                return RedirectToAction(redirectSuccess, new { studentId });
            }
            else
            {
                TempData["message"] = new MessageModel { Text = "Could not drop the course.", Type = "danger" };
                return RedirectToAction(redirectFailure, new { studentId });
            }
        }

        /// <summary>
        /// Bookmark a Course to add later.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseScheduleId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult BookmarkCourse(int studentId, int courseScheduleId, string redirectSuccess, string redirectFailure)
        {
            if (repository.BookmarkCourse(studentId, courseScheduleId))
            {
                TempData["message"] = new MessageModel { Text = "Succesfully bookmarked the course!", Type = "success" };
                return RedirectToAction(redirectSuccess, new { studentId });
            }
            else
            {
                TempData["message"] = new MessageModel { Text = "Could not bookmark the course.", Type = "danger" };
                return RedirectToAction(redirectFailure, new { studentId });
            }
        }

        /// <summary>
        /// Register a Course for a Student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseScheduleId"></param>
        /// <param name="redirectSuccess"></param>
        /// <param name="redirectFailure"></param>
        /// <returns></returns>
        public RedirectToRouteResult AddCourse(int studentId, int courseScheduleId, string redirectSuccess, string redirectFailure)
        {
            if (repository.RegisterForCourse(studentId, courseScheduleId))
            {
                TempData["message"] = new MessageModel { Text = "Succesfully registered the course!", Type = "success" };
                return RedirectToAction(redirectSuccess, new { studentId });
            }
            else
            {
                TempData["message"] = new MessageModel { Text = "Could not register the course.", Type = "danger" };
                return RedirectToAction(redirectFailure, new { studentId });
            }
        }

        /// <summary>
        /// Get the current Message.
        /// </summary>
        /// <returns>The current Message.</returns>
        private MessageModel GetMessage()
        {
            MessageModel message;

            try
            {
                message = (MessageModel)TempData["message"];

                if (message == null)
                {
                    message = new NullMessageModel();
                }
            }
            catch(Exception e)
            {
                message = new NullMessageModel();
            }

            return message;
        }
    }
}