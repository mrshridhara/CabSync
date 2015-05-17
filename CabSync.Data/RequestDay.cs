using System;

namespace CabSync.Data
{
    public struct RequestDay
    {
        public int Id { get; set; }
        public Requester Requester { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan LoginTime { get; set; }
        public TimeSpan LogoutTime { get; set; }
    }
}
