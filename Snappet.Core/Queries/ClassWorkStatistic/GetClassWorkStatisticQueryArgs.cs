using System;

namespace Snappet.Core.Queries.ClassWorkStatistic
{
    public class GetClassWorkStatisticQueryArgs
    {
        public DateTimeOffset StartDateTime { get; set; }

        public DateTimeOffset? EndDateTime { get; set; }

    }
}
