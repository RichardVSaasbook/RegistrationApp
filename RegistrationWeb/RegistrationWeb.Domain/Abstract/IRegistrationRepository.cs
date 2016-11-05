using RegistrationWeb.Domain.RegistrationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWeb.Domain.Abstract
{
    /// <summary>
    /// Interface for the RegistrationWeb repository.
    /// </summary>
    public interface IRegistrationRepository
    {
        IEnumerable<CourseScheduleDAO> ListStudentSchedule(StudentDAO student);
    }
}
