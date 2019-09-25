using System;

namespace Snappet.Repository
{
    public class ClassWorkRowData
    {
        public int SubmittedAnswerId { get; set; }

        private DateTimeOffset _submittedDateTime;
        public DateTimeOffset SubmitDateTime
        {
            // NOTE: Server creates in its timezone, we need store datetime in UTC

            get => _submittedDateTime;
            set => _submittedDateTime = new DateTimeOffset(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond, TimeSpan.Zero); 
        }

        public int Correct { get; set; }
        public int Progress { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public string Difficulty { get; set; }
        public string Subject { get; set; }
        public string Domain { get; set; }
        public string LearningObjective { get; set; }
    }
}