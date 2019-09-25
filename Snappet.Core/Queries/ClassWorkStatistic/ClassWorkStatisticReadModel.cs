using System.Collections.Generic;

namespace Snappet.Core.Queries.ClassWorkStatistic
{
    public class PupilWorkStatisticModel
    {
        public int UserId { get; set; }

        public List<ObjectiveWorkStatistic> ObjectiveWorkStatistic { get; set; }

        // there could be added other statistic type, by domain, for example
    }

    public class ObjectiveWorkStatistic
    {
        public string LearningObjective { get; set; }
        public double AverageProgressByAllExercises { get; set; }
        public double AverageProgressByProgressedExercises { get; set; }
        public int CorrectAnswers { get; set; }
        public int IncorrectAnswers { get; set; }
    }
}
