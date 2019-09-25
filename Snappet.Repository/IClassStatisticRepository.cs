using System.Collections.Generic;

namespace Snappet.Repository
{
    public interface IClassStatisticRepository
    {
        IEnumerable<ClassWorkRowData> GetClassWorkStatistic();
    }
}