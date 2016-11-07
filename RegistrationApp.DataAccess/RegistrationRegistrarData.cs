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
            List<CourseSchedule> courseSchedules = new List<CourseSchedule>();

            foreach (CourseSchedule courseSchedule in db.CourseSchedules)
            {
                if (GetNumberOfStudentsInCourse(courseSchedule) < courseSchedule.Capacity)
                {
                    courseSchedules.Add(courseSchedule);
                }
            }

            return courseSchedules;
        }

        /// <summary>
        /// List all Courses that don't have space for more Students.
        /// </summary>
        /// <returns>The List of Courses.</returns>
        public List<CourseSchedule> ListFullCourses()
        {
            List<CourseSchedule> courseSchedules = new List<CourseSchedule>();

            foreach (CourseSchedule courseSchedule in db.CourseSchedules)
            {
                if (GetNumberOfStudentsInCourse(courseSchedule) >= courseSchedule.Capacity)
                {
                    courseSchedules.Add(courseSchedule);
                }
            }

            return courseSchedules;
        }

        /// <summary>
        /// Adds a Student to the student body.
        /// </summary>
        /// <param name="student">The Student to add.</param>
        /// <returns>True if the addition was successful.</returns>
        public bool AddStudent(Student student)
        {
            db.Students.Add(student);
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// Removes a Student from the student body.
        /// </summary>
        /// <param name="student">The Student to remove.</param>
        /// <returns>True if the addition was successful.</returns>
        public bool RemoveStudent(Student student)
        {
            db.Students.Remove(student);
            return db.SaveChanges() > 0;
        }
    }
}
