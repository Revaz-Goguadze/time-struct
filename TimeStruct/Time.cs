namespace TimeStruct
{
    /// <summary>
    /// Represents a time of day in hours and minutes.
    /// </summary>
    public readonly struct Time
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct from a total number of minutes.
        /// </summary>
        /// <param name="minutes">The total number of minutes.</param>
        public Time(int minutes)
            : this(minutes / 60, minutes % 60)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> struct from hours and minutes.
        /// </summary>
        /// <param name="hours">The number of hours.</param>
        /// <param name="minutes">The number of minutes.</param>
        public Time(int hours, int minutes)
        {
            var convertedTime = ConvertTime(hours, minutes);
            this.Hours = convertedTime.hours;
            this.Minutes = convertedTime.minutes;
        }

        /// <summary>
        /// Gets the number of hours.
        /// </summary>
        public int Hours { get; }

        /// <summary>
        /// Gets the number of minutes.
        /// </summary>
        public int Minutes { get; }

        /// <summary>
        /// Returns a string representation of the time in the format "HH:MM".
        /// </summary>
        /// <returns>A string representation of the time in the format "HH:MM".</returns>
        public new string ToString() => $"{this.Hours:00}:{this.Minutes:00}";

        /// <summary>
        /// Deconstructs the time into its component hours and minutes.
        /// </summary>
        /// <param name="hours">The number of hours.</param>
        /// <param name="minutes">The number of minutes.</param>
        public void Deconstruct(out int hours, out int minutes) => (hours, minutes) = (this.Hours, this.Minutes);

        /// <summary>
        /// Converts hours and minutes to a total number of minutes.
        /// </summary>
        /// <param name="hours">The number of hours.</param>
        /// <param name="minutes">The number of minutes.</param>
        /// <returns>A tuple containing the total number of hours and the remaining minutes.</returns>
        private static (int hours, int minutes) ConvertTime(int hours, int minutes)
        {
            const int minutesInDay = 24 * 60, minutesInHour = 60, hoursInDay = 24;
            int totalMinutes = (hours * minutesInHour) + minutes;
            if (totalMinutes < 0)
            {
                totalMinutes = (totalMinutes % minutesInDay) + minutesInDay;
            }

            int convertedHours = (totalMinutes / minutesInHour) % hoursInDay;
            int convertedMinutes = totalMinutes % minutesInHour;
            return (convertedHours, convertedMinutes);
        }
    }
}
