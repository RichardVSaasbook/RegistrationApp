using RegistrationApp.Utilities;
using System;
using System.Data.Entity;

namespace RegistrationApp.DataAccess
{
    public partial class RegistrationData
    {
        /// <summary>
        /// Register a Student for a Course.
        /// </summary>
        /// <param name="student">The Student to register to the Course.</param>
        /// <param name="course">The Course to register the Student for.</param>
        /// <returns>True if the Registration was successful.</returns>
        public bool RegisterForCourse(Student student, CourseSchedule courseSchedule)
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
                foreach (CourseSchedule existingSchedule in student.CourseSchedules)
                {
                    TimeSpan oldStartTime = existingSchedule.Schedule.StartTime;
                    TimeSpan oldEndTime = ScheduleTime.GetEndTime(oldStartTime, existingSchedule.Schedule.TimeBlocks);

                    if (ScheduleTime.TimesOverlap(startTime, endTime, oldStartTime, oldEndTime))
                    {
                        successful = false;
                    }
                }

                if (successful)
                {
                    courseSchedule.Students.Add(student);
                    successful = db.SaveChanges() > 0;
                }
            }

            return successful;
        }
    }
}
