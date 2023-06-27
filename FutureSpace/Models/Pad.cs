namespace FutureSpace.Models
{
    public class Pad
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string AgencyId { get; set; }
        public string Name { get; set; }
        public string InfoUrl { get; set; }
        public string WikiUrl { get; set; }
        public string MapUrl { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public virtual Location Location { get; set; }
        public string MapImage { get; set; }
        public int Total_Launch_Count { get; set; }
    }
}