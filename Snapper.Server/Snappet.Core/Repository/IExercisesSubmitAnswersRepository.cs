using System;
using System.Collections.Generic;

namespace Snappet.Core.Repository
{
    public interface IExercisesSubmitAnswersRepository
    {
        List<ExerciseSubmitAnswer> GetClassExercisesSubmitAnswers(DateTime startDate, DateTime endDate);
    }
}