namespace Reprise_back.Repository.Interface
{
    public interface IUserDataFilmRepository
    {
        Task UpdateFilmRate(double rate, Guid filmId, string userId);
        Task DeleteFilmRate(Guid filmId, string userId);
    }
}
