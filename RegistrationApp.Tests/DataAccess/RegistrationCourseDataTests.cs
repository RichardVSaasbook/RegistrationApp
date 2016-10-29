using RegistrationApp.DataAccess;
using System.Collections.Generic;
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
                Students = new List<Student>
                {
                    new Student(),
                    new Student()
                }
            };

            mockDB.AddDataEntry(schedule);

            int expected = 2;
            int actual = data.GetNumberOfStudentsInCourse(schedule);

            Assert.Equal(expected, actual);
        }
    }
}
