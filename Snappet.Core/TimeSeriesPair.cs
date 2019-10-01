using System;

namespace Snappet.Core
{
    public class TimeSeriesPair<T>
    {
        public DateTime Date { get; set; }
        public T Value { get; set; }

        public TimeSeriesPair(DateTime date, T value)
        {
            Date = date;
            Value = value;
        }
    }
}