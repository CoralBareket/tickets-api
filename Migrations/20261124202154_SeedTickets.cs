using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketsApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "CreatedAt", "Description", "Priority", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 11, 20, 9, 0, 0, 0, DateTimeKind.Utc), "User receives an error when attempting to sign in.", "High", "Open", "Unable to log in" },
                    { 2, new DateTime(2026, 11, 21, 10, 30, 0, 0, DateTimeKind.Utc), "The dashboard takes several seconds to display data.", "Medium", "InProgress", "Dashboard loading slowly" },
                    { 3, new DateTime(2026, 11, 22, 14, 0, 0, 0, DateTimeKind.Utc), "The profile image was not updated after uploading a new one.", "Low", "Closed", "Incorrect profile image" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
