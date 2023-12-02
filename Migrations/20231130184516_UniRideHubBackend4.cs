using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniRideHubBackend.Migrations
{
    /// <inheritdoc />
    public partial class UniRideHubBackend4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avg_rating",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "total_Seats",
                table: "Rides",
                newName: "Total_Seats");

            migrationBuilder.RenameColumn(
                name: "source",
                table: "Rides",
                newName: "Source");

            migrationBuilder.RenameColumn(
                name: "mid_routes",
                table: "Rides",
                newName: "Mid_routes");

            migrationBuilder.RenameColumn(
                name: "fare",
                table: "Rides",
                newName: "Fare");

            migrationBuilder.RenameColumn(
                name: "destination",
                table: "Rides",
                newName: "Destination");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Rides",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "User_Rides",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ride_id = table.Column<int>(type: "int", nullable: false),
                    User_type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avg_rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Rides", x => x.User_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Rides");

            migrationBuilder.RenameColumn(
                name: "Total_Seats",
                table: "Rides",
                newName: "total_Seats");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "Rides",
                newName: "source");

            migrationBuilder.RenameColumn(
                name: "Mid_routes",
                table: "Rides",
                newName: "mid_routes");

            migrationBuilder.RenameColumn(
                name: "Fare",
                table: "Rides",
                newName: "fare");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Rides",
                newName: "destination");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rides",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "Avg_rating",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
