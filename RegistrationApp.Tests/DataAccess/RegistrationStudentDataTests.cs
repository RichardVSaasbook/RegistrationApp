using Moq;
using RegistrationApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RegistrationApp.Tests.DataAccess
{
    /// <summary>
    /// Test class for the Student functionality of RegistrationData.
    /// </summary>
    public class RegistrationStudentDataTests
    {
        /// <summary>
        /// Make sure that a student is added to the course if he/she should be.
        /// </summary>
        [Fact]
        public void Test_RegisterForCourse_ReadyToAdd()
        {
            MockDatabase<CourseSchedule> mockDB = new MockDatabase<CourseSchedule>(c => c.CourseSchedules);
            RegistrationData data = new RegistrationData(mockDB.Context);

            Student student = new Student
            {
                StudentSchedules = new List<StudentSchedule>()
            };

            CourseSchedule schedule = new CourseSchedule
            {
                Capacity = 3,
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule
                    {
                        Student = new Student(),
                    },
                    new StudentSchedule
                    {
                        Student = new Student(),
                    }
                },
                Schedule = new Schedule
                {
                    StartTime = new TimeSpan(8, 0, 0),
                    TimeBlocks = 1
                },
                ProfessorId = 5
            };

            mockDB.AddDataEntry(schedule);
            data.RegisterForCourse(student, schedule);

            Assert.Equal(schedule.StudentSchedules.ToList().Count, 3);
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Make sure the Student isn't added to the Course if he/she is the professor.
        /// </summary>
        [Fact]
        public void Test_RegisterForCourse_StudentIsProfessor()
        {
            MockDatabase<CourseSchedule> mockDB = new MockDatabase<CourseSchedule>(c => c.CourseSchedules);
            RegistrationData data = new RegistrationData(mockDB.Context);

            Student student = new Student
            {
                StudentSchedules = new List<StudentSchedule>(),
                PersonId = 5
            };

            CourseSchedule schedule = new CourseSchedule
            {
                Capacity = 3,
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule(),
                    new StudentSchedule()
                },
                Schedule = new Schedule
                {
                    StartTime = new TimeSpan(8, 0, 0),
                    TimeBlocks = 1
                },
                ProfessorId = 5
            };

            mockDB.AddDataEntry(schedule);
            data.RegisterForCourse(student, schedule);

            Assert.Equal(schedule.StudentSchedules.ToList().Count, 2);
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Never());
        }

        /// <summary>
        /// Make sure the Student isn't added to the Course if the capacity is full.
        /// </summary>
        [Fact]
        public void Test_RegisterForCourse_CourseIsFull()
        {
            MockDatabase<CourseSchedule> mockDB = new MockDatabase<CourseSchedule>(c => c.CourseSchedules);
            RegistrationData data = new RegistrationData(mockDB.Context);

            Student student = new Student
            {
                StudentSchedules = new List<StudentSchedule>()
            };

            CourseSchedule schedule = new CourseSchedule
            {
                Capacity = 3,
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule { Enrolled = true },
                    new StudentSchedule { Enrolled = true },
                    new StudentSchedule { Enrolled = true }
                },
                Schedule = new Schedule
                {
                    StartTime = new TimeSpan(8, 0, 0),
                    TimeBlocks = 1
                },
                ProfessorId = 5
            };

            mockDB.AddDataEntry(schedule);
            data.RegisterForCourse(student, schedule);

            Assert.Equal(schedule.StudentSchedules.ToList().Count, 3);
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Never());
        }
        
        /// <summary>
        /// Make sure a Student isn't added to the Course if he/she is already taking a Course during that time.
        /// </summary>
        [Fact]
        public void Test_RegisterForCourse_StudentIsTakingCourseDuringThatTime()
        {
            MockDatabase<CourseSchedule> mockDB = new MockDatabase<CourseSchedule>(c => c.CourseSchedules);
            RegistrationData data = new RegistrationData(mockDB.Context);

            Student student = new Student
            {
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule
                    {
                        CourseSchedule = new CourseSchedule
                        {
                            Schedule = new Schedule
                            {
                                StartTime = new TimeSpan(8, 0, 0),
                                TimeBlocks = 2
                            }
                        }
                    }
                }
            };

            CourseSchedule schedule = new CourseSchedule
            {
                Capacity = 3,
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule(),
                    new StudentSchedule()
                },
                Schedule = new Schedule
                {
                    StartTime = new TimeSpan(8, 0, 0),
                    TimeBlocks = 1
                },
                ProfessorId = 5
            };

            mockDB.AddDataEntry(schedule);
            data.RegisterForCourse(student, schedule);

            Assert.Equal(schedule.StudentSchedules.ToList().Count, 2);
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Never());
        }

        /// <summary>
        /// Make sure a Student can hold a Course and that it doesn't count towards capacity.
        /// </summary>
        [Fact]
        public void Test_HoldCourse()
        {
            MockDatabase<CourseSchedule> mockDB = new MockDatabase<CourseSchedule>(c => c.CourseSchedules);
            RegistrationData data = new RegistrationData(mockDB.Context);

            Student student = new Student
            {
                StudentSchedules = new List<StudentSchedule>()
            };

            CourseSchedule schedule = new CourseSchedule
            {
                Capacity = 3,
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule
                    {
                        Student = new Student(),
                        Enrolled = true
                    },
                    new StudentSchedule
                    {
                        Student = new Student(),
                        Enrolled = true
                    }
                },
                Schedule = new Schedule
                {
                    StartTime = new TimeSpan(8, 0, 0),
                    TimeBlocks = 1
                },
                ProfessorId = 5
            };

            mockDB.AddDataEntry(schedule);
            data.HoldCourse(student, schedule);

            Assert.Equal(3, schedule.StudentSchedules.ToList().Count);
            Assert.Equal(2, data.GetNumberOfStudentsInCourse(schedule));
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Make sure that a Student can drop a Course he/she is registered for.
        /// </summary>
        [Fact]
        public void Test_DropCourse_Success()
        {
            MockDatabase<Student> mockDB = new MockDatabase<Student>(c => c.Students);
            RegistrationData data = new RegistrationData(mockDB.Context);

            StudentSchedule course1 = new StudentSchedule();
            StudentSchedule course2 = new StudentSchedule();
            Student student = new Student
            {
                StudentSchedules = new List<StudentSchedule>
                {
                    course1, course2
                }
            };

            mockDB.AddDataEntry(student);
            data.DropCourse(student, course2);

            Assert.Equal(student.StudentSchedules.ToList().Count, 1);
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Make sure that a Student cannot drop a class he/she is not in.
        /// </summary>
        [Fact]
        public void Test_DropCourse_Failure()
        {
            MockDatabase<Student> mockDB = new MockDatabase<Student>(c => c.Students);
            RegistrationData data = new RegistrationData(mockDB.Context);

            StudentSchedule course1 = new StudentSchedule();
            StudentSchedule course2 = new StudentSchedule();
            Student student = new Student
            {
                StudentSchedules = new List<StudentSchedule>
                {
                    course1, course2
                }
            };

            mockDB.AddDataEntry(student);
            data.DropCourse(student, new StudentSchedule());

            Assert.Equal(student.StudentSchedules.ToList().Count, 2);
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Never());
        }

        /// <summary>
        /// Make sure we can list a Student's Courses.
        /// </summary>
        [Fact]
        public void Test_ListStudentCourses()
        {
            MockDatabase<Student> mockDB = new MockDatabase<Student>(c => c.Students);
            RegistrationData data = new RegistrationData(mockDB.Context);

            Student student = new Student
            {
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule { Enrolled = true, CourseSchedule = new CourseSchedule { Course = new Course { Title = "Intro to Computer Science" } } },
                    new StudentSchedule { Enrolled = false, CourseSchedule = new CourseSchedule { Course = new Course { Title = "English I" } } },
                    new StudentSchedule { Enrolled = true, CourseSchedule = new CourseSchedule { Course = new Course { Title = "Calculus IV" } } },
                }
            };

            mockDB.AddDataEntry(student);

            List<CourseSchedule> courses = data.ListStudentSchedule(student);

            Assert.Equal(2, courses.Count);
            Assert.Equal("Intro to Computer Science", courses[0].Course.Title);
            Assert.Equal("Calculus IV", courses[1].Course.Title);
        }
    }
}
