using System.Collections.Generic;
using System.Linq;

namespace RegistrationApp.DataAccess
{
    public partial class RegistrationData
    {
        /// <summary>
        /// List all Courses that still have space for more Students.
        /// </summary>
        /// <returns>The List of Courses.</returns>
        public List<CourseSchedule> ListOpenCourses()
        {
            return db.CourseSchedules.Where(s => GetNumberOfStudentsInCourse(s) < s.Capacity).ToList();
        }

        /// <summary>
        /// List all Courses that don't have space for more Students.
        /// </summary>
        /// <returns>The List of Courses.</returns>
        public List<CourseSchedule> ListFullCourses()
        {
            return db.CourseSchedules.Where(s => GetNumberOfStudentsInCourse(s) >= s.Capacity).ToList();
        }
    }
}
