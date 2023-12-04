using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniRideHubBackend.Migrations
{
    /// <inheritdoc />
    public partial class imagepath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MapImage",
                table: "Rides",
                newName: "MapImageFileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MapImageFileName",
                table: "Rides",
                newName: "MapImage");
        }
    }
}
