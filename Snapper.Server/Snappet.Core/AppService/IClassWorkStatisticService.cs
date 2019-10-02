using System;
using System.Collections.Generic;

namespace Snappet.Core.AppService
{
    public interface IClassWorkStatisticService
    {
        List<TimeSeriesPair<double>> GetClassCommonProgress(DateTime startDate, DateTime endDateTime);

        List<TimeSeriesPair<UserProgress>> GetStudentsProgress(DateTime startDate, DateTime endDateTime);
    }
}