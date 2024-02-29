using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFisherWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tier = table.Column<int>(type: "INTEGER", nullable: false),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Albums_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contents_Artists_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Src = table.Column<string>(type: "TEXT", nullable: false),
                    Alt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Albums_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_Artists_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppleURI = table.Column<string>(type: "TEXT", nullable: false),
                    SpotifyURI = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Albums_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Artists_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Albums_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tags_Artists_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "Rank", "Title" },
                values: new object[] { 7, 1, "A Head Full of Dreams" });

            migrationBuilder.InsertData(
                table: "Contents",
                columns: new[] { "Id", "EntityId", "Text" },
                values: new object[] { 1, 7, "\"It was just time for us to make an album about hope and love and togetherness\"-Chris Martin. A Head Full of Dreams is my favorite Coldplay Album, and its central theme is the graduation and application of the hopeful yearning found in past albums. A Head Full of Dreams stand in contrast as the day to the night that was Ghost Stories. Ghost Stories was raw and depressing and overwhelmingly dark, AHFOD enlightens us once again to the joy found in everyday life. The album cover alone, with its rainbow circle of life, bursting with color is directly contrasted to the darkness that was Ghost Stories. \"A Head Full of Dreams,\" \"Birds\" and \"Fun\" are upbeat and hopeful alternative hits that draw us into the irrepressible happiness of the album. At the same time, songs like \"Hymn for the Weekend\" and \"Adventure a Lifetime\" fuse conventional alternative with bright and colorful pop-rock. Musically, \"Birds\" and \"Up&Up\" draw you in with their driven beats and uplifting chords, while \"Amazing Day\" surrounds you with feelings of peaceful love." });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Alt", "EntityId", "Src" },
                values: new object[] { 1, "Album Cover, A Head Full of Dreams - Coldplay", 7, "/music/coldplay-albums/a-head-full-of-dreams.jpg" });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "AppleURI", "EntityId", "SpotifyURI" },
                values: new object[] { 1, "a-head-full-of-dreams/1053933969", 7, "3cfAM8b8KqJRoIzt3zLKqw" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Content", "EntityId", "Title" },
                values: new object[] { 1, "Coloratura, Let Somebody Know", 7, "Favorite Tracks:" });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_EntityId",
                table: "Contents",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_EntityId",
                table: "Images",
                column: "EntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Links_EntityId",
                table: "Links",
                column: "EntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_EntityId",
                table: "Tags",
                column: "EntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
