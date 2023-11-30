using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniRideHubBackend.Migrations
{
    /// <inheritdoc />
    public partial class UniRideHubBackend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rides_completed",
                table: "Users",
                newName: "Rides_completed");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "mobile",
                table: "Users",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "Last_name");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "First_name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rides_completed",
                table: "Users",
                newName: "rides_completed");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "Users",
                newName: "mobile");

            migrationBuilder.RenameColumn(
                name: "Last_name",
                table: "Users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "First_name",
                table: "Users",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");
        }
    }
}
