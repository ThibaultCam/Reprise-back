namespace Reprise_back.Models
{
    public class UserFilmRate
    {
        public Guid Id { get; set; }
        public required string UserId { get; set; }
        public required Guid FilmId { get; set; }
        public Film? Film { get; set; }
        public double Rate { get; set; }
    }
}
