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
        public bool DropCourse(StudentDAO studentDAO, StudentScheduleDAO studentScheduleDAO)
        {
            return data.DropCourse(Mapper.MapToStudent(studentDAO), Mapper.MapToStudentSchedule(studentScheduleDAO));
        }

        /// <summary>
        /// Holds a CourseSchedule for a Student to look at later.
        /// </summary>
        /// <param name="studentDAO">The Student to hold the Course for.</param>
        /// <param name="courseScheduleDAO">The Course to hold.</param>
        /// <returns>True if the hold was successful.</returns>
        public bool HoldCourse(StudentDAO studentDAO, CourseScheduleDAO courseScheduleDAO)
        {
            return data.HoldCourse(Mapper.MapToStudent(studentDAO), Mapper.MapToCourseSchedule(courseScheduleDAO));
        }

        /// <summary>
        /// List the Students enrolled CourseSchedules.
        /// </summary>
        /// <param name="studentDAO">The Student to grab a list of.</param>
        /// <returns>The List of CourseSchedules.</returns>
        public List<CourseScheduleDAO> ListStudentSchedule(int studentId)
        {
            StudentDAO studentDAO = Mapper.MapToStudentDAO(data.FindOrCreateStudent(studentId));
            List<CourseScheduleDAO> courseScheduleDAOs = new List<CourseScheduleDAO>();

            foreach (CourseSchedule courseSchedule in data.ListStudentSchedule(Mapper.MapToStudent(studentDAO)))
            {
                courseScheduleDAOs.Add(Mapper.MapToCourseScheduleDAO(courseSchedule));
            }

            return courseScheduleDAOs;
        }

        /// <summary>
        /// Register a Course for a Student.
        /// </summary>
        /// <param name="studentDAO">The Student to register for.</param>
        /// <param name="courseScheduleDAO">The CourseSchedule to register for.</param>
        /// <returns>True if the registration was successful.</returns>
        public bool RegisterForCourse(StudentDAO studentDAO, CourseScheduleDAO courseScheduleDAO)
        {
            return data.RegisterForCourse(Mapper.MapToStudent(studentDAO), Mapper.MapToCourseSchedule(courseScheduleDAO));
        }
    }
}
