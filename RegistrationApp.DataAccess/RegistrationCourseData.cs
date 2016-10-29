using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp.DataAccess
{
    public partial class RegistrationData
    {
        /// <summary>
        /// Gets the number of Students registered for a Course.
        /// </summary>
        /// <param name="courseSchedule">The CourseSchedule to check the number of Students on.</param>
        /// <returns>The number of Students registered for the Course.</returns>
        public int GetNumberOfStudentsInCourse(CourseSchedule courseSchedule)
        {
            return courseSchedule.StudentSchedules.Where(s => s.Enrolled).ToList().Count;
        }
    }
}
