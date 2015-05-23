using System;

namespace CabSync.Data
{
    public struct PointOfInterest : IEquatable<PointOfInterest>
    {
        public string Coordinates { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public static bool operator !=(PointOfInterest one, PointOfInterest other) => !one.Equals(other);

        public static bool operator ==(PointOfInterest one, PointOfInterest other) => one.Equals(other);

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(PointOfInterest))
                return false;
            return Equals((PointOfInterest)obj);
        }

        public bool Equals(PointOfInterest other) => Coordinates == other.Coordinates;

        public override int GetHashCode() => Coordinates.GetHashCode();
    }
}