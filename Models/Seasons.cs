namespace Reprise_back.Models
{
    public class Seasons
    {
        public Guid Id { get; set; }
        public int SeasonNumber { get; set; }
        public int NbEpisodes { get; set; } = 0;
        public Guid SerieId { get; set; }
        public Serie? Serie { get; set; }
    }
}