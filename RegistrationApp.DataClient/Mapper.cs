using RegistrationApp.DataAccess;
using RegistrationApp.DataClient.Models;
using RegistrationApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationApp.DataClient
{
    /// <summary>
    /// Converts the DataClient models to the DataAccess models and vice-versa.
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// Convert Student into StudentDAO.
        /// </summary>
        /// <param name="student">The Student to convert.</param>
        /// <returns>The StudentDAO.</returns>
        public static StudentDAO MapToStudentDAO(Student student)
        {
            return new StudentDAO
            {
                Person = MapToPersonDAO(student.Person),
                MajorDepartment = MapToDepartmentDAO(student.Department)
            };
        }

        /// <summary>
        /// Convert StudentDAO into Student.
        /// </summary>
        /// <param name="studentDAO">The StudentDAO to convert.</param>
        /// <returns>The Student.</returns>
        public static Student MapToStudent(StudentDAO studentDAO)
        {
            RegistrationData data = new RegistrationData();

            Student student = data.FindOrCreateStudent(studentDAO.Person.Id);
            student.PersonId = studentDAO.Person.Id;
            student.MajorId = studentDAO.MajorDepartment.Id;
            student.Person = MapToPerson(studentDAO.Person);
            student.Department = MapToDepartment(studentDAO.MajorDepartment);

            return student;
        }

        /// <summary>
        /// Convert Person into PersonDAO.
        /// </summary>
        /// <param name="person">The Person to convert.</param>
        /// <returns>The PersonDAO.</returns>
        public static PersonDAO MapToPersonDAO(Person person)
        {
            return new PersonDAO
            {
                Id = person.PersonId,
                Name = person.Name
            };
        }

        /// <summary>
        /// Convert PersonDAO into Person.
        /// </summary>
        /// <param name="personDAO">The PersonDAO to convert.</param>
        /// <returns>The Person.</returns>
        public static Person MapToPerson(PersonDAO personDAO)
        {
            RegistrationData data = new RegistrationData();

            Person person = data.FindOrCreatePerson(personDAO.Id);
            person.PersonId = personDAO.Id;
            person.Name = personDAO.Name;

            return person;
        }

        /// <summary>
        /// Convert Department into DepartmentDAO.
        /// </summary>
        /// <param name="department">The Department to convert.</param>
        /// <returns>The DepartmentDAO.</returns>
        public static DepartmentDAO MapToDepartmentDAO(Department department)
        {
            return new DepartmentDAO
            {
                Id = department.DepartmentId,
                Name = department.Name
            };
        }

        /// <summary>
        /// Convert DepartmentDAO into Department.
        /// </summary>
        /// <param name="departmentDAO">The DepartmentDAO to convert.</param>
        /// <returns>The Department.</returns>
        public static Department MapToDepartment(DepartmentDAO departmentDAO)
        {
            RegistrationData data = new RegistrationData();

            Department department = data.FindOrCreateDepartment(departmentDAO.Id);
            department.DepartmentId = departmentDAO.Id;
            department.Name = departmentDAO.Name;

            return department;
        }

        /// <summary>
        /// Convert CourseSchedule into CourseScheduleDAO.
        /// </summary>
        /// <param name="courseSchedule">The CourseSchedule to convert.</param>
        /// <returns>The CourseScheduleDAO.</returns>
        public static CourseScheduleDAO MapToCourseScheduleDAO(CourseSchedule courseSchedule)
        {
            return new CourseScheduleDAO
            {
                Id = courseSchedule.CourseScheduleId,
                Professor = MapToPersonDAO(courseSchedule.Person),
                Capacity = courseSchedule.Capacity,
                Course = MapToCourseDAO(courseSchedule.Course),
                Schedule = MapToScheduleDAO(courseSchedule.Schedule)
            };
        }

        /// <summary>
        /// Convert CourseScheduleDAO into CourseSchedule.
        /// </summary>
        /// <param name="courseScheduleDAO">The CourseScheduleDAO to convert.</param>
        /// <returns>The CourseSchedule.</returns>
        public static CourseSchedule MapToCourseSchedule(CourseScheduleDAO courseScheduleDAO)
        {
            RegistrationData data = new RegistrationData();

            CourseSchedule courseSchedule = data.FindOrCreateCourseSchedule(courseScheduleDAO.Id);
            courseSchedule.CourseScheduleId = courseScheduleDAO.Id;
            courseSchedule.Person = MapToPerson(courseScheduleDAO.Professor);
            courseSchedule.ProfessorId = courseScheduleDAO.Professor.Id;
            courseSchedule.Capacity = courseScheduleDAO.Capacity;
            courseSchedule.Course = MapToCourse(courseScheduleDAO.Course);
            courseSchedule.CourseId = courseScheduleDAO.Course.Id;
            courseSchedule.Schedule = MapToSchedule(courseScheduleDAO.Schedule);
            courseSchedule.ScheduleId = courseScheduleDAO.Schedule.Id;

            return courseSchedule;
        }

        /// <summary>
        /// Convert Course into CourseDAO.
        /// </summary>
        /// <param name="course">The Course to convert.</param>
        /// <returns>The CourseDAO.</returns>
        public static CourseDAO MapToCourseDAO(Course course)
        {
            return new CourseDAO
            {
                Id = course.CourseId,
                Title = course.Title,
                CourseDepartment = MapToDepartmentDAO(course.Department),
                Credit = course.Credit
            };
        }

        /// <summary>
        /// Convert CourseDAO into Course.
        /// </summary>
        /// <param name="courseDAO">The CourseDAO to convert.</param>
        /// <returns>The Course.</returns>
        public static Course MapToCourse(CourseDAO courseDAO)
        {
            RegistrationData data = new RegistrationData();

            Course course = data.FindOrCreateCourse(courseDAO.Id);
            course.CourseId = courseDAO.Id;
            course.Title = courseDAO.Title;
            course.Department = MapToDepartment(courseDAO.CourseDepartment);
            course.DepartmentId = courseDAO.CourseDepartment.Id;
            course.Credit = courseDAO.Credit;

            return course;
        }

        /// <summary>
        /// Convert Schedule into ScheduleDAO.
        /// </summary>
        /// <param name="schedule">The Schedule to convert.</param>
        /// <returns>The ScheduleDAO.</returns>
        public static ScheduleDAO MapToScheduleDAO(Schedule schedule)
        {
            return new ScheduleDAO
            {
                Id = schedule.ScheduleId,
                StartTime = schedule.StartTime,
                EndTime = ScheduleTime.GetEndTime(schedule.StartTime, schedule.TimeBlocks),
                TimeBlocks = schedule.TimeBlocks
            };
        }

        /// <summary>
        /// Convert ScheduleDAO into Schedule.
        /// </summary>
        /// <param name="scheduleDAO">The ScheduleDAO to convert.</param>
        /// <returns>The Schedule.</returns>
        public static Schedule MapToSchedule(ScheduleDAO scheduleDAO)
        {
            RegistrationData data = new RegistrationData();

            Schedule schedule = data.FindOrCreateSchedule(scheduleDAO.Id);
            schedule.ScheduleId = scheduleDAO.Id;
            schedule.StartTime = scheduleDAO.StartTime;
            schedule.TimeBlocks = scheduleDAO.TimeBlocks;

            return schedule;
        }

        /// <summary>
        /// Convert StudentSchedule into StudentScheduleDAO.
        /// </summary>
        /// <param name="studentSchedule">The StudentSchedule to convert.</param>
        /// <returns>The StudentScheduleDAO.</returns>
        public static StudentScheduleDAO MapToStudentScheduleDAO(StudentSchedule studentSchedule)
        {
            return new StudentScheduleDAO
            {
                CourseSchedule = MapToCourseScheduleDAO(studentSchedule.CourseSchedule),
                Student = MapToStudentDAO(studentSchedule.Student),
                Enrolled = studentSchedule.Enrolled
            };
        }

        /// <summary>
        /// Convert StudentScheduleDAO into StudentSchedule.
        /// </summary>
        /// <param name="studentScheduleDAO">The StudentScheduleDAO to convert.</param>
        /// <returns>The StudentSchedule.</returns>
        public static StudentSchedule MapToStudentSchedule(StudentScheduleDAO studentScheduleDAO)
        {
            RegistrationData data = new RegistrationData();

            StudentSchedule studentSchedule = data.FindOrCreateStudentSchedule(studentScheduleDAO.CourseSchedule.Id, studentScheduleDAO.Student.Person.Id);
            studentSchedule.CourseSchedule = MapToCourseSchedule(studentScheduleDAO.CourseSchedule);
            studentSchedule.CourseScheduleId = studentScheduleDAO.CourseSchedule.Id;
            studentSchedule.Student = MapToStudent(studentScheduleDAO.Student);
            studentSchedule.StudentId = studentScheduleDAO.Student.Person.Id;
            studentSchedule.Enrolled = studentScheduleDAO.Enrolled;

            return studentSchedule;
        }
    }
}