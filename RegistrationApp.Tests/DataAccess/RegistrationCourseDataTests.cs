using Moq;
using RegistrationApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RegistrationApp.Tests.DataAccess
{
    /// <summary>
    /// Test class for the Course functionality of RegistrationData.
    /// </summary>
    public class RegistrationCourseDataTests
    {
        /// <summary>
        /// Test to check the number of students count.
        /// </summary>
        [Fact]
        public void Test_GetNumberOfStudentsInCourse()
        {
            MockDatabase<CourseSchedule> mockDB = new MockDatabase<CourseSchedule>(c => c.CourseSchedules);
            RegistrationData data = new RegistrationData(mockDB.Context);

            CourseSchedule schedule = new CourseSchedule
            {
                Capacity = 3,
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule { Enrolled = true },
                    new StudentSchedule { Enrolled = false },
                    new StudentSchedule { Enrolled = true }
                }
            };

            mockDB.AddDataEntry(schedule);

            int expected = 2;
            int actual = data.GetNumberOfStudentsInCourse(schedule);

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Make sure that a CourseSchedule can be added if valid.
        /// </summary>
        [Fact]
        public void Test_ScheduleCourse_Successful()
        {
            MockDatabase<CourseSchedule> mockDB = new MockDatabase<CourseSchedule>(c => c.CourseSchedules);
            RegistrationData data = new RegistrationData(mockDB.Context);

            Course course = new Course { CourseSchedules = new List<CourseSchedule>() };
            Schedule schedule = new Schedule { StartTime = new TimeSpan(8, 0, 0), TimeBlocks = 1 };
            Person professor = new Person();

            data.ScheduleCourse(course, schedule, professor, 3);
            
            mockDB.MockSet.Verify(m => m.Add(It.IsAny<CourseSchedule>()), Times.Once());
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Make sure a Course is not scheduled if the capacity is too low (less than 1).
        /// </summary>
        [Fact]
        public void Test_ScheduleCourse_InvalidCapacity()
        {
            MockDatabase<CourseSchedule> mockDB = new MockDatabase<CourseSchedule>(c => c.CourseSchedules);
            RegistrationData data = new RegistrationData(mockDB.Context);

            Course course = new Course { CourseSchedules = new List<CourseSchedule>() };
            Schedule schedule = new Schedule { StartTime = new TimeSpan(8, 0, 0), TimeBlocks = 1 };
            Person professor = new Person();

            data.ScheduleCourse(course, schedule, professor, 0);

            mockDB.MockSet.Verify(m => m.Add(It.IsAny<CourseSchedule>()), Times.Never());
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Never());
        }

        /// <summary>
        /// Make sure a Course is not scheduled if the professor is already teaching a Course at the same time.
        /// </summary>
        [Fact]
        public void Test_ScheduleCourse_ProfessorIsTeachingCourseAtSameTime()
        {
            MockDatabase<CourseSchedule> mockDB = new MockDatabase<CourseSchedule>(c => c.CourseSchedules);
            RegistrationData data = new RegistrationData(mockDB.Context);

            CourseSchedule existingCourseSchedule = new CourseSchedule
            {
                Schedule = new Schedule { StartTime = new TimeSpan(8, 0, 0), TimeBlocks = 2 }
            };
            Person professor = new Person { PersonId = 5, CourseSchedules = new List<CourseSchedule> { existingCourseSchedule } };
            Schedule schedule = new Schedule { StartTime = new TimeSpan(9, 30, 0), TimeBlocks = 1 };
            Course course = new Course
            {
                CourseSchedules = new List<CourseSchedule>
                {
                    existingCourseSchedule
                }
            };

            data.ScheduleCourse(course, schedule, professor, 3);

            mockDB.MockSet.Verify(m => m.Add(It.IsAny<CourseSchedule>()), Times.Never());
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Never());
        }
    }
}
