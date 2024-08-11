using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExtremeClassified.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Countryanddivistionsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortalCountries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    LangCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ISO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ISO3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ISONumeric = table.Column<int>(type: "int", nullable: false),
                    Capital = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContinentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedUser = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortalCountries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "CountryAdministrativeDivisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    DivisionType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryAdministrativeDivisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryAdministrativeDivisions_PortalCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "PortalCountries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryAdministrativeDivisions_CountryId",
                table: "CountryAdministrativeDivisions",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryAdministrativeDivisions");

            migrationBuilder.DropTable(
                name: "PortalCountries");
        }
    }
}
