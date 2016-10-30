using Moq;
using RegistrationApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RegistrationApp.Tests.DataAccess
{
    /// <summary>
    /// Test class for the registrar functionality of RegistrationData.
    /// </summary>
    public class RegistrationRegistrarDataTests
    {
        /// <summary>
        /// Make sure we can List all open courses.
        /// </summary>
        [Fact]
        public void Test_ListOpenCourses()
        {
            MockDatabase<CourseSchedule> mockDB = new MockDatabase<CourseSchedule>(c => c.CourseSchedules);
            RegistrationData data = new RegistrationData(mockDB.Context);

            mockDB.AddDataEntry(new CourseSchedule
            {
                Capacity = 3,
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule { Enrolled = true },
                    new StudentSchedule { Enrolled = true },
                    new StudentSchedule { Enrolled = true }
                },
                Course = new Course { Title = "Intro to Computer Science" }
            });

            mockDB.AddDataEntry(new CourseSchedule
            {
                Capacity = 5,
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule { Enrolled = true },
                    new StudentSchedule { Enrolled = true },
                    new StudentSchedule { Enrolled = true }
                },
                Course = new Course { Title = "Calculus IV" }
            });

            List<CourseSchedule> courses = data.ListOpenCourses();

            Assert.Equal(1, courses.Count);
            Assert.Equal("Calculus IV", courses[0].Course.Title);
        }

        /// <summary>
        /// Make sure we can List all full courses.
        /// </summary>
        [Fact]
        public void Test_ListFullCourses()
        {
            MockDatabase<CourseSchedule> mockDB = new MockDatabase<CourseSchedule>(c => c.CourseSchedules);
            RegistrationData data = new RegistrationData(mockDB.Context);

            mockDB.AddDataEntry(new CourseSchedule
            {
                Capacity = 3,
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule { Enrolled = true },
                    new StudentSchedule { Enrolled = true },
                    new StudentSchedule { Enrolled = true }
                },
                Course = new Course { Title = "Intro to Computer Science" }
            });

            mockDB.AddDataEntry(new CourseSchedule
            {
                Capacity = 5,
                StudentSchedules = new List<StudentSchedule>
                {
                    new StudentSchedule { Enrolled = true },
                    new StudentSchedule { Enrolled = true },
                    new StudentSchedule { Enrolled = true }
                },
                Course = new Course { Title = "Calculus IV" }
            });

            List<CourseSchedule> courses = data.ListFullCourses();

            Assert.Equal(1, courses.Count);
            Assert.Equal("Intro to Computer Science", courses[0].Course.Title);
        }

        /// <summary>
        /// Make sure we can add a Student to the student body.
        /// </summary>
        [Fact]
        public void Test_AddStudent()
        {
            MockDatabase<Student> mockDB = new MockDatabase<Student>(c => c.Students);
            RegistrationData data = new RegistrationData(mockDB.Context);

            data.AddStudent(new Student());

            mockDB.MockSet.Verify(m => m.Add(It.IsAny<Student>()), Times.Once());
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Make sure we can remove a Student from the student body.
        /// </summary>
        [Fact]
        public void Test_RemoveStudent()
        {
            MockDatabase<Student> mockDB = new MockDatabase<Student>(c => c.Students);
            RegistrationData data = new RegistrationData(mockDB.Context);

            Student student = new Student();

            mockDB.AddDataEntry(student);

            data.RemoveStudent(student);

            mockDB.MockSet.Verify(m => m.Remove(It.IsAny<Student>()), Times.Once());
            mockDB.MockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
