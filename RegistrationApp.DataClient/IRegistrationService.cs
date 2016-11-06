﻿using RegistrationApp.DataClient.Models;
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

        [OperationContract]
        List<CourseDAO> ListCourseInformation();

        [OperationContract]
        bool ScheduleCourse(CourseScheduleDAO courseSchedule);

        [OperationContract]
        bool CancelCourse(int courseScheduleId);

        [OperationContract]
        bool ModifyCourse(CourseScheduleDAO courseSchedule);

        [OperationContract]
        List<StudentDAO> ListEnrolledStudents(int courseId);

        [OperationContract]
        List<ScheduleDAO> ListSchedules();

        [OperationContract]
        List<PersonDAO> ListPeople();

        [OperationContract]
        List<CourseScheduleDAO> ListOpenCourses();

        [OperationContract]
        List<CourseScheduleDAO> ListFullCourses();

        [OperationContract]
        bool AddStudent(StudentDAO student);

        [OperationContract]
        bool RemoveStudent(int studentId);
        #endregion
    }
}
