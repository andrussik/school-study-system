using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Gender = table.Column<char>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    IdCode = table.Column<string>(nullable: true),
                    StudentCode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Citizenship = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    SemesterId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SemesterName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.SemesterId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubjectName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IsGradable = table.Column<bool>(nullable: false),
                    ECTS = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "SubjectSemesters",
                columns: table => new
                {
                    SubjectSemesterId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubjectId = table.Column<int>(nullable: false),
                    SemesterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectSemesters", x => x.SubjectSemesterId);
                    table.ForeignKey(
                        name: "FK_SubjectSemesters_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectSemesters_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonSubjectSemesters",
                columns: table => new
                {
                    PersonSubjectSemesterId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    SubjectSemesterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSubjectSemesters", x => x.PersonSubjectSemesterId);
                    table.ForeignKey(
                        name: "FK_PersonSubjectSemesters_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSubjectSemesters_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonSubjectSemesters_SubjectSemesters_SubjectSemesterId",
                        column: x => x.SubjectSemesterId,
                        principalTable: "SubjectSemesters",
                        principalColumn: "SubjectSemesterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GradeNumber = table.Column<int>(maxLength: 5, nullable: true),
                    IsPassed = table.Column<bool>(nullable: false),
                    PersonSubjectSemesterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_PersonSubjectSemesters_PersonSubjectSemesterId",
                        column: x => x.PersonSubjectSemesterId,
                        principalTable: "PersonSubjectSemesters",
                        principalColumn: "PersonSubjectSemesterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_PersonSubjectSemesterId",
                table: "Grades",
                column: "PersonSubjectSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSubjectSemesters_PersonId",
                table: "PersonSubjectSemesters",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSubjectSemesters_RoleId",
                table: "PersonSubjectSemesters",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSubjectSemesters_SubjectSemesterId",
                table: "PersonSubjectSemesters",
                column: "SubjectSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSemesters_SemesterId",
                table: "SubjectSemesters",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSemesters_SubjectId",
                table: "SubjectSemesters",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "PersonSubjectSemesters");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SubjectSemesters");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
