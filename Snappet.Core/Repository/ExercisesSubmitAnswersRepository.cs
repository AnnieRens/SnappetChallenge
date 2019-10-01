using System;
using System.Collections.Generic;
using System.Linq;

namespace Snappet.Core.Repository
{
    public class ExercisesSubmitAnswersRepository : IExercisesSubmitAnswersRepository
    {
        private readonly ClassContext _dbContext;

        public ExercisesSubmitAnswersRepository(ClassContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ExerciseSubmitAnswer> GetClassExercisesSubmitAnswers(DateTime startDate, DateTime endDate)
        {
            return _dbContext.ExerciseSubmitAnswers.FilterByDateRange(startDate, endDate);
        }
    }

    public static class ExerciseSubmitAnswerQueryBuilder
    {
        public static List<ExerciseSubmitAnswer> FilterByDateRange(this List<ExerciseSubmitAnswer> submitAnswers, DateTime startDate,
            DateTime endDate)
        {
            return submitAnswers.Where(x => x.SubmitDateTime >= startDate && x.SubmitDateTime < endDate)
                .ToList();
        }
    }
}
