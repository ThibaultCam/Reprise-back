using Reprise_back.Repository.Interface;
using Reprise_back.Service.Interface;

namespace Reprise_back.Service
{
    public class UserDataFilmService : IUserDataFilmService
    {
        private readonly IUserDataFilmRepository _repo;
        public UserDataFilmService(IUserDataFilmRepository repo) => _repo = repo;
        public Task DeleteFilmRate(Guid filmId, string userId) => _repo.DeleteFilmRate(filmId, userId);

        public Task UpdateFilmRate(double rate, Guid filmId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
