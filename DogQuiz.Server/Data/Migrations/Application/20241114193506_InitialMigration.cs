using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DogQuiz.Server.Data.Migrations.Application
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BreedCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagGroups_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TagGroups_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TagGroups_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BreedMixes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreedCollectionId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedMixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedMixes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedMixes_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedMixes_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedMixes_BreedCollection_BreedCollectionId",
                        column: x => x.BreedCollectionId,
                        principalTable: "BreedCollection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnswerType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Bool = table.Column<bool>(type: "bit", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answers_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answers_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
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
                    table.ForeignKey(
                        name: "FK_BreedBreedMix_BreedMixes_BreedMixId",
                        column: x => x.BreedMixId,
                        principalTable: "BreedMixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreedNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    BreedVarietyId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedNames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedNames_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedNames_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedNames_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
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
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedRoles_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedRoles_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedRoles_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Difficulty = table.Column<int>(type: "int", nullable: true),
                    BreedCollectionId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeds_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Breeds_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Breeds_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Breeds_BreedCollection_BreedCollectionId",
                        column: x => x.BreedCollectionId,
                        principalTable: "BreedCollection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BreedVarieties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    BreedCollectionId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedVarieties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedVarieties_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedVarieties_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedVarieties_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedVarieties_BreedCollection_BreedCollectionId",
                        column: x => x.BreedCollectionId,
                        principalTable: "BreedCollection",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BreedVarieties_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facts_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facts_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facts_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Facts_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagGroupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tags_TagGroups_TagGroupId",
                        column: x => x.TagGroupId,
                        principalTable: "TagGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Folder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attribution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    License = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    BreedMixId = table.Column<int>(type: "int", nullable: true),
                    NotableDogId = table.Column<int>(type: "int", nullable: true),
                    NotableOwnerId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageDetails_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageDetails_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                });

            migrationBuilder.CreateTable(
                name: "NotableDogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KnownFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryImageId = table.Column<int>(type: "int", nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    BreedVarietyId = table.Column<int>(type: "int", nullable: true),
                    BreedMixId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotableDogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotableDogs_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableDogs_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableDogs_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                });

            migrationBuilder.CreateTable(
                name: "NotableOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KnownFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryImageId = table.Column<int>(type: "int", nullable: true),
                    BreedCollectionId = table.Column<int>(type: "int", nullable: true),
                    BreedId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotableOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotableOwners_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableOwners_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableOwners_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotableOwners_BreedCollection_BreedCollectionId",
                        column: x => x.BreedCollectionId,
                        principalTable: "BreedCollection",
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_CreatedById",
                table: "Answers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_DeletedById",
                table: "Answers",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UpdatedById",
                table: "Answers",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BreedBreedMix_BreedMixId",
                table: "BreedBreedMix",
                column: "BreedMixId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedMixes_BreedCollectionId",
                table: "BreedMixes",
                column: "BreedCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedMixes_CreatedById",
                table: "BreedMixes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedMixes_DeletedById",
                table: "BreedMixes",
                column: "DeletedById");

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
                name: "IX_Breeds_BreedCollectionId",
                table: "Breeds",
                column: "BreedCollectionId");

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
                name: "IX_Breeds_UpdatedById",
                table: "Breeds",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BreedVarieties_BreedCollectionId",
                table: "BreedVarieties",
                column: "BreedCollectionId");

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
                name: "IX_BreedVarieties_UpdatedById",
                table: "BreedVarieties",
                column: "UpdatedById");

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
                name: "IX_NotableOwners_BreedCollectionId",
                table: "NotableOwners",
                column: "BreedCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_NotableOwners_BreedId",
                table: "NotableOwners",
                column: "BreedId");

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
                name: "IX_Questions_BreedId",
                table: "Questions",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CreatedById",
                table: "Questions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DeletedById",
                table: "Questions",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UpdatedById",
                table: "Questions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TagGroups_CreatedById",
                table: "TagGroups",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TagGroups_DeletedById",
                table: "TagGroups",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_TagGroups_UpdatedById",
                table: "TagGroups",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BreedId",
                table: "Tags",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CreatedById",
                table: "Tags",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_DeletedById",
                table: "Tags",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagGroupId",
                table: "Tags",
                column: "TagGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_UpdatedById",
                table: "Tags",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_Id",
                table: "Answers",
                column: "Id",
                principalTable: "Questions",
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
                name: "FK_BreedMixes_AspNetUsers_CreatedById",
                table: "BreedMixes");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedMixes_AspNetUsers_DeletedById",
                table: "BreedMixes");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedMixes_AspNetUsers_UpdatedById",
                table: "BreedMixes");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_AspNetUsers_CreatedById",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_AspNetUsers_DeletedById",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_AspNetUsers_UpdatedById",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedVarieties_AspNetUsers_CreatedById",
                table: "BreedVarieties");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedVarieties_AspNetUsers_DeletedById",
                table: "BreedVarieties");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedVarieties_AspNetUsers_UpdatedById",
                table: "BreedVarieties");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageDetails_AspNetUsers_CreatedById",
                table: "ImageDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageDetails_AspNetUsers_UpdatedById",
                table: "ImageDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableDogs_AspNetUsers_CreatedById",
                table: "NotableDogs");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableDogs_AspNetUsers_DeletedById",
                table: "NotableDogs");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableDogs_AspNetUsers_UpdatedById",
                table: "NotableDogs");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableOwners_AspNetUsers_CreatedById",
                table: "NotableOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableOwners_AspNetUsers_DeletedById",
                table: "NotableOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableOwners_AspNetUsers_UpdatedById",
                table: "NotableOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageDetails_BreedMixes_BreedMixId",
                table: "ImageDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableDogs_BreedMixes_BreedMixId",
                table: "NotableDogs");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedVarieties_Breeds_BreedId",
                table: "BreedVarieties");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageDetails_Breeds_BreedId",
                table: "ImageDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableDogs_Breeds_BreedId",
                table: "NotableDogs");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableOwners_Breeds_BreedId",
                table: "NotableOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedVarieties_BreedCollection_BreedCollectionId",
                table: "BreedVarieties");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableOwners_BreedCollection_BreedCollectionId",
                table: "NotableOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableDogs_BreedVarieties_BreedVarietyId",
                table: "NotableDogs");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableDogs_ImageDetails_PrimaryImageId",
                table: "NotableDogs");

            migrationBuilder.DropForeignKey(
                name: "FK_NotableOwners_ImageDetails_PrimaryImageId",
                table: "NotableOwners");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BreedBreedMix");

            migrationBuilder.DropTable(
                name: "BreedNames");

            migrationBuilder.DropTable(
                name: "BreedRoles");

            migrationBuilder.DropTable(
                name: "Facts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TagGroups");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BreedMixes");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "BreedCollection");

            migrationBuilder.DropTable(
                name: "BreedVarieties");

            migrationBuilder.DropTable(
                name: "ImageDetails");

            migrationBuilder.DropTable(
                name: "NotableDogs");

            migrationBuilder.DropTable(
                name: "NotableOwners");
        }
    }
}
