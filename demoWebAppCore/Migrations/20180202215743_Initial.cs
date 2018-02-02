using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace demoWebAppCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    PKExam = table.Column<int>(nullable: false),
                    ExDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Subject = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.PKExam);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    PKStudent = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.PKStudent);
                });

            migrationBuilder.CreateTable(
                name: "StudentsExams",
                columns: table => new
                {
                    PPKFKStudent = table.Column<int>(nullable: false),
                    PPKFKExam = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsExams", x => new { x.PPKFKStudent, x.PPKFKExam });
                    table.ForeignKey(
                        name: "FK__StudentsE__PPKFK__286302EC",
                        column: x => x.PPKFKExam,
                        principalTable: "Exams",
                        principalColumn: "PKExam",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__StudentsE__PPKFK__276EDEB3",
                        column: x => x.PPKFKStudent,
                        principalTable: "Students",
                        principalColumn: "PKStudent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsExams_PPKFKExam",
                table: "StudentsExams",
                column: "PPKFKExam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsExams");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
