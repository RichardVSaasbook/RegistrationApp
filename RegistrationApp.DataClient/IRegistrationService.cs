using RegistrationApp.DataClient.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace RegistrationApp.DataClient
{
    [ServiceContract]
    public interface IRegistrationService
    {
        #region Student
        [OperationContract]
        bool RegisterForCourse(int studentId, int courseScheduleId);

        [OperationContract]
        bool HoldCourse(int studentId, int courseScheduleId);

        [OperationContract]
        bool DropCourse(int studentId, int studentScheduleId);

        [OperationContract]
        List<StudentScheduleDAO> ListStudentSchedule(int studentId);

        [OperationContract]
        List<StudentScheduleDAO> ListStudentBookmarks(int studentId);

        [OperationContract]
        List<StudentDAO> ListStudents();

        [OperationContract]
        List<CourseScheduleDAO> ListCourses();

        [OperationContract]
        StudentDAO GetStudent(int studentId);
        #endregion
    }
}
