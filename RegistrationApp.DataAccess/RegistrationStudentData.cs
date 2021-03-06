﻿using RegistrationApp.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            return CreateStudentSchedule(student, courseSchedule, true);
        }

        /// <summary>
        /// Hold a Course for a Student.
        /// </summary>
        /// <param name="student">The Student to hold the class for.</param>
        /// <param name="courseSchedule">The Course to hold for the Student.</param>
        /// <returns>True if the hold was successful.</returns>
        public bool HoldCourse(Student student, CourseSchedule courseSchedule)
        {
            return CreateStudentSchedule(student, courseSchedule, false);
        }

        /// <summary>
        /// Drop a Student's course.
        /// </summary>
        /// <param name="student">The Student to drop the Course from.</param>
        /// <param name="studentSchedule">The Course to drop.</param>
        /// <returns>True if the drop was successful.</returns>
        public bool DropCourse(Student student, StudentSchedule studentSchedule)
        {
            bool successful = db.StudentSchedules.Remove(studentSchedule) != null;

            if (successful)
            {
                successful = db.SaveChanges() > 0;
            }

            return successful;
        }

        /// <summary>
        /// Reutnrs a list of all Courses the Student is registered for.
        /// </summary>
        /// <param name="student">The Student to list Courses from.</param>
        /// <returns>The List of Courses.</returns>
        public List<StudentSchedule> ListStudentSchedule(Student student) {
            return student.StudentSchedules.Where(s => s.Enrolled).ToList();
        }

        /// <summary>
        /// Returns a list of all Courses the Student has bookmarked.
        /// </summary>
        /// <param name="student">The Student to list bookmarked Courses from.</param>
        /// <returns>The List of bookmarked Courses.</returns>
        public List<StudentSchedule> ListStudentBookmarks(Student student)
        {
            return student.StudentSchedules.Where(s => !s.Enrolled).ToList();
        }

        /// <summary>
        /// Lists all of the Students in the database.
        /// </summary>
        /// <returns>The List of Students.</returns>
        public List<Student> ListStudents()
        {
            return db.Students.ToList();
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
                foreach (StudentSchedule existingSchedule in student.StudentSchedules.Where(s => s.Enrolled))
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

        /// <summary>
        /// Create a new StudentSchedule with the given Enrolled value.
        /// </summary>
        /// <param name="student"></param>
        /// <param name="courseSchedule"></param>
        /// <param name="enrolled"></param>
        /// <returns></returns>
        private bool CreateStudentSchedule(Student student, CourseSchedule courseSchedule, bool enrolled)
        {
            bool successful = CanRegisterForCourse(student, courseSchedule);

            if (successful)
            {
                StudentSchedule existingSchedule = db.StudentSchedules.Where(s => s.StudentId == student.PersonId && s.CourseScheduleId == courseSchedule.CourseScheduleId).FirstOrDefault();

                if (existingSchedule == null)
                {
                    db.StudentSchedules.Add(new StudentSchedule
                    {
                        Student = student,
                        CourseSchedule = courseSchedule,
                        Enrolled = enrolled
                    });
                }
                else
                {
                    existingSchedule.Enrolled = enrolled;
                    var entry = db.Entry(existingSchedule);
                    entry.State = EntityState.Modified;
                }
                
                successful = db.SaveChanges() > 0;
            }

            return successful;
        }
    }
}
