using System.Numerics;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementPortal.Migrations
{
    /// <inheritdoc />
    public partial class FixPhoneNumberType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "text",
                nullable: false,
                oldClrType: typeof(BigInteger),
                oldType: "numeric");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<BigInteger>(
                name: "PhoneNumber",
                table: "Employees",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
