using RegistrationWeb.Domain.RegistrationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWeb.Domain.Abstract
{
    /// <summary>
    /// Interface for the RegistrationWeb repository.
    /// </summary>
    public interface IRegistrationRepository
    {
        IEnumerable<StudentScheduleDAO> ListStudentSchedule(int studentId);
        IEnumerable<StudentScheduleDAO> ListStudentBookmarks(int studentId);
        IEnumerable<StudentDAO> ListStudents();
        IEnumerable<CourseScheduleDAO> ListCourses();
        StudentDAO GetStudent(int studentId);
        bool BookmarkCourse(int studentId, int courseScheduleId);
        bool DropCourse(int studentId, int courseScheduleId);
        bool RegisterForCourse(int studentId, int courseScheduleId);
        IEnumerable<CourseDAO> ListCourseInformation();
        bool ScheduleCourse(CourseScheduleDAO courseSchedule);
        bool CancelCourse(int courseScheduleId);
        bool ModifyCourse(int courseScheduleId, int scheduleId, short capacity);
        IEnumerable<StudentDAO> ListEnrolledStudents(int courseId);
        IEnumerable<ScheduleDAO> ListSchedules();
        IEnumerable<PersonDAO> ListPeople();
        IEnumerable<CourseScheduleDAO> ListOpenCourses();
        IEnumerable<CourseScheduleDAO> ListFullCourses();
        bool AddStudent(StudentDAO student);
        bool RemoveStudent(int studentId);
        IEnumerable<CourseScheduleDAO> ListCourseSchedules(int courseId);
        CourseScheduleDAO GetCourseSchedule(int courseScheduleId);
        ScheduleDAO GetSchedule(int scheduleId);
    }
}
