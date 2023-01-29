using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiktivSkolaEF.Migrations
{
    public partial class Changedstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateGrade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    GradeDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateGrade", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StaffPosition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    StaffPosition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPosition", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PersonalNumber = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Class = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PositionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Staff_StaffPosition",
                        column: x => x.PositionID,
                        principalTable: "StaffPosition",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ConnectionTable",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    GradeID = table.Column<int>(type: "int", nullable: false),
                    StaffPositionID = table.Column<int>(type: "int", nullable: false),
                    DateGradeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionTable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ConnectionTable_DateGrade",
                        column: x => x.DateGradeID,
                        principalTable: "DateGrade",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConnectionTable_Grades",
                        column: x => x.GradeID,
                        principalTable: "Grades",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConnectionTable_Staff",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConnectionTable_StaffPosition",
                        column: x => x.StaffPositionID,
                        principalTable: "StaffPosition",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ConnectionTable_Student",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionTable_DateGradeID",
                table: "ConnectionTable",
                column: "DateGradeID");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionTable_GradeID",
                table: "ConnectionTable",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionTable_StaffID",
                table: "ConnectionTable",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionTable_StaffPositionID",
                table: "ConnectionTable",
                column: "StaffPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionTable_StudentID",
                table: "ConnectionTable",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_PositionID",
                table: "Staff",
                column: "PositionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectionTable");

            migrationBuilder.DropTable(
                name: "DateGrade");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "StaffPosition");
        }
    }
}
