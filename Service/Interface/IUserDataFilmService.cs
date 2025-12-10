namespace Reprise_back.Service.Interface
{
    public interface IUserDataFilmService
    {
        Task UpdateFilmRate(double rate, Guid filmId, string userId);
        Task DeleteFilmRate(Guid filmId, string userId);
    }
}
