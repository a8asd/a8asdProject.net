namespace TheProject.Models
{
    public class RideRequest
    {
        public Location Destination { get; set; }
        public Location Start { get; set; }
        public string RiderName { get; set; }
        public bool Accepted { get; private set; }

        public void Accept()
        {
            Accepted = true;
        }
    }
}