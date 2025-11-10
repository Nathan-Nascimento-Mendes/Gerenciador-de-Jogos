using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gerenciador_de_Jogos.Migrations
{
    /// <inheritdoc />
    public partial class RecrateSeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JogoGeneros",
                columns: new[] { "GeneroId", "JogoId" },
                values: new object[,]
                {
                    { 2, 6 },
                    { 12, 6 },
                    { 12, 7 },
                    { 14, 7 },
                    { 1, 8 },
                    { 2, 8 },
                    { 8, 9 },
                    { 11, 9 },
                    { 1, 10 },
                    { 14, 10 },
                    { 8, 11 },
                    { 13, 11 },
                    { 1, 12 },
                    { 12, 12 },
                    { 8, 13 },
                    { 10, 13 },
                    { 1, 14 },
                    { 15, 14 },
                    { 5, 15 },
                    { 15, 15 },
                    { 1, 16 },
                    { 7, 16 },
                    { 4, 17 },
                    { 5, 17 },
                    { 2, 18 },
                    { 12, 18 }
                });

            migrationBuilder.InsertData(
                table: "JogoPlataformas",
                columns: new[] { "JogoId", "PlataformaId", "PlataformaId1", "Valor" },
                values: new object[,]
                {
                    { 2, 4, null, 189.90m },
                    { 3, 2, null, 159.90m },
                    { 4, 4, null, 139.90m },
                    { 5, 2, null, 89.90m },
                    { 6, 4, null, 139.90m },
                    { 7, 4, null, 169.90m },
                    { 8, 8, null, 259.90m },
                    { 9, 2, null, 89.90m },
                    { 10, 6, null, 189.90m },
                    { 11, 1, null, 49.90m },
                    { 11, 4, null, 59.90m },
                    { 12, 4, null, 199.90m },
                    { 12, 8, null, 219.90m },
                    { 13, 2, null, 79.90m },
                    { 13, 4, null, 69.90m },
                    { 14, 5, null, 249.90m },
                    { 14, 6, null, 269.90m },
                    { 15, 4, null, 129.90m },
                    { 15, 8, null, 139.90m },
                    { 16, 4, null, 199.90m },
                    { 16, 7, null, 209.90m },
                    { 17, 7, null, 289.90m },
                    { 17, 8, null, 299.90m },
                    { 18, 2, null, 299.90m },
                    { 18, 4, null, 289.90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 12, 7 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 14, 7 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 11, 9 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 14, 10 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 8, 11 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 13, 11 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 12, 12 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 8, 13 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 10, 13 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 15, 14 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 15, 15 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 7, 16 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 5, 17 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "JogoGeneros",
                keyColumns: new[] { "GeneroId", "JogoId" },
                keyValues: new object[] { 12, 18 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 12, 8 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 14, 6 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 15, 4 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 15, 8 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 16, 4 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 16, 7 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 17, 7 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 17, 8 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "JogoPlataformas",
                keyColumns: new[] { "JogoId", "PlataformaId" },
                keyValues: new object[] { 18, 4 });
        }
    }
}
