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
                CourseSchedules = new List<CourseSchedule>()
            };

            CourseSchedule schedule = new CourseSchedule
            {
                Capacity = 3,
                Students = new List<Student>
                {
                    new Student(),
                    new Student()
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

            Assert.Equal(schedule.Students.ToList().Count, 3);
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
                CourseSchedules = new List<CourseSchedule>(),
                PersonId = 5
            };

            CourseSchedule schedule = new CourseSchedule
            {
                Capacity = 3,
                Students = new List<Student>
                {
                    new Student(),
                    new Student()
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

            Assert.Equal(schedule.Students.ToList().Count, 2);
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
                CourseSchedules = new List<CourseSchedule>()
            };

            CourseSchedule schedule = new CourseSchedule
            {
                Capacity = 3,
                Students = new List<Student>
                {
                    new Student(),
                    new Student(),
                    new Student()
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

            Assert.Equal(schedule.Students.ToList().Count, 3);
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
                CourseSchedules = new List<CourseSchedule>
                {
                    new CourseSchedule
                    {
                        Schedule = new Schedule
                        {
                            StartTime = new TimeSpan(8, 0, 0),
                            TimeBlocks = 2
                        }
                    }
                }
            };

            CourseSchedule schedule = new CourseSchedule
            {
                Capacity = 3,
                Students = new List<Student>
                {
                    new Student(),
                    new Student()
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

            Assert.Equal(schedule.Students.ToList().Count, 2);
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Never());
        }
    }
}
