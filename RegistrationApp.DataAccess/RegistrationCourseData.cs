﻿using RegistrationApp.Utilities;
using System;
using System.Linq;

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

        /// <summary>
        /// Schedule a new time block for a Course.
        /// </summary>
        /// <param name="course">The Course to schedule.</param>
        /// <param name="schedule">The Schedule time the Course will take place over.</param>
        /// <param name="professor">The Person who will be the professor for the class.</param>
        /// <param name="capacity">The total capacity of the Course.</param>
        /// <returns>True if the addition was successful.</returns>
        public bool ScheduleCourse(Course course, Schedule schedule, Person professor, short capacity)
        {
            bool successful = true;

            TimeSpan startTime = schedule.StartTime;
            TimeSpan endTime = ScheduleTime.GetEndTime(startTime, schedule.TimeBlocks);

            if (capacity <= 0)
            {
                successful = false;
            }
            else
            {
                foreach (CourseSchedule existingSchedule in professor.CourseSchedules)
                {
                    TimeSpan oldStartTime = existingSchedule.Schedule.StartTime;
                    TimeSpan oldEndTime = ScheduleTime.GetEndTime(oldStartTime, existingSchedule.Schedule.TimeBlocks);

                    if (ScheduleTime.TimesOverlap(startTime, endTime, oldStartTime, oldEndTime))
                    {
                        successful = false;
                    }
                }
            }

            if (successful)
            {
                db.CourseSchedules.Add(new CourseSchedule {
                    Course = course,
                    Schedule = schedule,
                    Person = professor,
                    Capacity = capacity
                });
                db.SaveChanges();
            }

            return successful;
        }
    }
}
