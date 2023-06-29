namespace FutureSpace.Models
{
    public class Program_Launch
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Agencia> Agencies { get; set; }
        public string Image_Url { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Info_Url { get; set; }
        public string Wiki_Url { get; set;}
    }
}