namespace FutureSpace.Models
{
    public class Rocket
    {
        public int Id { get; set; }
        public virtual Configuration Configuration { get; set; }
    }
}