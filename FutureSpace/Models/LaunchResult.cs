using System.Diagnostics;

namespace FutureSpace.Models
{
    public class LaunchResult
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public virtual List<Launch> Results { get; set; }
    }
}
