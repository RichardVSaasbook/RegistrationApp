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
    }
}
