using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleZoo.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Add_Animals_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LatestEditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditCounts = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "CreateDate", "DeletedOn", "EditCounts", "IsDelete", "LatestEditDate", "Title" },
                values: new object[] { 1, 0, new DateTime(2023, 7, 26, 17, 5, 43, 212, DateTimeKind.Local).AddTicks(653), null, 0, false, new DateTime(2023, 7, 26, 17, 5, 43, 212, DateTimeKind.Local).AddTicks(654), "Brad the Dog" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LatestEditDate" },
                values: new object[] { new DateTime(2023, 7, 26, 17, 5, 43, 212, DateTimeKind.Local).AddTicks(451), new DateTime(2023, 7, 26, 17, 5, 43, 212, DateTimeKind.Local).AddTicks(466) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LatestEditDate" },
                values: new object[] { new DateTime(2023, 7, 26, 14, 13, 55, 309, DateTimeKind.Local).AddTicks(2618), new DateTime(2023, 7, 26, 14, 13, 55, 309, DateTimeKind.Local).AddTicks(2628) });
        }
    }
}
