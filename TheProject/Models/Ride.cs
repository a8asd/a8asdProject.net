namespace TheProject.Models
{
    public class Ride
    {
        public double Distance { get; set; }
        public string RiderName { get; set; }
        public Location Destination { get; set; }
        public string DriverName { get; set; }
        public RideStatus Status { get; set; }
        public Location Start { get; set; }

        public void Accept()
        {
            Status = RideStatus.Accepted;
        }
    }
}