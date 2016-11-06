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
    }
}
