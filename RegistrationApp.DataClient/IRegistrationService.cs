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
        bool RegisterForCourse(StudentDAO studentDAO, CourseScheduleDAO courseScheduleDAO);

        [OperationContract]
        bool HoldCourse(StudentDAO studentDAO, CourseScheduleDAO courseScheduleDAO);

        [OperationContract]
        bool DropCourse(StudentDAO studentDAO, StudentScheduleDAO studentScheduleDAO);

        [OperationContract]
        List<CourseScheduleDAO> ListStudentSchedule(int studentId);

        [OperationContract]
        List<StudentDAO> ListStudents();
        #endregion
    }
}
