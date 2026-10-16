
using System;

namespace OOPs_Collections_TrainingManagementSystem.Sessions
{
    public class ClassroomSession : CourseSession
    {
        public ClassroomSession(
            string courseCode,
            DateTime startDate,
            int durationDays)
            : base(courseCode, startDate, durationDays)
        {
        }

        public override decimal CalculateSessionCharge()
        {
            return 800m;
        }
    }
}
