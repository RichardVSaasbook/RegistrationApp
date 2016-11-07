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
            CourseScheduleDAO courseSchedule = repository.GetCourseSchedule(courseScheduleId);

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
                SchedulesList = new SelectList(GetScheduleList(courseScheduleId), "Value", "Text"),
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

        public ViewResult New(int courseId)
        {
            List<SelectListItem> peopleList = new List<SelectListItem>();

            foreach (PersonDAO person in repository.ListPeople())
            {
                peopleList.Add(new SelectListItem
                {
                    Value = person.Id.ToString(),
                    Text = person.Name
                });
            }

            return View(new CourseCourseViewModel
            {
                CourseListViewModel = new CourseListViewModel
                {
                    CurrentCourseId = courseId,
                    Courses = repository.ListCourseInformation(),
                    Message = GetMessage(),
                    CurrentAction = "New"
                },
                SchedulesList = new SelectList(GetScheduleList(0), "Value", "Text"),
                PeopleList = new SelectList(peopleList, "Value", "Text"),
                Capacity = "0",
                CourseScheduleId = 0
            });
        }

        public RedirectToRouteResult Create(int courseId, string professor, string schedule, string capacity, string redirectSuccess, string redirectFailure)
        {
            if (repository.ScheduleCourse(courseId, int.Parse(professor), int.Parse(schedule), short.Parse(capacity)))
            {
                TempData["message"] = new MessageModel { Text = "Succesfully scheduled course!", Type = "success" };
                return RedirectToAction(redirectSuccess, new { courseId });
            }
            else
            {
                TempData["message"] = new MessageModel { Text = "Could not schedule the course.", Type = "danger" };
                return RedirectToAction(redirectFailure, new { courseId });
            }
        }

        public RedirectToRouteResult Unschedule(int courseId, int courseScheduleId, string redirectSuccess, string redirectFailure)
        {
            if (repository.CancelCourse(courseScheduleId))
            {
                TempData["message"] = new MessageModel { Text = "Succesfully unscheduled course!", Type = "success" };
                return RedirectToAction(redirectSuccess, new { courseId });
            }
            else
            {
                TempData["message"] = new MessageModel { Text = "Could not unschedule the course.", Type = "danger" };
                return RedirectToAction(redirectFailure, new { courseId });
            }
        }

        public ViewResult Students(int courseId, int courseScheduleId)
        {
            List<SelectListItem> peopleList = new List<SelectListItem>();

            return View(new CourseCourseViewModel
            {
                CourseListViewModel = new CourseListViewModel
                {
                    CurrentCourseId = courseId,
                    Courses = repository.ListCourseInformation(),
                    Message = GetMessage(),
                    CurrentAction = "Students"
                },
                CourseScheduleId = courseScheduleId,
                RegisteredStudents = repository.ListEnrolledStudents(courseScheduleId)
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

        private string FormatTime(TimeSpan time)
        {
            DateTime dateTime = DateTime.Today.Add(time);
            return dateTime.ToString("hh:mm tt");
        }

        private List<SelectListItem> GetScheduleList(int courseScheduleId)
        {
            List<SelectListItem> scheduleList = new List<SelectListItem>();
            CourseScheduleDAO courseSchedule = new CourseScheduleDAO { Schedule = new ScheduleDAO { Id = 0 } };

            if (courseScheduleId > 0)
            {
                courseSchedule = repository.GetCourseSchedule(courseScheduleId);
            }

            foreach (ScheduleDAO schedule in repository.ListSchedules())
            {
                scheduleList.Add(new SelectListItem
                {
                    Value = schedule.Id.ToString(),
                    Text = FormatTime(schedule.StartTime) + " - " + FormatTime(schedule.EndTime),
                    Selected = courseSchedule.Schedule.Id == schedule.Id
                });
            }

            return scheduleList;
        }
    }
}