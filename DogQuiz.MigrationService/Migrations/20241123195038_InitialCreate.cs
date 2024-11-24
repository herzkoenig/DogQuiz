using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogQuiz.MigrationService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreedOrigin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoricalContext = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedOrigin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwoLetterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreeLetterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumericCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreedOriginId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_BreedOrigin_BreedOriginId",
                        column: x => x.BreedOriginId,
                        principalTable: "BreedOrigin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityProviderId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_PermissionRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "PermissionRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionRolePermission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    PermissionRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionRolePermission", x => new { x.PermissionId, x.PermissionRoleId });
                    table.ForeignKey(
                        name: "FK_PermissionRolePermission_PermissionRoles_PermissionRoleId",
                        column: x => x.PermissionRoleId,
                        principalTable: "PermissionRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionRolePermission_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    AnswerType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    ChoiceId = table.Column<int>(type: "int", nullable: true),
                    Answer = table.Column<bool>(type: "bit", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answers_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answers_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    AnswerMultipleSelectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choice_Answers_AnswerMultipleSelectId",
                        column: x => x.AnswerMultipleSelectId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BreedBreedMix",
                columns: table => new
                {
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    BreedMixId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedBreedMix", x => new { x.BreedId, x.BreedMixId });
                });

            migrationBuilder.CreateTable(
                name: "BreedMixes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1250)", maxLength: 1250, nullable: true),
                    PrimaryImageId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedMixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedMixes_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedMixes_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedMixes_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BreedNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    BreedVarietyId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedNames_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedNames_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedNames_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BreedRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedRoles_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedRoles_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedRoles_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1250)", maxLength: 1250, nullable: true),
                    OriginId = table.Column<int>(type: "int", nullable: true),
                    Difficulty = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeds_BreedOrigin_OriginId",
                        column: x => x.OriginId,
                        principalTable: "BreedOrigin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Breeds_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Breeds_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Breeds_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BreedVarieties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedVarieties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedVarieties_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreedVarieties_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedVarieties_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedVarieties_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Facts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facts_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facts_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facts_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facts_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    BreedVarietyId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_BreedVarieties_BreedVarietyId",
                        column: x => x.BreedVarietyId,
                        principalTable: "BreedVarieties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImageDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Folder = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Attribution = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    License = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    BreedMixId = table.Column<int>(type: "int", nullable: true),
                    NotableDogId = table.Column<int>(type: "int", nullable: true),
                    NotableOwnerId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageDetails_BreedMixes_BreedMixId",
                        column: x => x.BreedMixId,
                        principalTable: "BreedMixes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageDetails_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageDetails_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageDetails_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotableDogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    KnownFor = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1250)", maxLength: 1250, nullable: true),
                    PrimaryImageId = table.Column<int>(type: "int", nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    BreedVarietyId = table.Column<int>(type: "int", nullable: true),
                    BreedMixId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotableDogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotableDogs_BreedMixes_BreedMixId",
                        column: x => x.BreedMixId,
                        principalTable: "BreedMixes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableDogs_BreedVarieties_BreedVarietyId",
                        column: x => x.BreedVarietyId,
                        principalTable: "BreedVarieties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableDogs_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableDogs_ImageDetails_PrimaryImageId",
                        column: x => x.PrimaryImageId,
                        principalTable: "ImageDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableDogs_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableDogs_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableDogs_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotableOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    KnownFor = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1250)", maxLength: 1250, nullable: true),
                    PrimaryImageId = table.Column<int>(type: "int", nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    BreedVarietyId = table.Column<int>(type: "int", nullable: true),
                    BreedMixId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotableOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotableOwners_BreedMixes_BreedMixId",
                        column: x => x.BreedMixId,
                        principalTable: "BreedMixes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableOwners_BreedVarieties_BreedVarietyId",
                        column: x => x.BreedVarietyId,
                        principalTable: "BreedVarieties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableOwners_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableOwners_ImageDetails_PrimaryImageId",
                        column: x => x.PrimaryImageId,
                        principalTable: "ImageDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableOwners_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableOwners_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableOwners_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    QuestionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    BreedMixId = table.Column<int>(type: "int", nullable: true),
                    BreedVarietyId = table.Column<int>(type: "int", nullable: true),
                    NotableDogId = table.Column<int>(type: "int", nullable: true),
                    NotableOwnerId = table.Column<int>(type: "int", nullable: true),
                    ImageQuestionType = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    TextQuestionType = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_BreedMixes_BreedMixId",
                        column: x => x.BreedMixId,
                        principalTable: "BreedMixes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_BreedVarieties_BreedVarietyId",
                        column: x => x.BreedVarietyId,
                        principalTable: "BreedVarieties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_ImageDetails_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImageDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_NotableDogs_NotableDogId",
                        column: x => x.NotableDogId,
                        principalTable: "NotableDogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_NotableOwners_NotableOwnerId",
                        column: x => x.NotableOwnerId,
                        principalTable: "NotableOwners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ChoiceId",
                table: "Answers",
                column: "ChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CreatedById",
                table: "Answers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_DeletedById",
                table: "Answers",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_ImageId",
                table: "Answers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UpdatedById",
                table: "Answers",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedBreedMix_BreedMixId",
                table: "BreedBreedMix",
                column: "BreedMixId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedMixes_CreatedById",
                table: "BreedMixes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedMixes_DeletedById",
                table: "BreedMixes",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedMixes_PrimaryImageId",
                table: "BreedMixes",
                column: "PrimaryImageId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedMixes_UpdatedById",
                table: "BreedMixes",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedNames_BreedId",
                table: "BreedNames",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedNames_BreedVarietyId",
                table: "BreedNames",
                column: "BreedVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedNames_CreatedById",
                table: "BreedNames",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedNames_DeletedById",
                table: "BreedNames",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedNames_UpdatedById",
                table: "BreedNames",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedRoles_BreedId",
                table: "BreedRoles",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedRoles_CreatedById",
                table: "BreedRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedRoles_DeletedById",
                table: "BreedRoles",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedRoles_UpdatedById",
                table: "BreedRoles",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_CreatedById",
                table: "Breeds",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_DeletedById",
                table: "Breeds",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_ImageId",
                table: "Breeds",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_Name",
                table: "Breeds",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_OriginId",
                table: "Breeds",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_UpdatedById",
                table: "Breeds",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedVarieties_BreedId",
                table: "BreedVarieties",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedVarieties_CreatedById",
                table: "BreedVarieties",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedVarieties_DeletedById",
                table: "BreedVarieties",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedVarieties_Name",
                table: "BreedVarieties",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BreedVarieties_UpdatedById",
                table: "BreedVarieties",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_AnswerMultipleSelectId",
                table: "Choice",
                column: "AnswerMultipleSelectId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_BreedOriginId",
                table: "Countries",
                column: "BreedOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_BreedId",
                table: "Facts",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_CreatedById",
                table: "Facts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_DeletedById",
                table: "Facts",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_UpdatedById",
                table: "Facts",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_BreedId",
                table: "ImageDetails",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_BreedMixId",
                table: "ImageDetails",
                column: "BreedMixId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_CreatedById",
                table: "ImageDetails",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_NotableDogId",
                table: "ImageDetails",
                column: "NotableDogId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_NotableOwnerId",
                table: "ImageDetails",
                column: "NotableOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDetails_UpdatedById",
                table: "ImageDetails",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_NotableDogs_BreedId",
                table: "NotableDogs",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_NotableDogs_BreedMixId",
                table: "NotableDogs",
                column: "BreedMixId");

            migrationBuilder.CreateIndex(
                name: "IX_NotableDogs_BreedVarietyId",
                table: "NotableDogs",
                column: "BreedVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_NotableDogs_CreatedById",
                table: "NotableDogs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_NotableDogs_DeletedById",
                table: "NotableDogs",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_NotableDogs_PrimaryImageId",
                table: "NotableDogs",
                column: "PrimaryImageId");

            migrationBuilder.CreateIndex(
                name: "IX_NotableDogs_UpdatedById",
                table: "NotableDogs",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_NotableOwners_BreedId",
                table: "NotableOwners",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_NotableOwners_BreedMixId",
                table: "NotableOwners",
                column: "BreedMixId");

            migrationBuilder.CreateIndex(
                name: "IX_NotableOwners_BreedVarietyId",
                table: "NotableOwners",
                column: "BreedVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_NotableOwners_CreatedById",
                table: "NotableOwners",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_NotableOwners_DeletedById",
                table: "NotableOwners",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_NotableOwners_PrimaryImageId",
                table: "NotableOwners",
                column: "PrimaryImageId");

            migrationBuilder.CreateIndex(
                name: "IX_NotableOwners_UpdatedById",
                table: "NotableOwners",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionRolePermission_PermissionRoleId",
                table: "PermissionRolePermission",
                column: "PermissionRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Name",
                table: "Permissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserId",
                table: "Permissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_BreedId",
                table: "Questions",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_BreedMixId",
                table: "Questions",
                column: "BreedMixId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_BreedVarietyId",
                table: "Questions",
                column: "BreedVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedById",
                table: "Questions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DeletedById",
                table: "Questions",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ImageId",
                table: "Questions",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_NotableDogId",
                table: "Questions",
                column: "NotableDogId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_NotableOwnerId",
                table: "Questions",
                column: "NotableOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UpdatedById",
                table: "Questions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BreedId",
                table: "Tags",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BreedVarietyId",
                table: "Tags",
                column: "BreedVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CreatedById",
                table: "Tags",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_DeletedById",
                table: "Tags",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UpdatedById",
                table: "Tags",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Choice_ChoiceId",
                table: "Answers",
                column: "ChoiceId",
                principalTable: "Choice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_ImageDetails_ImageId",
                table: "Answers",
                column: "ImageId",
                principalTable: "ImageDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_Id",
                table: "Answers",
                column: "Id",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedBreedMix_BreedMixes_BreedMixId",
                table: "BreedBreedMix",
                column: "BreedMixId",
                principalTable: "BreedMixes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedBreedMix_Breeds_BreedId",
                table: "BreedBreedMix",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedMixes_ImageDetails_PrimaryImageId",
                table: "BreedMixes",
                column: "PrimaryImageId",
                principalTable: "ImageDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedNames_BreedVarieties_BreedVarietyId",
                table: "BreedNames",
                column: "BreedVarietyId",
                principalTable: "BreedVarieties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedNames_Breeds_BreedId",
                table: "BreedNames",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedRoles_Breeds_BreedId",
                table: "BreedRoles",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_ImageDetails_ImageId",
                table: "Breeds",
                column: "ImageId",
                principalTable: "ImageDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageDetails_NotableDogs_NotableDogId",
                table: "ImageDetails",
                column: "NotableDogId",
                principalTable: "NotableDogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageDetails_NotableOwners_NotableOwnerId",
                table: "ImageDetails",
                column: "NotableOwnerId",
                principalTable: "NotableOwners",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Choice_ChoiceId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedMixes_ImageDetails_PrimaryImageId",
                table: "BreedMixes");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_ImageDetails_ImageId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableDogs_ImageDetails_PrimaryImageId",
                table: "NotableDogs");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableOwners_ImageDetails_PrimaryImageId",
                table: "NotableOwners");

            migrationBuilder.DropTable(
                name: "BreedBreedMix");

            migrationBuilder.DropTable(
                name: "BreedNames");

            migrationBuilder.DropTable(
                name: "BreedRoles");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Facts");

            migrationBuilder.DropTable(
                name: "PermissionRolePermission");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "ImageDetails");

            migrationBuilder.DropTable(
                name: "NotableDogs");

            migrationBuilder.DropTable(
                name: "NotableOwners");

            migrationBuilder.DropTable(
                name: "BreedMixes");

            migrationBuilder.DropTable(
                name: "BreedVarieties");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "BreedOrigin");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PermissionRoles");
        }
    }
}
