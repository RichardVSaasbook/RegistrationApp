using System.Runtime.Serialization;

namespace RegistrationApp.DataClient.Models
{
    /// <summary>
    /// Data Access Object for the service to send Department info.
    /// </summary>
    [DataContract]
    public class CourseDAO
    {
        /// <summary>
        /// The Id for the Course.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// The Title of the Course.
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// The amount of Credit for the Course.
        /// </summary>
        [DataMember]
        public short Credit { get; set; }

        /// <summary>
        /// Department information that this Course is a part of.
        /// </summary>
        [DataMember]
        public DepartmentDAO CourseDepartment { get; set; }
    }
}