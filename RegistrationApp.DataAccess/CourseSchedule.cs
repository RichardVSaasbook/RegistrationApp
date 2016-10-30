//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationApp.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseSchedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourseSchedule()
        {
            this.StudentSchedules = new HashSet<StudentSchedule>();
        }
    
        public int CourseScheduleId { get; set; }
        public int CourseId { get; set; }
        public int ScheduleId { get; set; }
        public int ProfessorId { get; set; }
        public short Capacity { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Course Course { get; set; }
        public virtual Schedule Schedule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentSchedule> StudentSchedules { get; set; }
    }
}
