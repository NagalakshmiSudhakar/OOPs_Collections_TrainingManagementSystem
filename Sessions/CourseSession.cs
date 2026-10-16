
using System;

namespace OOPs_Collections_TrainingManagementSystem.Sessions
{
    public abstract class CourseSession
    {
        public string CourseCode { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationDays { get; set; }

        protected CourseSession(
            string courseCode,
            DateTime startDate,
            int durationDays)
        {
            CourseCode = courseCode;
            StartDate = startDate;
            DurationDays = durationDays;
        }

        public abstract decimal CalculateSessionCharge();
    }
}
