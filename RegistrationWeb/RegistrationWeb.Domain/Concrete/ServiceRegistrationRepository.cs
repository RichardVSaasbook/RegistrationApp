using RegistrationWeb.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrationWeb.Domain.RegistrationServiceReference;

namespace RegistrationWeb.Domain.Concrete
{
    public class ServiceRegistrationRepository : IRegistrationRepository
    {
        private RegistrationServiceClient rsc = new RegistrationServiceClient();

        /// <summary>
        /// List a Student's registered courses.
        /// </summary>
        /// <param name="student">The Student to get courses from.</param>
        /// <returns>The List of registered Courses.</returns>
        public IEnumerable<StudentScheduleDAO> ListStudentSchedule(int studentId)
        {
            return rsc.ListStudentSchedule(studentId);
        }

        /// <summary>
        /// Lists all Students in the database.
        /// </summary>
        /// <returns>The List of StudentDAOs.</returns>
        public IEnumerable<StudentDAO> ListStudents()
        {
            return rsc.ListStudents();
        }

        /// <summary>
        /// Lists a Student's bookmarked Courses.
        /// </summary>
        /// <param name="studentId">The id of the Student.</param>
        /// <returns>The List of Student bookmarks.</returns>
        public IEnumerable<StudentScheduleDAO> ListStudentBookmarks(int studentId)
        {
            return rsc.ListStudentBookmarks(studentId);
        }

        /// <summary>
        /// Lists all of the Courses available.
        /// </summary>
        /// <returns>The List of Courses.</returns>
        public IEnumerable<CourseScheduleDAO> ListCourses()
        {
            return rsc.ListCourses();
        }

        /// <summary>
        /// Get a Student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public StudentDAO GetStudent(int studentId)
        {
            return rsc.GetStudent(studentId);
        }

        /// <summary>
        /// Bookmark a Course for a Student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseScheduleId"></param>
        /// <returns></returns>
        public bool BookmarkCourse(int studentId, int courseScheduleId)
        {
            return rsc.HoldCourse(studentId, courseScheduleId);
        }

        /// <summary>
        /// Drop a Student's Course.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseScheduleId"></param>
        /// <returns></returns>
        public bool DropCourse(int studentId, int courseScheduleId)
        {
            return rsc.DropCourse(studentId, courseScheduleId);
        }

        /// <summary>
        /// Register the Course for the Student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseScheduleId"></param>
        /// <returns></returns>
        public bool RegisterForCourse(int studentId, int courseScheduleId)
        {
            return rsc.RegisterForCourse(studentId, courseScheduleId);
        }

        public IEnumerable<CourseDAO> ListCourseInformation()
        {
            return rsc.ListCourseInformation();
        }

        public bool ScheduleCourse(int courseId, int professorId, int scheduleId, short capacity)
        {
            return rsc.ScheduleCourse(courseId, professorId, scheduleId, capacity);
        }

        public bool CancelCourse(int courseScheduleId)
        {
            return rsc.CancelCourse(courseScheduleId);
        }

        public bool ModifyCourse(int courseScheduleId, int scheduleId, short capacity)
        {
            return rsc.ModifyCourse(courseScheduleId, scheduleId, capacity);
        }

        public IEnumerable<StudentDAO> ListEnrolledStudents(int courseId)
        {
            return rsc.ListEnrolledStudents(courseId);
        }

        public IEnumerable<ScheduleDAO> ListSchedules()
        {
            return rsc.ListSchedules();
        }

        public IEnumerable<PersonDAO> ListPeople()
        {
            return rsc.ListPeople();
        }

        public IEnumerable<CourseScheduleDAO> ListOpenCourses()
        {
            return rsc.ListOpenCourses();
        }

        public IEnumerable<CourseScheduleDAO> ListFullCourses()
        {
            return rsc.ListFullCourses();
        }

        public bool AddStudent(string name, int majorId)
        {
            return rsc.AddStudent(name, majorId);
        }

        public bool RemoveStudent(int studentId)
        {
            return rsc.RemoveStudent(studentId);
        }

        public IEnumerable<CourseScheduleDAO> ListCourseSchedules(int courseId)
        {
            return rsc.ListCourseSchedule(courseId);
        }

        public CourseScheduleDAO GetCourseSchedule(int courseScheduleId)
        {
            return rsc.GetCourseSchedule(courseScheduleId);
        }

        public ScheduleDAO GetSchedule(int scheduleId)
        {
            return rsc.GetSchedule(scheduleId);
        }
    }
}
