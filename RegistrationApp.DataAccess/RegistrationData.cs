using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RegistrationApp.DataAccess
{
    /// <summary>
    /// Data access for the RegistrationApp.
    /// </summary>
    public partial class RegistrationData
    {
        private RegistrationAppEntities db;

        /// <summary>
        /// Create a new RegistrationData data access object.
        /// </summary>
        public RegistrationData() : this(new RegistrationAppEntities()) {  }

        /// <summary>
        /// Create a new RegistrationData data access object, specifying the DbContext to use.
        /// </summary>
        /// <param name="db">The DbContext to use (helpful for testing.)</param>
        public RegistrationData(RegistrationAppEntities db)
        {
            this.db = db;
        }

        /// <summary>
        /// Finds or creates a Person from the database.
        /// </summary>
        /// <param name="personId">The Id of the person to find.</param>
        /// <returns>The new or found Person.</returns>
        public Person FindOrCreatePerson(int personId)
        {
            return FindOrCreate(db.People, personId);
        }

        /// <summary>
        /// Finds or creates a Student from the database.
        /// </summary>
        /// <param name="studentId">The Id of the Student to find.</param>
        /// <returns>The new or found Student.</returns>
        public Student FindOrCreateStudent(int studentId)
        {
            return FindOrCreate(db.Students, studentId);
        }

        /// <summary>
        /// Finds or creates a Department from the database.
        /// </summary>
        /// <param name="departmentId">The Id of the Department to find.</param>
        /// <returns>The new or found Department.</returns>
        public Department FindOrCreateDepartment(int departmentId)
        {
            return FindOrCreate(db.Departments, departmentId);
        }

        /// <summary>
        /// Finds or creates a CourseSchedule from the database.
        /// </summary>
        /// <param name="courseScheduleId">The Id of the CourseSchedule to find.</param>
        /// <returns>The new or found CourseSchedule.</returns>
        public CourseSchedule FindOrCreateCourseSchedule(int courseScheduleId)
        {
            return FindOrCreate(db.CourseSchedules, courseScheduleId);
        }

        /// <summary>
        /// Finds or creates a Course from the database.
        /// </summary>
        /// <param name="courseId">The Id of the Course to find.</param>
        /// <returns>The new or found Course.</returns>
        public Course FindOrCreateCourse(int courseId)
        {
            return FindOrCreate(db.Courses, courseId);
        }

        /// <summary>
        /// Finds or creates a Schedule from the database.
        /// </summary>
        /// <param name="scheduleId">The Id of the Schedule to find.</param>
        /// <returns>The new or found Schedule.</returns>
        public Schedule FindOrCreateSchedule(int scheduleId)
        {
            return FindOrCreate(db.Schedules, scheduleId);
        }

        /// <summary>
        /// Finds or creates a StudentSchedule from the database.
        /// </summary>
        /// <param name="studentScheduleId">The Id of the StudentSchedule to find.</param>
        /// <returns>The new or found StudentSchedule.</returns>
        public StudentSchedule FindOrCreateStudentSchedule(int studentId, int courseScheduleId)
        {
            return FindOrCreate(db.StudentSchedules, studentId, courseScheduleId);
        }

        public List<Person> ListPeople()
        {
            return db.People.ToList();
        }

        public List<Schedule> ListSchedules()
        {
            return db.Schedules.ToList();
        }

        public List<Department> ListDepartments()
        {
            return db.Departments.ToList();
        }

        /// <summary>
        /// Finds or creates a resource from the database.
        /// </summary>
        /// <typeparam name="T">The Type of the resource.</typeparam>
        /// <param name="dbSet">The DbSet to search through.</param>
        /// <param name="id">The Id of the resource to find.</param>
        /// <returns>The found or created resource.</returns>
        private T FindOrCreate<T>(DbSet<T> dbSet, params object[] id) where T : class, new()
        {
            T entity = dbSet.Find(id);

            if (entity == null)
            {
                entity = new T();
            }

            return entity;
        }
    }
}
