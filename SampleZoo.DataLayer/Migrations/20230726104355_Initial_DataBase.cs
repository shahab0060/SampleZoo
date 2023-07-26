using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleZoo.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial_DataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LatestEditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditCounts = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "DeletedOn", "EditCounts", "IsDelete", "LatestEditDate", "Password", "PhoneNumber", "UserName" },
                values: new object[] { 1, new DateTime(2023, 7, 26, 14, 13, 55, 309, DateTimeKind.Local).AddTicks(2618), null, 0, false, new DateTime(2023, 7, 26, 14, 13, 55, 309, DateTimeKind.Local).AddTicks(2628), "shahab0060", "+989026150241", "itsShaab" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
