using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnASP.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 16, 2, 34, 31, 354, DateTimeKind.Utc).AddTicks(9712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 15, 15, 25, 12, 759, DateTimeKind.Utc).AddTicks(756));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "Bill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 15, 15, 25, 12, 759, DateTimeKind.Utc).AddTicks(756),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 16, 2, 34, 31, 354, DateTimeKind.Utc).AddTicks(9712));
        }
    }
}
