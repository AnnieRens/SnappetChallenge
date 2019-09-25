using Snappet.Core.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snappet.Core.Queries.ClassWorkStatistic
{
    public class GetClassWorkStatisticQuery : IGetClassWorkStatisticQuery
    {
        private readonly IClassStatisticRepository _classStatisticRepository;

        public GetClassWorkStatisticQuery(IClassStatisticRepository classStatisticRepository)
        {
            _classStatisticRepository = classStatisticRepository;
        }

        public async Task<List<PupilWorkStatisticModel>> Ask(GetClassWorkStatisticCommandArgs input)
        {
            var classStatisticData = _classStatisticRepository.GetClassWorkStatistic().ToList();

            // Get all users
            var users = classStatisticData.GroupBy(x => x.UserId)
                .ToDictionary(k => k.Key, k => k.ToList());

            // Filter by date and learn.obj. for progress calculation
            // TODO (platonova): need optimize it
            var filteredByDtaeStatistic = classStatisticData.Where(x =>
                    x.SubmitDateTime >= input.StartDateTime && x.SubmitDateTime < input.EndDateTime)
                .GroupBy(x => new {x.UserId, x.LearningObjective})
                .Select(x => new
                    {
                        UserId = x.Key.UserId,
                        LearningObjective = x.Key.LearningObjective,

                        AverageProgressByAllExercises = x.ToList().Any() ? x.Select(z => z.Progress).Average() : 0,
                        AverageProgressByProgressedExercises = x.Count(y => y.Progress != 0),
                        AverageProgressByProgressed = x.Count(y => y.Progress != 0) > 0
                            ? x.Where(y => y.Progress != 0).Select(z => z.Progress).Average()
                            : 0,

                        CorrectAnswers = x.Count(y => y.Correct == 1),
                        IncorrectAnswers = x.Count(y => y.Correct != 1)
                    }
                )
                .GroupBy(x => x.UserId)
                .ToDictionary(x => x.Key, x => x.ToList());

            // Prepare result model
            var result = new List<PupilWorkStatisticModel>();

            foreach (var userId in users.Keys)
            {
                filteredByDtaeStatistic.TryGetValue(userId, out var val);

                result.Add(new PupilWorkStatisticModel
                {
                    UserId = userId,
                    ObjectiveWorkStatistic = val != null
                        ? val.Select(x => new ObjectiveWorkStatistic
                        {
                            LearningObjective = x.LearningObjective,
                            AverageProgressByAllExercises = x.AverageProgressByAllExercises,
                            AverageProgressByProgressedExercises = x.AverageProgressByProgressedExercises,
                            CorrectAnswers = x.CorrectAnswers,
                            IncorrectAnswers = x.IncorrectAnswers
                        }).ToList()
                        : new List<ObjectiveWorkStatistic>()
                });
            }

            return result;
        }
    }
}