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

        public List<TimeSeriesPair<double>> GetClassCommonProgress(DateTime startDate, DateTime endDateTime)
        {
            var studentAnswers = _submitAnswersRepository.GetClassExercisesSubmitAnswers(startDate, endDateTime);

            var result = studentAnswers.Where(x => x.Progress != 0)
                .GroupBy(x => x.SubmitDateTime.Date, y => y.Progress)
                .Select(x => new TimeSeriesPair<double>(x.Key, x.ToList().Average())).ToList();

            return result;
        }

        public List<TimeSeriesPair<UserProgress>> GetStudentsProgress(DateTime startDate, DateTime endDateTime)
        {
            var studentAnswers = _submitAnswersRepository.GetClassExercisesSubmitAnswers(startDate, endDateTime);

            var result = studentAnswers.Where(x => x.Progress != 0)
                .GroupBy(x => new {x.UserId, x.SubmitDateTime.Date}, x => x.Progress)
                .Select(x =>
                    new TimeSeriesPair<UserProgress>(x.Key.Date, new UserProgress(x.Key.UserId, x.ToList().Average())))
                .ToList();

            return result;
        }
    }
}