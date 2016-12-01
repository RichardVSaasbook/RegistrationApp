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
