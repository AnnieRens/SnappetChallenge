using System;

namespace Snappet.Core.Queries.ClassWorkStatistic
{
    public class GetClassWorkStatisticCommandArgs
    {
        public DateTimeOffset StartDateTime { get; set; }

        public DateTimeOffset? EndDateTime { get; set; }

    }
}
