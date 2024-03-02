using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFisherWebApp.Migrations
{
    /// <inheritdoc />
    public partial class LinkUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Albums_AlbumId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Artists_ArtistId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_AlbumId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_ArtistId",
                table: "Links");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Links",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Links",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Links_AlbumId",
                table: "Links",
                column: "AlbumId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Links_ArtistId",
                table: "Links",
                column: "ArtistId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Albums_AlbumId",
                table: "Links",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Artists_ArtistId",
                table: "Links",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Albums_AlbumId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Artists_ArtistId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_AlbumId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_ArtistId",
                table: "Links");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Links",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "Links",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Links_AlbumId",
                table: "Links",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_ArtistId",
                table: "Links",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Albums_AlbumId",
                table: "Links",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Artists_ArtistId",
                table: "Links",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }
    }
}
