using System.Runtime.Serialization;

namespace RegistrationApp.DataClient.Models
{
    /// <summary>
    /// Data Access Object for the service to send Person info.
    /// </summary>
    [DataContract]
    public class PersonDAO
    {
        /// <summary>
        /// The Id of the Person.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// The Name of the Person.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}