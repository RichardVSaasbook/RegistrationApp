using System.Runtime.Serialization;

namespace RegistrationApp.DataClient.Models
{
    /// <summary>
    /// Data Access Object for the service to send CourseSchedule info.
    /// </summary>
    [DataContract]
    public class CourseScheduleDAO
    {
        /// <summary>
        /// The Id for the CourseSchedule.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// The Person information for the Professor teaching this CourseSchedule.
        /// </summary>
        [DataMember]
        public PersonDAO Professor { get; set; }

        /// <summary>
        /// The Course information that this CourseSchedule is part of.
        /// </summary>
        [DataMember]
        public CourseDAO Course { get; set; }

        /// <summary>
        /// The Schedule information for this CourseSchedule.
        /// </summary>
        [DataMember]
        public ScheduleDAO Schedule { get; set; }

        /// <summary>
        /// The Capacity of the CourseSchedule.
        /// </summary>
        [DataMember]
        public short Capacity { get; set; }

        /// <summary>
        /// The number of Students enrolled.
        /// </summary>
        [DataMember]
        public int Enrolled { get; set; }
    }
}