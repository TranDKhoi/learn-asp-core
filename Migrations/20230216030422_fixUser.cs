using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnASP.Migrations
{
    public partial class fixUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 16, 3, 4, 22, 797, DateTimeKind.Utc).AddTicks(9780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 16, 2, 34, 31, 354, DateTimeKind.Utc).AddTicks(9712));

            migrationBuilder.CreateIndex(
                name: "IX_User_username",
                table: "User",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_username",
                table: "User");

            migrationBuilder.DropColumn(
                name: "password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "username",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 16, 2, 34, 31, 354, DateTimeKind.Utc).AddTicks(9712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 16, 3, 4, 22, 797, DateTimeKind.Utc).AddTicks(9780));
        }
    }
}
