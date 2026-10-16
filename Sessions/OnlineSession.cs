
using System;

namespace OOPs_Collections_TrainingManagementSystem.Sessions
{
    public class OnlineSession : CourseSession
    {
        public OnlineSession(
            string courseCode,
            DateTime startDate,
            int durationDays)
            : base(courseCode, startDate, durationDays)
        {
        }

        public override decimal CalculateSessionCharge()
        {
            return 200m;
        }
    }
}
