using System;

namespace Snappet.Core
{
    public class ExerciseSubmitAnswer : BaseEntity
    {
        //public int SubmittedAnswerId { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public DateTimeOffset SubmitDateTime { get; set; }

        public bool Correct { get; set; } //IsCorrect
        public int Progress { get; set; } // ProgressChange
    }
}