namespace FutureSpace.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string MapImage { get; set; }
        public int TotalLaunchCount { get; set; }
        public int TotalLandingCount { get; set; }
    }
}