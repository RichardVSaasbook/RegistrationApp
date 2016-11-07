using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RegistrationWeb.Client
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new { controller = "Home", action = "Index" }
            );

            #region Students
            routes.MapRoute(
                null,
                "student",
                new { controller = "Student", action = "Index" }
            );

            routes.MapRoute(
                null,
                "student/{studentId}",
                new { controller = "Student", action = "Show" }
            );

            routes.MapRoute(
                null,
                "student/{studentId}/add-course",
                new { controller = "Student", action = "ShowCourses" }
            );

            routes.MapRoute(
                null,
                "student/{studentId}/bookmarks",
                new { controller = "Student", action = "CourseBookmarks" }
            );

            routes.MapRoute(
                "DropStudentCourse",
                "student/{studentId}/drop/{courseScheduleId}",
                new { controller = "Student", action = "DropCourse" }
            );

            routes.MapRoute(
                "AddStudentCourse",
                "student/{studentId}/add/{courseScheduleId}",
                new { controller = "Student", action = "AddCourse" }
            );

            routes.MapRoute(
                "BookmarkStudentCourse",
                "student/{studentId}/bookmark/{courseScheduleId}",
                new { controller = "Student", action = "BookmarkCourse" }
            );
            #endregion

            routes.MapRoute(
                null,
                "course",
                new { controller = "Course", action = "Index" }
            );

            routes.MapRoute(
                null,
                "course/{courseId}",
                new { controller = "Course", action = "Show" }
            );

            routes.MapRoute(
                null,
                "course/{courseId}/modify/{courseScheduleId}",
                new { controller = "Course", action = "Edit" }
            );

            routes.MapRoute(
                "ModifyCourse",
                "course/{courseId}/modify/{courseScheduleId}/update",
                new { controller = "Course", action = "Update" }
            );

            routes.MapRoute(
                "UnscheduleCourse",
                "course/{courseScheduleId}/unschedule",
                new { controller = "Course", action = "Unschedule" }
            );
        }
    }
}
