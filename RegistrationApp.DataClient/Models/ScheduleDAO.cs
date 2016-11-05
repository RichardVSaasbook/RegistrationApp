using System;
using System.Runtime.Serialization;

namespace RegistrationApp.DataClient.Models
{
    /// <summary>
    /// Data Access Object for the service to send Schedule info.
    /// </summary>
    [DataContract]
    public class ScheduleDAO
    {
        /// <summary>
        /// The Id of the Schedule.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// The StartTime of the Schedule block.
        /// </summary>
        [DataMember]
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// The number of TimeBlocks the Schedule spans.
        /// </summary>
        [DataMember]
        public short TimeBlocks { get; set; }
    }
}