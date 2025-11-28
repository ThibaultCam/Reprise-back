using Microsoft.EntityFrameworkCore;
using Reprise_back.Models;

namespace Reprise_back.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Film> Films => Set<Film>();
        public DbSet<Serie> Series => Set<Serie>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().ToTable("Films");
            modelBuilder.Entity<Serie>().ToTable("Series");
            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 1,
                    Name = "Inception",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology.",
                    ReleaseDate = new DateTime(2010, 7, 16),
                    DurationMinutes = 148
                },
                new Film
                {
                    Id = 2,
                    Name = "The Matrix",
                    Description = "A computer hacker learns about the true nature of his reality and his role in the war against its controllers.",
                    ReleaseDate = new DateTime(1999, 3, 31),
                    DurationMinutes = 136
                },
                new Film
                {
                    Id = 3,
                    Name = "Interstellar",
                    Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                    ReleaseDate = new DateTime(2014, 11, 7),
                    DurationMinutes = 169
                }
                );
            modelBuilder.Entity<Serie>().HasData(
                new Serie
                {
                    Id = 1,
                    Name = "Breaking Bad",
                    Description = "A high school chemistry teacher turned methamphetamine producer navigates the dangers of the drug trade.",
                    ReleaseDate = new DateTime(2008, 1, 20),
                },
                new Serie
                {
                    Id = 2,
                    Name = "Stranger Things",
                    Description = "A group of kids in the 1980s uncover supernatural mysteries in their small town.",
                    ReleaseDate = new DateTime(2016, 7, 15),
                }
                );

            modelBuilder.Entity<Seasons>().HasData(
                new Seasons { Id = 1, SerieId = 1, SeasonNumber = 1, NbEpisodes = 5 },
                new Seasons { Id = 2, SerieId = 1, SeasonNumber = 2, NbEpisodes = 5 },
                new Seasons { Id = 3, SerieId = 2, SeasonNumber = 1, NbEpisodes = 5 },
                new Seasons { Id = 4, SerieId = 2, SeasonNumber = 2, NbEpisodes = 5 }
            );

        }
    }

}
