using System;
using System.Collections.Generic;

namespace CabSync.Data
{
    public struct Trip : IEquatable<Trip>
    {
        public Cab Cab { get; set; }

        public DateTime EndDateTime { get; set; }

        public IEnumerable<Requester> Requesters { get; set; }

        public DateTime StartDateTime { get; set; }

        public TripType TripType { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Trip))
                return false;
            return Equals((Trip)obj);
        }

        public bool Equals(Trip other)
            => Cab.Equals(other.Cab) && StartDateTime.Equals(other.StartDateTime) && EndDateTime.Equals(other.EndDateTime);

        public override int GetHashCode()
            => Cab.GetHashCode() ^ StartDateTime.GetHashCode() ^ EndDateTime.GetHashCode();
    }
}