namespace FutureSpace.Models
{
    public class Launch
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Launch_Library_Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public virtual Status Status { get; set; }
        public DateTime Net { get; set; }
        public DateTime Window_End { get; set; }
        public DateTime Window_Start { get; set; }
        public bool Inhold { get; set; }
        public bool TbdTime { get; set; }
        public bool TbdDate { get; set; }
        public string Probability { get; set; }
        public string HoldReason { get; set; }
        public string FailReason { get; set; }
        public string Hashtag { get; set; }
        public virtual LaunchServiceProvider Launch_Service_Provider { get; set; }
        public virtual Rocket Rocket { get; set; }
        public virtual Mission Mission { get; set; }
        public virtual Pad Pad { get; set; }
        public bool Webcast_Live { get; set; }
        public string Image { get; set; }
        public string Infographic { get; set; }
        public virtual List<Program_Launch> Program { get; set; }
        public DateTime Imported_t { get; set; }
        public string Status_t { get; set; }
    }
}
