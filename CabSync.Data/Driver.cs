using System;

namespace CabSync.Data
{
    public struct Driver : IEquatable<Driver>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Driver))
                return false;
            return Equals((Driver)obj);
        }

        public bool Equals(Driver other) => Name == other.Name && PhoneNo == other.PhoneNo;

        public override int GetHashCode() => Name.GetHashCode() ^ PhoneNo.GetHashCode();
    }
}