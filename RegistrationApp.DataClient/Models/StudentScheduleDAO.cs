using System.Runtime.Serialization;

namespace RegistrationApp.DataClient.Models
{
    /// <summary>
    /// Data Access Object for the service to send StudentSchedule info.
    /// </summary>
    [DataContract]
    public class StudentScheduleDAO
    {
        /// <summary>
        /// Whether or not the Student is currently Enrolled in this StudentSchedule.
        /// </summary>
        [DataMember]
        public bool Enrolled { get; set; }

        /// <summary>
        /// The Student information for this StudentSchedule.
        /// </summary>
        [DataMember]
        public StudentDAO Student { get; set; }

        /// <summary>
        /// The CourseSchedule information for this StudentSchedule.
        /// </summary>
        [DataMember]
        public CourseScheduleDAO CourseSchedule { get; set; }
    }
}