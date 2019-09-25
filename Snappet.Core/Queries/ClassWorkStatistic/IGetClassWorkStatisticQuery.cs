﻿using System.Collections.Generic;

namespace Snappet.Core.Queries.ClassWorkStatistic
{
    public interface IGetClassWorkStatisticQuery : IAsyncQuery<GetClassWorkStatisticCommandArgs, List<PupilWorkStatisticModel>>
    {
    }
}
