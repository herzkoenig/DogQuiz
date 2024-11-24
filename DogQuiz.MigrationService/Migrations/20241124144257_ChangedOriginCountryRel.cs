using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogQuiz.MigrationService.Migrations
{
    /// <inheritdoc />
    public partial class ChangedOriginCountryRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_BreedOrigin_OriginId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_BreedOrigin_BreedOriginId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_BreedOriginId",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BreedOrigin",
                table: "BreedOrigin");

            migrationBuilder.DropColumn(
                name: "BreedOriginId",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "BreedOrigin",
                newName: "BreedOrigins");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BreedOrigins",
                table: "BreedOrigins",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BreedOriginCountry",
                columns: table => new
                {
                    BreedOriginsId = table.Column<int>(type: "int", nullable: false),
                    CountriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedOriginCountry", x => new { x.BreedOriginsId, x.CountriesId });
                    table.ForeignKey(
                        name: "FK_BreedOriginCountry_BreedOrigins_BreedOriginsId",
                        column: x => x.BreedOriginsId,
                        principalTable: "BreedOrigins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreedOriginCountry_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedOriginCountry_CountriesId",
                table: "BreedOriginCountry",
                column: "CountriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_BreedOrigins_OriginId",
                table: "Breeds",
                column: "OriginId",
                principalTable: "BreedOrigins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_BreedOrigins_OriginId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BreedOriginCountry");

            migrationBuilder.DropIndex(
                name: "IX_Users_CountryId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BreedOrigins",
                table: "BreedOrigins");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "BreedOrigins",
                newName: "BreedOrigin");

            migrationBuilder.AddColumn<int>(
                name: "BreedOriginId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BreedOrigin",
                table: "BreedOrigin",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_BreedOriginId",
                table: "Countries",
                column: "BreedOriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_BreedOrigin_OriginId",
                table: "Breeds",
                column: "OriginId",
                principalTable: "BreedOrigin",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_BreedOrigin_BreedOriginId",
                table: "Countries",
                column: "BreedOriginId",
                principalTable: "BreedOrigin",
                principalColumn: "Id");
        }
    }
}
