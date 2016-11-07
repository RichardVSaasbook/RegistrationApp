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

        public bool AddStudent(string name, int majorId)
        {
            return data.AddStudent(new Student
            {
                Department = data.FindOrCreateDepartment(majorId),
                Person = new Person
                {
                    Name = name
                }
            });
        }

        public bool CancelCourse(int courseScheduleId)
        {
            return data.CancelCourse(data.FindOrCreateCourseSchedule(courseScheduleId));
        }

        /// <summary>
        /// Drops a Course for a Student.
        /// </summary>
        /// <param name="studentDAO">The Student to drop the Course on.</param>
        /// <param name="studentScheduleDAO">The Course to drop.</param>
        /// <returns>True if the drop was successful.</returns>
        public bool DropCourse(int studentId, int courseScheduleId)
        {
            return data.DropCourse(data.FindOrCreateStudent(studentId), data.FindOrCreateStudentSchedule(studentId, courseScheduleId));
        }

        public CourseScheduleDAO GetCourseSchedule(int courseScheduleId)
        {
            return Mapper.MapToCourseScheduleDAO(data.FindOrCreateCourseSchedule(courseScheduleId));
        }

        public ScheduleDAO GetSchedule(int scheduleId)
        {
            return Mapper.MapToScheduleDAO(data.FindOrCreateSchedule(scheduleId));
        }

        /// <summary>
        /// Get the Student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public StudentDAO GetStudent(int studentId)
        {
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
            return data.HoldCourse(data.FindOrCreateStudent(studentId), data.FindOrCreateCourseSchedule(courseScheduleId));
        }

        public List<CourseDAO> ListCourseInformation()
        {
            List<CourseDAO> courses = new List<CourseDAO>();

            foreach (Course course in data.ListCourseInformation())
            {
                courses.Add(Mapper.MapToCourseDAO(course));
            }

            return courses;
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

        public List<CourseScheduleDAO> ListCourseSchedule(int courseId)
        {
            List<CourseScheduleDAO> courseSchedules = new List<CourseScheduleDAO>();

            foreach (CourseSchedule courseSchedule in data.ListCourses().Where(c => c.CourseId == courseId))
            {
                courseSchedules.Add(Mapper.MapToCourseScheduleDAO(courseSchedule));
            }

            return courseSchedules;
        }

        public List<DepartmentDAO> ListDepartments()
        {
            List<DepartmentDAO> departments = new List<DepartmentDAO>();

            foreach (Department department in data.ListDepartments())
            {
                departments.Add(Mapper.MapToDepartmentDAO(department));
            }

            return departments;
        }

        public List<StudentDAO> ListEnrolledStudents(int courseId)
        {
            List<StudentDAO> students = new List<StudentDAO>();

            foreach (StudentSchedule studentSchedule in data.FindOrCreateCourseSchedule(courseId).StudentSchedules.Where(s => s.Enrolled))
            {
                students.Add(Mapper.MapToStudentDAO(studentSchedule.Student));
            }

            return students;
        }

        public List<CourseScheduleDAO> ListFullCourses()
        {
            List<CourseScheduleDAO> courseSchedules = new List<CourseScheduleDAO>();

            foreach (CourseSchedule courseSchedule in data.ListFullCourses())
            {
                courseSchedules.Add(Mapper.MapToCourseScheduleDAO(courseSchedule));
            }

            return courseSchedules;
        }

        public List<CourseScheduleDAO> ListOpenCourses()
        {
            List<CourseScheduleDAO> courseSchedules = new List<CourseScheduleDAO>();

            foreach (CourseSchedule courseSchedule in data.ListOpenCourses())
            {
                courseSchedules.Add(Mapper.MapToCourseScheduleDAO(courseSchedule));
            }

            return courseSchedules;
        }

        public List<PersonDAO> ListPeople()
        {
            List<PersonDAO> people = new List<PersonDAO>();

            foreach (Person person in data.ListPeople())
            {
                people.Add(Mapper.MapToPersonDAO(person));
            }

            return people;
        }

        public List<ScheduleDAO> ListSchedules()
        {
            List<ScheduleDAO> schedules = new List<ScheduleDAO>();

            foreach (Schedule schedule in data.ListSchedules())
            {
                schedules.Add(Mapper.MapToScheduleDAO(schedule));
            }

            return schedules;
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

        public bool ModifyCourse(int courseScheduleId, int scheduleId, short capacity)
        {
            return data.ModifyCourse(data.FindOrCreateCourseSchedule(courseScheduleId), data.FindOrCreateSchedule(scheduleId), capacity);
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

        public bool RemoveStudent(int studentId)
        {
            return data.RemoveStudent(data.FindOrCreateStudent(studentId));
        }

        public bool ScheduleCourse(int courseId, int professorId, int scheduleId, short capacity)
        {
            Course course = data.FindOrCreateCourse(courseId);
            Schedule schedule = data.FindOrCreateSchedule(scheduleId);
            Person professor = data.FindOrCreatePerson(professorId);
            return data.ScheduleCourse(course, schedule, professor, capacity);
        }
    }
}
