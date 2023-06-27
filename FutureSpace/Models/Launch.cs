namespace FutureSpace.Models
{
    public class Launch
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string LaunchLibraryId { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public virtual Status Status { get; set; }
        public string Net { get; set; }
        public DateTime WindowEnd { get; set; }
        public DateTime WindowStart { get; set; }
        public bool Inhold { get; set; }
        public bool TbdTime { get; set; }
        public bool TbdDate { get; set; }
        public string Probability { get; set; }
        public string HoldReason { get; set; }
        public string FailReason { get; set; }
        public string Hashtag { get; set; }
        public virtual LaunchServiceProvider LaunchServiceProvider { get; set; }
        public virtual Rocket Rocket { get; set; }
        public virtual Mission Mission { get; set; }
        public virtual Pad Pad { get; set; }
        public bool WebcastLive { get; set; }
        public string Image { get; set; }
        public string Infographic { get; set; }
        public string Program { get; set; }
    }
}
