using System;

namespace CabSync.Data
{
    public struct Cab : IEquatable<Cab>
    {
        public PointOfInterest DepotLocation { get; set; }

        public Driver Driver { get; set; }

        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        public static bool operator !=(Cab one, Cab other) => !one.Equals(other);

        public static bool operator ==(Cab one, Cab other) => one.Equals(other);

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Cab))
                return false;
            return Equals((Cab)obj);
        }

        public bool Equals(Cab other) => RegistrationNumber == other.RegistrationNumber;

        public override int GetHashCode() => RegistrationNumber.GetHashCode();
    }
}