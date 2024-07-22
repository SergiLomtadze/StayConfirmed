using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayConfirmed.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsoCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsoCounty",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsoCounty",
                table: "InputFromCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalPax",
                table: "InputFromCustomers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsoCounty",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsoCounty",
                table: "InputFromCustomers");

            migrationBuilder.DropColumn(
                name: "TotalPax",
                table: "InputFromCustomers");
        }
    }
}
