using System.Runtime.Serialization;

namespace RegistrationApp.DataClient.Models
{
    /// <summary>
    /// Data Access Object for the service to send Student info.
    /// </summary>
    [DataContract]
    public class StudentDAO
    {
        /// <summary>
        /// The Person information for this Student.
        /// </summary>
        [DataMember]
        public PersonDAO Person { get; set; }

        /// <summary>
        /// The Department informationf for this Student's major.
        /// </summary>
        [DataMember]
        public DepartmentDAO MajorDepartment { get; set; }
    }
}