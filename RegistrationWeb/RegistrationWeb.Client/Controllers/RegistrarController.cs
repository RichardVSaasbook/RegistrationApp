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
    public class RegistrarController : Controller
    {
        private IRegistrationRepository repository;

        public RegistrarController(IRegistrationRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Students()
        {
            return View("Students", "~/Views/Shared/_LayoutNoSidebar.cshtml", new RegistrarViewModel
            {
                CurrentAction = "Students",
                Students = repository.ListStudents().OrderBy(s => s.Person.Name),
                Message = GetMessage()
            });
        }

        public ViewResult FullCourses()
        {
            return View("FullCourses", "~/Views/Shared/_LayoutNoSidebar.cshtml", new RegistrarViewModel
            {
                CurrentAction = "FullCourses",
                CourseSchedules = repository.ListFullCourses(),
                Message = GetMessage()
            });
        }

        public ViewResult OpenCourses()
        {
            return View("FullCourses", "~/Views/Shared/_LayoutNoSidebar.cshtml", new RegistrarViewModel
            {
                CurrentAction = "OpenCourses",
                CourseSchedules = repository.ListOpenCourses(),
                Message = GetMessage()
            });
        }

        public ViewResult NewStudent()
        {
            List<SelectListItem> departmentsList = new List<SelectListItem>();

            foreach (DepartmentDAO department in repository.ListDepartments())
            {
                departmentsList.Add(new SelectListItem
                {
                    Value = department.Id.ToString(),
                    Text = department.Name
                });
            }

            return View("NewStudent", "~/Views/Shared/_LayoutNoSidebar.cshtml", new RegistrarViewModel
            {
                CurrentAction = "NewStudent",
                DepartmentsList = new SelectList(departmentsList, "Value", "Text"),
                Message = GetMessage()
            });
        }

        public RedirectToRouteResult CreateStudent(string name, string department, string redirectSuccess, string redirectFailure)
        {
            if (repository.AddStudent(name, int.Parse(department)))
            {
                TempData["message"] = new MessageModel { Text = "Succesfully added student!", Type = "success" };
                return RedirectToAction(redirectSuccess);
            }
            else
            {
                TempData["message"] = new MessageModel { Text = "Could not add the student.", Type = "danger" };
                return RedirectToAction(redirectFailure);
            }
        }

        public RedirectToRouteResult RemoveStudent(int studentId, string redirectSuccess, string redirectFailure)
        {
            if (repository.RemoveStudent(studentId))
            {
                TempData["message"] = new MessageModel { Text = "Succesfully removed student!", Type = "success" };
                return RedirectToAction(redirectSuccess);
            }
            else
            {
                TempData["message"] = new MessageModel { Text = "Could not remove the student.", Type = "danger" };
                return RedirectToAction(redirectFailure);
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
            catch (Exception e)
            {
                message = new NullMessageModel();
            }

            return message;
        }
    }
}