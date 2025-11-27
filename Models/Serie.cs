namespace Reprise_back.Models
{
    public class Serie : Media
    {
        public List<Seasons> Seasons { get; set; } = new List<Seasons>();
    }
}
