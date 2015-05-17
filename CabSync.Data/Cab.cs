namespace CabSync.Data
{
    public struct Cab
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public Driver Driver { get; set; }
        public PointOfInterest DepotLocation { get; set; }
    }
}
