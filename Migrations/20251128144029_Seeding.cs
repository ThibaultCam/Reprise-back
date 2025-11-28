using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reprise_back.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons");

            migrationBuilder.AlterColumn<int>(
                name: "SerieId",
                table: "Seasons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "DurationMinutes", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "A thief who steals corporate secrets through the use of dream-sharing technology.", 148, "Inception", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "A computer hacker learns about the true nature of his reality and his role in the war against its controllers.", 136, "The Matrix", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", 169, "Interstellar", new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Series",
                columns: new[] { "Id", "Description", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "A high school chemistry teacher turned methamphetamine producer navigates the dangers of the drug trade.", "Breaking Bad", new DateTime(2008, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "A group of kids in the 1980s uncover supernatural mysteries in their small town.", "Stranger Things", new DateTime(2016, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "Id", "NbEpisodes", "SeasonNumber", "SerieId" },
                values: new object[,]
                {
                    { 1, 5, 1, 1 },
                    { 2, 5, 2, 1 },
                    { 3, 5, 1, 2 },
                    { 4, 5, 2, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons");

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seasons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Series",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "SerieId",
                table: "Seasons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Series_SerieId",
                table: "Seasons",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");
        }
    }
}
