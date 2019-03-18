using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ResumeProject.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Conference",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventType = table.Column<string>(nullable: true),
                    PersonID = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conference", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Conference_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Degree = table.Column<string>(nullable: true),
                    GraduationDate = table.Column<DateTime>(nullable: false),
                    PersonID = table.Column<int>(nullable: false),
                    School = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Education_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrentlyStillWorking = table.Column<bool>(nullable: false),
                    ExperienceType = table.Column<string>(nullable: true),
                    Organization = table.Column<string>(nullable: true),
                    PersonID = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    YearsService = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Experience_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonalSkill",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonID = table.Column<int>(nullable: false),
                    Skill = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalSkill", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonalSkill_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Description",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Duties = table.Column<string>(nullable: true),
                    ExperienceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Description_Experience_ExperienceID",
                        column: x => x.ExperienceID,
                        principalTable: "Experience",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conference_PersonID",
                table: "Conference",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Description_ExperienceID",
                table: "Description",
                column: "ExperienceID");

            migrationBuilder.CreateIndex(
                name: "IX_Education_PersonID",
                table: "Education",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_PersonID",
                table: "Experience",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalSkill_PersonID",
                table: "PersonalSkill",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conference");

            migrationBuilder.DropTable(
                name: "Description");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "PersonalSkill");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
