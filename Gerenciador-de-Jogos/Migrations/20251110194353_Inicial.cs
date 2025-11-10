using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gerenciador_de_Jogos.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Jogos",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Capa",
                value: "https://t2.tudocdn.net/593327?w=1920");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 11,
                column: "Capa",
                value: "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/413150/capsule_616x353.jpg?t=1754692865");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 13,
                column: "Capa",
                value: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/504230/capsule_616x353.jpg?t=1714089525");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 17,
                column: "Capa",
                value: "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/1551360/header.jpg?t=1746471508");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 18,
                column: "Capa",
                value: "https://assets.nuuvem.com/image/upload/t_product_sharing_banner/v1/products/6436f817b6a147001a7ea5c8/sharing_images/pc4vqdrrrgme9rgefowf.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Jogos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 10,
                column: "Capa",
                value: "https://upload.wikimedia.org/wikipedia/en/1/15/Bloodborne_Cover.jpg");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 11,
                column: "Capa",
                value: "https://upload.wikimedia.org/wikipedia/en/8/82/Stardew_Valley_cover_art.jpg");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 13,
                column: "Capa",
                value: "https://upload.wikimedia.org/wikipedia/en/4/45/Celeste_cover_art.jpg");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 17,
                column: "Capa",
                value: "https://upload.wikimedia.org/wikipedia/en/7/7d/Forza_Horizon_5_cover_art.jpg");

            migrationBuilder.UpdateData(
                table: "Jogos",
                keyColumn: "Id",
                keyValue: 18,
                column: "Capa",
                value: "https://upload.wikimedia.org/wikipedia/en/a/a3/The_Legend_of_Zelda_Tears_of_the_Kingdom_box_art.jpg");
        }
    }
}
