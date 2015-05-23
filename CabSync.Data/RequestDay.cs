using System;

namespace CabSync.Data
{
    public struct RequestDay : IEquatable<RequestDay>
    {
        public DayOfWeek DayOfWeek { get; set; }

        public int Id { get; set; }

        public TimeSpan LoginTime { get; set; }

        public TimeSpan LogoutTime { get; set; }

        public Requester Requester { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(RequestDay))
                return false;
            return Equals((RequestDay)obj);
        }

        public bool Equals(RequestDay other) => Requester.Equals(other.Requester) && DayOfWeek == other.DayOfWeek;

        public override int GetHashCode() => Requester.GetHashCode() ^ DayOfWeek.GetHashCode();
    }
}