namespace Reprise_back.Models
{
    public class Media : BaseNamedEntity
    {
        public List<Genre> Genre { get; set; } = new List<Genre>();
        public DateTime ReleaseDate { get; set; }
    }
}
