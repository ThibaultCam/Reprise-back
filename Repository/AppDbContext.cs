using Microsoft.EntityFrameworkCore;
using Reprise_back.Models;

namespace Reprise_back.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Film> Films => Set<Film>();
        public DbSet<Serie> Series => Set<Serie>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Seasons> Seasons => Set<Seasons>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().ToTable("Films");
            modelBuilder.Entity<Serie>().ToTable("Series");

            // Relations Film-Genre
            modelBuilder.Entity<Film>()
                .HasMany(f => f.Genres)
                .WithMany(g => g.Films)
                .UsingEntity<FilmGenre>(
                    j => j
                        .HasOne(fg => fg.Genre)
                        .WithMany(g => g.FilmGenres)
                        .HasForeignKey(fg => fg.GenreId),
                    j => j
                        .HasOne(fg => fg.Film)
                        .WithMany(f => f.FilmGenres)
                        .HasForeignKey(fg => fg.FilmId),
                    j =>
                    {
                        j.HasKey(fg => new { fg.FilmId, fg.GenreId });
                        j.ToTable("FilmGenres");
                    });

            // Relations Serie-Genre
            modelBuilder.Entity<Serie>()
                .HasMany(s => s.Genres)
                .WithMany(g => g.Series)
                .UsingEntity<SerieGenre>(
                    j => j
                        .HasOne(sg => sg.Genre)
                        .WithMany(g => g.SerieGenres)
                        .HasForeignKey(sg => sg.GenreId),
                    j => j
                        .HasOne(sg => sg.Serie)
                        .WithMany(s => s.SerieGenres)
                        .HasForeignKey(sg => sg.SerieId),
                    j =>
                    {
                        j.HasKey(sg => new { sg.SerieId, sg.GenreId });
                        j.ToTable("SerieGenres");
                    });

            // GUID fixes pour Genres
            var genreAction = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var genreDrama = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var genreSciFi = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var genreThriller = Guid.Parse("44444444-4444-4444-4444-444444444444");

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = genreAction, Name = "Action" },
                new Genre { Id = genreDrama, Name = "Drama" },
                new Genre { Id = genreSciFi, Name = "Science Fiction" },
                new Genre { Id = genreThriller, Name = "Thriller" }
            );

            // GUID fixes pour Films
            var filmInception = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
            var filmMatrix = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");
            var filmInterstellar = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc");

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = filmInception,
                    Name = "Inception",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology.",
                    ReleaseDate = new DateTime(2010, 7, 16),
                    DurationMinutes = 148,
                },
                new Film
                {
                    Id = filmMatrix,
                    Name = "The Matrix",
                    Description = "A computer hacker learns about the true nature of his reality and his role in the war against its controllers.",
                    ReleaseDate = new DateTime(1999, 3, 31),
                    DurationMinutes = 136,
                },
                new Film
                {
                    Id = filmInterstellar,
                    Name = "Interstellar",
                    Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                    ReleaseDate = new DateTime(2014, 11, 7),
                    DurationMinutes = 169,
                }
            );

            // GUID fixes pour Series
            var serieBreakingBad = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd");
            var serieStrangerThings = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");

            modelBuilder.Entity<Serie>().HasData(
                new Serie
                {
                    Id = serieBreakingBad,
                    Name = "Breaking Bad",
                    Description = "A high school chemistry teacher turned methamphetamine producer navigates the dangers of the drug trade.",
                    ReleaseDate = new DateTime(2008, 1, 20),
                },
                new Serie
                {
                    Id = serieStrangerThings,
                    Name = "Stranger Things",
                    Description = "A group of kids in the 1980s uncover supernatural mysteries in their small town.",
                    ReleaseDate = new DateTime(2016, 7, 15),
                }
            );

            // GUID fixes pour Seasons
            var season1BreakingBad = Guid.Parse("f1111111-1111-1111-1111-111111111111");
            var season2BreakingBad = Guid.Parse("f2222222-2222-2222-2222-222222222222");
            var season1StrangerThings = Guid.Parse("f3333333-3333-3333-3333-333333333333");
            var season2StrangerThings = Guid.Parse("f4444444-4444-4444-4444-444444444444");

            modelBuilder.Entity<Seasons>().HasData(
                new Seasons { Id = season1BreakingBad, SerieId = serieBreakingBad, SeasonNumber = 1, NbEpisodes = 7 },
                new Seasons { Id = season2BreakingBad, SerieId = serieBreakingBad, SeasonNumber = 2, NbEpisodes = 13 },
                new Seasons { Id = season1StrangerThings, SerieId = serieStrangerThings, SeasonNumber = 1, NbEpisodes = 8 },
                new Seasons { Id = season2StrangerThings, SerieId = serieStrangerThings, SeasonNumber = 2, NbEpisodes = 9 }
            );

            // Relations Film-Genre fixes
            modelBuilder.Entity<FilmGenre>().HasData(
                new FilmGenre { FilmId = filmInception, GenreId = genreSciFi },
                new FilmGenre { FilmId = filmMatrix, GenreId = genreSciFi },
                new FilmGenre { FilmId = filmInterstellar, GenreId = genreSciFi },
                new FilmGenre { FilmId = filmInterstellar, GenreId = genreDrama }
            );

            // Relations Serie-Genre fixes
            modelBuilder.Entity<SerieGenre>().HasData(
                new SerieGenre { SerieId = serieBreakingBad, GenreId = genreDrama },
                new SerieGenre { SerieId = serieBreakingBad, GenreId = genreThriller },
                new SerieGenre { SerieId = serieStrangerThings, GenreId = genreSciFi },
                new SerieGenre { SerieId = serieStrangerThings, GenreId = genreThriller }
            );
        }
    }
}