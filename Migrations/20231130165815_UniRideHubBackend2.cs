using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniRideHubBackend.Migrations
{
    /// <inheritdoc />
    public partial class UniRideHubBackend2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Avg_rating",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avg_rating",
                table: "Users");
        }
    }
}
