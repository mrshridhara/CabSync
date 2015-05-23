using System;

namespace CabSync.Data
{
    public struct Cab : IEquatable<Cab>
    {
        public PointOfInterest DepotLocation { get; set; }

        public Driver Driver { get; set; }

        public int Id { get; set; }

        public string RegistrationNumber { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Cab))
                return false;
            return Equals((Cab)obj);
        }

        public override int GetHashCode() => RegistrationNumber.GetHashCode();

        public bool Equals(Cab other) => RegistrationNumber == other.RegistrationNumber;
    }
}