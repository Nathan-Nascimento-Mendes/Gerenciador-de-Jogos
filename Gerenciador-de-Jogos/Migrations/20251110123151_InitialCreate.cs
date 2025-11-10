using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gerenciador_de_Jogos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Capa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plataformas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataformas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JogoGeneros",
                columns: table => new
                {
                    JogoId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogoGeneros", x => new { x.JogoId, x.GeneroId });
                    table.ForeignKey(
                        name: "FK_JogoGeneros_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogoGeneros_Jogos_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JogoPlataformas",
                columns: table => new
                {
                    JogoId = table.Column<int>(type: "int", nullable: false),
                    PlataformaId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlataformaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogoPlataformas", x => new { x.JogoId, x.PlataformaId });
                    table.ForeignKey(
                        name: "FK_JogoPlataformas_Jogos_JogoId",
                        column: x => x.JogoId,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogoPlataformas_Plataformas_PlataformaId",
                        column: x => x.PlataformaId,
                        principalTable: "Plataformas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogoPlataformas_Plataformas_PlataformaId1",
                        column: x => x.PlataformaId1,
                        principalTable: "Plataformas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Ação" },
                    { 2, "Aventura" },
                    { 3, "Caça" },
                    { 4, "Corrida" },
                    { 5, "Exploração" },
                    { 6, "Estratégia" },
                    { 7, "FPS" },
                    { 8, "Indie" },
                    { 9, "Metroidvania" },
                    { 10, "Plataforma" },
                    { 11, "Roguelike" },
                    { 12, "RPG" },
                    { 13, "Simulação" },
                    { 14, "Soulslike" },
                    { 15, "Sobrevivência" }
                });

            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "Id", "Ano", "Capa", "Titulo" },
                values: new object[,]
                {
                    { 1, 2022, "https://image.api.playstation.com/vulcan/ap/rnd/202110/2000/YMUoJUYNX0xWk6eTKuZLr5Iw.jpg", "Elden Ring" },
                    { 2, 2021, "https://www.monsterhunter.com/rise/assets/images/common/share.png", "Monster Hunter Rise" },
                    { 3, 2025, "https://assets.nintendo.com/image/upload/ar_16:9,c_lpad,w_1240/b_white/f_auto/q_auto/ncom/software/switch/70010000020840/60eebc8f7133f685eddbffbe43c8da617ba0a5d699f2008f9c31c6119d1792af", "Hollow Knight: Silksong" },
                    { 4, 2016, "https://cdn1.epicgames.com/offer/c8738a4d1ead40368eab9688b3c7d737/EGS_SkyrimSpecialEdition_BethesdaGameStudios_S1_2560x1440-dcf7c2839f4a13b0d921a8f146c8c922", "The Elder Scrolls V: Skyrim Special Edition" },
                    { 5, 2018, "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/588650/capsule_616x353.jpg?t=1757600364", "Dead Cells" },
                    { 6, 2015, "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/292030/header.jpg", "The Witcher 3: Wild Hunt" },
                    { 7, 2016, "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/374320/header.jpg", "Dark Souls III" },
                    { 8, 2018, "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/1174180/header.jpg", "Red Dead Redemption 2" },
                    { 9, 2020, "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/1145360/header.jpg", "Hades" },
                    { 10, 2015, "https://upload.wikimedia.org/wikipedia/en/1/15/Bloodborne_Cover.jpg", "Bloodborne" },
                    { 11, 2016, "https://upload.wikimedia.org/wikipedia/en/8/82/Stardew_Valley_cover_art.jpg", "Stardew Valley" },
                    { 12, 2020, "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/1091500/header.jpg", "Cyberpunk 2077" },
                    { 13, 2018, "https://upload.wikimedia.org/wikipedia/en/4/45/Celeste_cover_art.jpg", "Celeste" },
                    { 14, 2023, "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/2050650/header.jpg", "Resident Evil 4 Remake" },
                    { 15, 2016, "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/275850/header.jpg", "No Man's Sky" },
                    { 16, 2020, "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/782330/header.jpg", "Doom Eternal" },
                    { 17, 2021, "https://upload.wikimedia.org/wikipedia/en/7/7d/Forza_Horizon_5_cover_art.jpg", "Forza Horizon 5" },
                    { 18, 2023, "https://upload.wikimedia.org/wikipedia/en/a/a3/The_Legend_of_Zelda_Tears_of_the_Kingdom_box_art.jpg", "The Legend of Zelda: Tears of the Kingdom" }
                });

            migrationBuilder.InsertData(
                table: "Plataformas",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Mobile" },
                    { 2, "Nintendo Switch 1" },
                    { 3, "Nintendo Switch 2" },
                    { 4, "PC" },
                    { 5, "PlayStation 4" },
                    { 6, "PlayStation 5" },
                    { 7, "Xbox One" },
                    { 8, "Xbox Series S|X" }
                });

            migrationBuilder.InsertData(
                table: "JogoGeneros",
                columns: new[] { "GeneroId", "JogoId" },
                values: new object[,]
                {
                    { 12, 1 },
                    { 14, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 9, 3 },
                    { 10, 3 },
                    { 2, 4 },
                    { 12, 4 },
                    { 10, 5 },
                    { 11, 5 }
                });

            migrationBuilder.InsertData(
                table: "JogoPlataformas",
                columns: new[] { "JogoId", "PlataformaId", "PlataformaId1", "Valor" },
                values: new object[,]
                {
                    { 1, 4, null, 249.90m },
                    { 1, 6, null, 299.90m },
                    { 2, 2, null, 199.90m },
                    { 3, 4, null, 149.90m },
                    { 4, 5, null, 159.90m },
                    { 5, 4, null, 79.90m },
                    { 6, 5, null, 129.90m },
                    { 7, 5, null, 189.90m },
                    { 8, 7, null, 249.90m },
                    { 9, 4, null, 79.90m },
                    { 10, 5, null, 179.90m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JogoGeneros_GeneroId",
                table: "JogoGeneros",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_JogoPlataformas_PlataformaId",
                table: "JogoPlataformas",
                column: "PlataformaId");

            migrationBuilder.CreateIndex(
                name: "IX_JogoPlataformas_PlataformaId1",
                table: "JogoPlataformas",
                column: "PlataformaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogoGeneros");

            migrationBuilder.DropTable(
                name: "JogoPlataformas");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Plataformas");
        }
    }
}
