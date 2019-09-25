using System.Collections.Generic;

namespace Snappet.Core.Repository
{
    public interface IClassStatisticRepository
    {
        IEnumerable<ClassWorkRowData> GetClassWorkStatistic();
    }
}