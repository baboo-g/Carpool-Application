using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniRideHubBackend.Migrations
{
    /// <inheritdoc />
    public partial class addimagefile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "MapImage",
                table: "Rides",
                type: "longblob",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapImage",
                table: "Rides");
        }
    }
}
