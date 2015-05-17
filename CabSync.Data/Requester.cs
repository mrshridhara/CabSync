using System;

namespace CabSync.Data
{
    public struct Requester
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public Guid RegistrationKey { get; set; }
        public PointOfInterest NodalPoint { get; set; }
        public string UserId { get; set; }
    }
}
