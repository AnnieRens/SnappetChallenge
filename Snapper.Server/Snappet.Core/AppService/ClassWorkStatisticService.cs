using System;
using System.Collections.Generic;
using System.Linq;
using Snappet.Core.Repository;

namespace Snappet.Core.AppService
{
    public class ClassWorkStatisticService : IClassWorkStatisticService
    {
        private readonly IExercisesSubmitAnswersRepository _submitAnswersRepository;

        public ClassWorkStatisticService(IExercisesSubmitAnswersRepository submitAnswersRepository)
        {
            _submitAnswersRepository = submitAnswersRepository;
        }

        public List<TimeSeriesPair<double>> GetClassCommonProgress(DateTime startDate, DateTime endDateTime) //time series with one day interval
        {
            var studentAnswers = _submitAnswersRepository.GetClassExercisesSubmitAnswers(startDate, endDateTime);

            var result = studentAnswers.GroupBy(x => x.SubmitDateTime.Date, y => y.Progress)
                .Select(x => new TimeSeriesPair<double>(x.Key, x.ToList().Average())).ToList(); // except 0?

            return result;

        }

        public void GetStudentsProgress(DateTime startDate, DateTime endDateTime, int[] userIds)
        {

        }
    }

    public interface IClassWorkStatisticService
    {
        List<TimeSeriesPair<double>> GetClassCommonProgress(DateTime startDate, DateTime endDateTime);
    }
}