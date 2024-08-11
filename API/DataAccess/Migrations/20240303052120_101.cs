using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExtremeClassified.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingComments");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "Users",
            //    type: "nvarchar(36)",
            //    maxLength: 36,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(50)",
            //    oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "UserRegion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserRegion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ListingAlerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SearchContext = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingAlerts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListingAlerts");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "UserRegion");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserRegion");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "Users",
            //    type: "nvarchar(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(36)",
            //    oldMaxLength: 36);

            migrationBuilder.CreateTable(
                name: "ListingComments",
                columns: table => new
                {
                    CommentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListingId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListingComments", x => x.CommentId);
                });
        }
    }
}
