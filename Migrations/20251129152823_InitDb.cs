using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reprise_back.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenres",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenres", x => new { x.FilmId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_FilmGenres_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeasonNumber = table.Column<int>(type: "int", nullable: false),
                    NbEpisodes = table.Column<int>(type: "int", nullable: false),
                    SerieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seasons_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerieGenres",
                columns: table => new
                {
                    SerieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieGenres", x => new { x.SerieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_SerieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerieGenres_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "DurationMinutes", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "A thief who steals corporate secrets through the use of dream-sharing technology.", 148, "Inception", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), "A computer hacker learns about the true nature of his reality and his role in the war against its controllers.", 136, "The Matrix", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", 169, "Interstellar", new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Action" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Drama" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Science Fiction" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Description", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd"), "A high school chemistry teacher turned methamphetamine producer navigates the dangers of the drug trade.", "Breaking Bad", new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"), "A group of kids in the 1980s uncover supernatural mysteries in their small town.", "Stranger Things", new DateTime(2016, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "FilmGenres",
                columns: new[] { "FilmId", "GenreId" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("cccccccc-cccc-cccc-cccc-cccccccccccc"), new Guid("33333333-3333-3333-3333-333333333333") }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "NbEpisodes", "SeasonNumber", "SerieId" },
                values: new object[,]
                {
                    { new Guid("f1111111-1111-1111-1111-111111111111"), 7, 1, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("f2222222-2222-2222-2222-222222222222"), 13, 2, new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("f3333333-3333-3333-3333-333333333333"), 8, 1, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("f4444444-4444-4444-4444-444444444444"), 9, 2, new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") }
                });

            migrationBuilder.InsertData(
                table: "SerieGenres",
                columns: new[] { "GenreId", "SerieId" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222222"), new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd") },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenres_GenreId",
                table: "FilmGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SerieId",
                table: "Seasons",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_SerieGenres_GenreId",
                table: "SerieGenres",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenres");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "SerieGenres");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
