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
                Courses = repository.ListCourseInformation(),
                Message = GetMessage(),
                CurrentAction = "Index"
            });
        }

        public ViewResult Show(int courseId)
        {
            return View(new CourseCourseViewModel
            {
                CourseListViewModel = new CourseListViewModel
                {
                    CurrentCourseId = courseId,
                    Courses = repository.ListCourseInformation(),
                    Message = GetMessage(),
                    CurrentAction = "Show"
                },
                CourseSchedules = repository.ListCourseSchedules(courseId)
            });
        }

        public ViewResult Edit(int courseId, int courseScheduleId)
        {
            List<SelectListItem> scheduleList = new List<SelectListItem>();
            CourseScheduleDAO courseSchedule = repository.GetCourseSchedule(courseScheduleId);

            foreach (ScheduleDAO schedule in repository.ListSchedules())
            {
                scheduleList.Add(new SelectListItem
                {
                    Value = schedule.Id.ToString(),
                    Text = FormatTime(schedule.StartTime) + " - " + FormatTime(schedule.EndTime),
                    Selected = courseSchedule.Schedule.Id == schedule.Id
                });
            }

            return View(new CourseCourseViewModel
            {
                CourseListViewModel = new CourseListViewModel
                {
                    CurrentCourseId = courseId,
                    Courses = repository.ListCourseInformation(),
                    Message = GetMessage(),
                    CurrentAction = "Edit"
                },
                CourseSchedules = repository.ListCourseSchedules(courseId),
                SchedulesList = new SelectList(scheduleList, "Value", "Text"),
                Capacity = courseSchedule.Capacity.ToString(),
                CourseScheduleId = courseScheduleId
            });
        }

        public RedirectToRouteResult Update(int courseId, int courseScheduleId, string schedule, string capacity, string redirectSuccess, string redirectFailure)
        {
            if (repository.ModifyCourse(courseScheduleId, int.Parse(schedule), short.Parse(capacity)))
            {
                TempData["message"] = new MessageModel { Text = "Succesfully modified course!", Type = "success" };
                return RedirectToAction(redirectSuccess, new { courseId });
            }
            else
            {
                TempData["message"] = new MessageModel { Text = "Could not modify the course.", Type = "danger" };
                return RedirectToAction(redirectFailure, new { courseId, courseScheduleId });
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

        private string FormatTime(TimeSpan time)
        {
            DateTime dateTime = DateTime.Today.Add(time);
            return dateTime.ToString("hh:mm tt");
        }
    }
}