using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityApplication.Data.Migrations
{
    public partial class test38 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    SigningDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    TotalGoals = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clubs",
                columns: new[] { "Id", "City", "Country", "Name", "Owner" },
                values: new object[,]
                {
                    { 1, "Skopje", "Macedonia", "Vardar", "Marko" },
                    { 2, "Manchester City", "United Kingdom", "Manchester", "Dino" },
                    { 3, "Skopje", "Macedonia", "House Of Grappling Arts", "David" },
                    { 4, "Munich", "Germany", "Bayern", "Ne znam" },
                    { 5, "Belgrade", "Serbia", "Partizan", "Ante" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ClubId", "DOB", "FirstName", "LastName", "Rank", "SigningDate", "TotalGoals" },
                values: new object[,]
                {
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hristijan", "Hristovski", 2, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), 14 },
                    { 4, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marko", "Markovski", 3, new DateTime(2012, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), 8 },
                    { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marko", "Kolekjeski", 1, new DateTime(2017, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), 976124 },
                    { 2, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petar", "Petkovski", 5, new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 5, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simo", "Hayha", 4, new DateTime(2017, 5, 10, 0, 0, 0, 0, DateTimeKind.Local), 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_ClubId",
                table: "Players",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
