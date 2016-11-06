using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RegistrationApp.DataClient.Models;
using RegistrationApp.DataAccess;

namespace RegistrationApp.DataClient
{
    /// <summary>
    /// Service class for the RegistrationApp.
    /// </summary>
    public class RegistrationService : IRegistrationService
    {
        private RegistrationData data;

        /// <summary>
        /// Create the RegistrationService.
        /// </summary>
        public RegistrationService()
        {
            data = new RegistrationData();
        }

        /// <summary>
        /// Drops a Course for a Student.
        /// </summary>
        /// <param name="studentDAO">The Student to drop the Course on.</param>
        /// <param name="studentScheduleDAO">The Course to drop.</param>
        /// <returns>True if the drop was successful.</returns>
        public bool DropCourse(int studentId, int courseScheduleId)
        {
            RegistrationData data = new RegistrationData();
            return data.DropCourse(data.FindOrCreateStudent(studentId), data.FindOrCreateStudentSchedule(courseScheduleId, studentId));
        }

        /// <summary>
        /// Get the Student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public StudentDAO GetStudent(int studentId)
        {
            RegistrationData data = new RegistrationData();
            return Mapper.MapToStudentDAO(data.FindOrCreateStudent(studentId));
        }

        /// <summary>
        /// Holds a CourseSchedule for a Student to look at later.
        /// </summary>
        /// <param name="studentDAO">The Student to hold the Course for.</param>
        /// <param name="courseScheduleDAO">The Course to hold.</param>
        /// <returns>True if the hold was successful.</returns>
        public bool HoldCourse(int studentId, int courseScheduleId)
        {
            RegistrationData data = new RegistrationData();
            return data.HoldCourse(data.FindOrCreateStudent(studentId), data.FindOrCreateCourseSchedule(courseScheduleId));
        }

        /// <summary>
        /// List all of the Courses.
        /// </summary>
        /// <returns>The List of all Courses.</returns>
        public List<CourseScheduleDAO> ListCourses()
        {
            List<CourseScheduleDAO> courseScheduleDAOs = new List<CourseScheduleDAO>();
            
            foreach (CourseSchedule courseSchedule in data.ListCourses())
            {
                courseScheduleDAOs.Add(Mapper.MapToCourseScheduleDAO(courseSchedule));
            }

            return courseScheduleDAOs;
        }

        /// <summary>
        /// List the bookmarked courses for a Student.
        /// </summary>
        /// <param name="studentId">The Student to List Courses for.</param>
        /// <returns>The List of bookmarked Courses.</returns>
        public List<StudentScheduleDAO> ListStudentBookmarks(int studentId)
        {
            StudentDAO studentDAO = Mapper.MapToStudentDAO(data.FindOrCreateStudent(studentId));
            List<StudentScheduleDAO> studentScheduleDAOs = new List<StudentScheduleDAO>();

            foreach (StudentSchedule studentSchedule in data.ListStudentBookmarks(Mapper.MapToStudent(studentDAO)))
            {
                studentScheduleDAOs.Add(Mapper.MapToStudentScheduleDAO(studentSchedule));
            }

            return studentScheduleDAOs;
        }

        /// <summary>
        /// List all of the Students in the database.
        /// </summary>
        /// <returns>The List of StudentDAOs.</returns>
        public List<StudentDAO> ListStudents()
        {
            List<StudentDAO> studentDAOs = new List<StudentDAO>();

            foreach (Student student in data.ListStudents())
            {
                studentDAOs.Add(Mapper.MapToStudentDAO(student));
            }

            return studentDAOs;
        }

        /// <summary>
        /// List the Students enrolled CourseSchedules.
        /// </summary>
        /// <param name="studentDAO">The Student to grab a list of.</param>
        /// <returns>The List of CourseSchedules.</returns>
        public List<StudentScheduleDAO> ListStudentSchedule(int studentId)
        {
            StudentDAO studentDAO = Mapper.MapToStudentDAO(data.FindOrCreateStudent(studentId));
            List<StudentScheduleDAO> studentScheduleDAOs = new List<StudentScheduleDAO>();

            foreach (StudentSchedule studentSchedule in data.ListStudentSchedule(Mapper.MapToStudent(studentDAO)))
            {
                studentScheduleDAOs.Add(Mapper.MapToStudentScheduleDAO(studentSchedule));
            }

            return studentScheduleDAOs;
        }

        /// <summary>
        /// Register a Course for a Student.
        /// </summary>
        /// <param name="studentDAO">The Student to register for.</param>
        /// <param name="courseScheduleDAO">The CourseSchedule to register for.</param>
        /// <returns>True if the registration was successful.</returns>
        public bool RegisterForCourse(int studentId, int courseScheduleId)
        {
            return data.RegisterForCourse(data.FindOrCreateStudent(studentId), data.FindOrCreateCourseSchedule(courseScheduleId));
        }
    }
}
