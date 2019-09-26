using System.Collections.Generic;

namespace Snappet.Core.Queries.ClassWorkStatistic
{
    public interface IGetClassWorkStatisticQuery : IAsyncQuery<GetClassWorkStatisticQueryArgs, List<PupilWorkStatisticModel>>
    {
    }
}
