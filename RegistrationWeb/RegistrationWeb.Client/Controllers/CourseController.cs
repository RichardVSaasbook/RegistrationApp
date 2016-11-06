using RegistrationWeb.Client.Models;
using RegistrationWeb.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistrationWeb.Client.Controllers
{
    public class CourseController : Controller
    {
        private IRegistrationRepository repository;

        public CourseController(IRegistrationRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(new CourseListViewModel
            {
                CurrentCourseId = 0,
                CourseSchedules = repository.ListCourses().OrderBy(c => c.Schedule.StartTime).ThenBy(c => c.Schedule.EndTime),
                Message = GetMessage(),
                CurrentAction = "Index"
            });
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