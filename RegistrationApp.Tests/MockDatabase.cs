using Moq;
using RegistrationApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RegistrationApp.Tests
{
    /// <summary>
    /// Mocks a DataSet for use as a test database.
    /// </summary>
    public class MockDatabase<TType>
        where TType : class
    {
        private List<TType> data;
        private Mock<DbSet<TType>> mockSet;
        private Mock<RegistrationAppEntities> mockContext;

        /// <summary>
        /// Create a new MockDatabase for specific type.
        /// </summary>
        /// <param name="expression">The tables within the context.</param>
        public MockDatabase(System.Linq.Expressions.Expression<Func<RegistrationAppEntities, DbSet<TType>>> expression)
        {
            data = new List<TType>();
            mockSet = new Mock<DbSet<TType>>();

            mockSet.As<IQueryable<TType>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mockSet.As<IQueryable<TType>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mockSet.As<IQueryable<TType>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mockSet.As<IQueryable<TType>>().Setup(m => m.GetEnumerator()).Returns(data.AsQueryable().GetEnumerator());

            mockContext = new Mock<RegistrationAppEntities>();
            mockContext.Setup(expression).Returns(mockSet.Object);
        }

        /// <summary>
        /// Add an entry to the mock database.
        /// </summary>
        /// <param name="entry">The entry to add.</param>
        public void AddDataEntry(TType entry)
        {
            data.Add(entry);
        }

        /// <summary>
        /// The mock data set.
        /// </summary>
        public Mock<DbSet<TType>> MockSet
        {
            get
            {
                return mockSet;
            }
        }

        /// <summary>
        /// The mock database context.
        /// </summary>
        public Mock<RegistrationAppEntities> MockContext
        {
            get
            {
                return mockContext;
            }
        }

        /// <summary>
        /// The context object within the mock context.
        /// </summary>
        public RegistrationAppEntities Context
        {
            get
            {
                return mockContext.Object;
            }
        }
    }
}
