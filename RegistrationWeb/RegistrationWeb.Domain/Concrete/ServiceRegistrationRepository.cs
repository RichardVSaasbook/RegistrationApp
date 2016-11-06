using RegistrationWeb.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistrationWeb.Domain.RegistrationServiceReference;

namespace RegistrationWeb.Domain.Concrete
{
    public class ServiceRegistrationRepository : IRegistrationRepository
    {
        private RegistrationServiceClient rsc = new RegistrationServiceClient();

        /// <summary>
        /// List a Student's registered courses.
        /// </summary>
        /// <param name="student">The Student to get courses from.</param>
        /// <returns>The List of registered Courses.</returns>
        public IEnumerable<CourseScheduleDAO> ListStudentSchedule(int studentId)
        {
            return rsc.ListStudentSchedule(studentId);
        }

        /// <summary>
        /// Lists all Students in the database.
        /// </summary>
        /// <returns>The List of StudentDAOs.</returns>
        public IEnumerable<StudentDAO> ListStudents()
        {
            return rsc.ListStudents();
        }
    }
}
