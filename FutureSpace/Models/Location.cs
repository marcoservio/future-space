namespace FutureSpace.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Country_Code { get; set; }
        public string Map_Image { get; set; }
        public int Total_Launch_Count { get; set; }
        public int Total_Landing_Count { get; set; }
    }
}