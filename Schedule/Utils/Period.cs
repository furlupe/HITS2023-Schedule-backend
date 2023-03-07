namespace Schedule.Utils
{
    public class Period
    {
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        
        public Period(DateOnly start, DateOnly end) 
        {
            Start = (start < end) ? start : end;
            End = (start < end) ? end : start;
        }

        public Period(DateTime start, DateTime end)
        {
            Start = DateOnly.FromDateTime((start < end) ? start : end);
            End = DateOnly.FromDateTime((start < end) ? end : start);
        }
        public bool IntersetsWith(Period period)
        {
            return !(Start > period.End || End < period.Start);
        }
    }
}
