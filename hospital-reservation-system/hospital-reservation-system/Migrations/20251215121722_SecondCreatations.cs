using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hospital_reservation_system.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreatations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "doctors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "doctors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Specialty",
                value: "Cardiology");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Specialty",
                value: "Dermatology");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Specialty",
                value: "Dermatology");

            migrationBuilder.UpdateData(
                table: "doctors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Specialty",
                value: "Cardiology");
        }
    }
}
