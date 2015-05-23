using System;

namespace CabSync.Data
{
    public struct Requester : IEquatable<Requester>
    {
        public string FirstName { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }

        public PointOfInterest NodalPoint { get; set; }

        public string PhoneNo { get; set; }

        public Guid RegistrationKey { get; set; }

        public string UserId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Requester))
                return false;
            return Equals((Requester)obj);
        }

        public bool Equals(Requester other) => UserId.Equals(other.UserId);

        public override int GetHashCode() => UserId.GetHashCode();
    }
}