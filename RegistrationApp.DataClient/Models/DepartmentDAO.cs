using System.Runtime.Serialization;

namespace RegistrationApp.DataClient.Models
{
    /// <summary>
    /// Data Access Object for the service to send Department info.
    /// </summary>
    [DataContract]
    public class DepartmentDAO
    {
        /// <summary>
        /// The Department Id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// The Name of the Department.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}