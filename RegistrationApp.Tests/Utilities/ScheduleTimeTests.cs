using RegistrationApp.Utilities;
using System;
using Xunit;

namespace RegistrationApp.Tests.Utilities
{
    public class ScheduleTimeTests
    {
        #region GetEndTime

        /// <summary>
        /// A test for the GetEndTime method using 1 time block.
        /// </summary>
        [Fact]
        public void Test_GetEndTime_1Block()
        {
            Test_GetEndTime(new TimeSpan(8, 0, 0), 1, new TimeSpan(9, 15, 0));
        }

        /// <summary>
        /// A test for the GetEndTime method using 2 time blocks.
        /// </summary>
        [Fact]
        public void Test_GetEndTime_2Blocks()
        {
            Test_GetEndTime(new TimeSpan(8, 0, 0), 2, new TimeSpan(10, 45, 0));
        }

        /// <summary>
        /// A test for the TimesOverlap method making sure the times overlap.
        /// </summary>
        [Fact]
        public void Test_TimesOverlap_True()
        {
            TimeSpan startTime1 = new TimeSpan(8, 0, 0);
            TimeSpan endTime1 = new TimeSpan(9, 15, 0);
            TimeSpan startTime2 = new TimeSpan(8, 0, 0);
            TimeSpan endTime2 = new TimeSpan(10, 45, 0);

            Assert.True(ScheduleTime.TimesOverlap(startTime1, endTime1, startTime2, endTime2));
        }

        /// <summary>
        /// A test for the TimesOverlap method making sure the times don't overlap.
        /// </summary>
        [Fact]
        public void Test_TimesOverlap_False()
        {
            TimeSpan startTime1 = new TimeSpan(8, 0, 0);
            TimeSpan endTime1 = new TimeSpan(9, 15, 0);
            TimeSpan startTime2 = new TimeSpan(9, 30, 0);
            TimeSpan endTime2 = new TimeSpan(10, 45, 0);

            Assert.False(ScheduleTime.TimesOverlap(startTime1, endTime1, startTime2, endTime2));
        }

        /// <summary>
        /// Runs a GetEndTime test.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="numberOfBlocks">The number of time blocks.</param>
        /// <param name="expectedEndTime">The expected end time.</param>
        private void Test_GetEndTime(TimeSpan startTime, int numberOfBlocks, TimeSpan expectedEndTime)
        {
            TimeSpan actualEndTime = ScheduleTime.GetEndTime(startTime, numberOfBlocks);

            Assert.Equal(expectedEndTime, actualEndTime);
        }

        #endregion
    }
}
