using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFisherWebApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveContentTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Contents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Contents",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
