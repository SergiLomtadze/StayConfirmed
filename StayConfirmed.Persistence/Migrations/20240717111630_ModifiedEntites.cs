using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayConfirmed.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedEntites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Wallets",
                newName: "IdWallet");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transactions",
                newName: "IdTransaction");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stakeholders",
                newName: "IdStakeholder");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "IdRole");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservations",
                newName: "IdReservation");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReservationOperationalStatuses",
                newName: "IdReservationOperationalStatus");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReservationCustomerStatuses",
                newName: "IdReservationCustomerStatus");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ReservationComunications",
                newName: "IdReservationComunication");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PropertyProviderMappers",
                newName: "IdPropertyProviderMapper");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PropertyInfos",
                newName: "IdProperty");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PropertyContacts",
                newName: "IdPropertyContact");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profiles",
                newName: "IdProfile");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PricingModels",
                newName: "IdPricingModel");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MapProviders",
                newName: "IdMapProvider");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InputFromCustomers",
                newName: "IdInputFromCustomer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Currencies",
                newName: "IdCurrency");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CheckRules",
                newName: "IdCheckRule");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brands",
                newName: "IdBrand");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IdWallet",
                table: "Wallets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdTransaction",
                table: "Transactions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdStakeholder",
                table: "Stakeholders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdReservation",
                table: "Reservations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdReservationOperationalStatus",
                table: "ReservationOperationalStatuses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdReservationCustomerStatus",
                table: "ReservationCustomerStatuses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdReservationComunication",
                table: "ReservationComunications",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdPropertyProviderMapper",
                table: "PropertyProviderMappers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdProperty",
                table: "PropertyInfos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdPropertyContact",
                table: "PropertyContacts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdProfile",
                table: "Profiles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdPricingModel",
                table: "PricingModels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdMapProvider",
                table: "MapProviders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdInputFromCustomer",
                table: "InputFromCustomers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdCurrency",
                table: "Currencies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdCheckRule",
                table: "CheckRules",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdBrand",
                table: "Brands",
                newName: "Id");
        }
    }
}
