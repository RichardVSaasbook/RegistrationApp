using RegistrationApp.Utilities;
using System;
using System.Data.Entity;

namespace RegistrationApp.DataAccess
{
    public partial class RegistrationData
    {
        /// <summary>
        /// Register a Student to a Course.
        /// </summary>
        /// <param name="student">The Student to register to the Course.</param>
        /// <param name="course">The Course to register the Student for.</param>
        /// <returns>True if the registration was successful.</returns>
        public bool RegisterForCourse(Student student, CourseSchedule courseSchedule)
        {
            bool successful = true;

            if (CanRegisterForCourse(student, courseSchedule))
            {
                courseSchedule.StudentSchedules.Add(new StudentSchedule
                {
                    Student = student,
                    CourseSchedule = courseSchedule,
                    Enrolled = true
                });
                successful = db.SaveChanges() > 0;
            }

            return successful;
        }

        /// <summary>
        /// Hold a Course for a Student.
        /// </summary>
        /// <param name="student">The Student to hold the class for.</param>
        /// <param name="courseSchedule">The Course to hold for the Student.</param>
        /// <returns>True if the hold was successful.</returns>
        public bool HoldCourse(Student student, CourseSchedule courseSchedule)
        {
            bool successful = true;

            if (CanRegisterForCourse(student, courseSchedule))
            {
                courseSchedule.StudentSchedules.Add(new StudentSchedule
                {
                    Student = student,
                    CourseSchedule = courseSchedule,
                    Enrolled = false
                });
                successful = db.SaveChanges() > 0;
            }

            return successful;
        }

        /// <summary>
        /// Drop a Student's course.
        /// </summary>
        /// <param name="student">The Student to drop the Course from.</param>
        /// <param name="studentSchedule">The Course to drop.</param>
        /// <returns>True if the drop was successful.</returns>
        public bool DropCourse(Student student, StudentSchedule studentSchedule)
        {
            bool successful = student.StudentSchedules.Remove(studentSchedule);

            if (successful)
            {
                successful = db.SaveChanges() > 0;
            }

            return successful;
        }

        /// <summary>
        /// Determines whether or not a Student can register for a course.
        /// </summary>
        /// <param name="student">The Student to register to the Course.</param>
        /// <param name="course">The Course to register the Student for.</param>
        /// <returns>True if the Student can register for the Course.</returns>
        private bool CanRegisterForCourse(Student student, CourseSchedule courseSchedule)
        {
            bool successful = true;

            TimeSpan startTime = courseSchedule.Schedule.StartTime;
            TimeSpan endTime = ScheduleTime.GetEndTime(startTime, courseSchedule.Schedule.TimeBlocks);

            if (courseSchedule.ProfessorId == student.PersonId)
            {
                successful = false;
            }
            else if (GetNumberOfStudentsInCourse(courseSchedule) >= courseSchedule.Capacity)
            {
                successful = false;
            }
            else
            {
                foreach (StudentSchedule existingSchedule in student.StudentSchedules)
                {
                    TimeSpan oldStartTime = existingSchedule.CourseSchedule.Schedule.StartTime;
                    TimeSpan oldEndTime = ScheduleTime.GetEndTime(oldStartTime, existingSchedule.CourseSchedule.Schedule.TimeBlocks);

                    if (ScheduleTime.TimesOverlap(startTime, endTime, oldStartTime, oldEndTime))
                    {
                        successful = false;
                    }
                }
            }

            return successful;
        }
    }
}
