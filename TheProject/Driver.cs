namespace TheProject
{
    public class Driver
    {
        public string Name { get; set; }
        public LuberLocation Location { get; set; }
        public double AverageKph { get; } = 60;

        public string TimeToPickup(LuberLocation from)
        {
            var distance = Location.Distance(from);
            var seconds = (int) (distance * 60);
            return string.Format("{0}m {1}s", (seconds / 60), seconds % 60);
        }
    }
}