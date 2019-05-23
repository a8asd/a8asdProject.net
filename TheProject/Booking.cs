namespace TheProject
{
    public class Booking
    {
        public Customer Customer;
        public Driver Driver;
        public bool Complete { get; set; }
        public int Distance { get; set; }
    }
}