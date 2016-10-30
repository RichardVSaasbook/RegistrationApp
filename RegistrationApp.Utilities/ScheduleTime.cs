using System;

namespace RegistrationApp.Utilities
{
    /// <summary>
    /// Utility methods related to Schedule time.
    /// </summary>
    public class ScheduleTime
    {
        /// <summary>
        /// Get the end time of a course given the start time and the number of time blocks it spans.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="numberOfBlocks">The number of time blocks.</param>
        /// <returns>The end time.</returns>
        public static TimeSpan GetEndTime(TimeSpan startTime, int numberOfBlocks)
        {
            int hours = numberOfBlocks;
            int minutes = 15 * (numberOfBlocks + (numberOfBlocks - 1));

            while (minutes > 60)
            {
                minutes -= 60;
                hours += 1;
            }

            return startTime + new TimeSpan(hours, minutes, 0);
        }

        /// <summary>
        /// Figure out whether the first time range overlaps a second time range.
        /// </summary>
        /// <param name="startTime1">The start time of the first time range.</param>
        /// <param name="endTime1">The end time of the first time range.</param>
        /// <param name="startTime2">The start time of the second time range.</param>
        /// <param name="endTime2">The end time of the second time range.</param>
        /// <returns>Whether the first time range overlaps a second time range.</returns>
        public static bool TimesOverlap(TimeSpan startTime1, TimeSpan endTime1, TimeSpan startTime2, TimeSpan endTime2)
        {
            bool startInRange = startTime1 >= startTime2 && startTime1 < endTime2;
            bool endInRange = endTime1 > startTime2 && endTime1 <= endTime2;

            return startInRange || endInRange;
        }
    }
}
