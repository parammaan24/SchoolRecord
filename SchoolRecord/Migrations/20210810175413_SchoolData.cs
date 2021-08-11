using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolRecord.Migrations
{
    public partial class SchoolData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Query",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Query", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schoolTeacher",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolTeacher", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schoolClass",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fees = table.Column<int>(type: "int", nullable: false),
                    teacherid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolClass", x => x.id);
                    table.ForeignKey(
                        name: "FK_schoolClass_schoolTeacher_teacherid",
                        column: x => x.teacherid,
                        principalTable: "schoolTeacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "schoolAdminssion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    school_Classid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolAdminssion", x => x.id);
                    table.ForeignKey(
                        name: "FK_schoolAdminssion_schoolClass_school_Classid",
                        column: x => x.school_Classid,
                        principalTable: "schoolClass",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_schoolAdminssion_school_Classid",
                table: "schoolAdminssion",
                column: "school_Classid");

            migrationBuilder.CreateIndex(
                name: "IX_schoolClass_teacherid",
                table: "schoolClass",
                column: "teacherid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Query");

            migrationBuilder.DropTable(
                name: "schoolAdminssion");

            migrationBuilder.DropTable(
                name: "schoolClass");

            migrationBuilder.DropTable(
                name: "schoolTeacher");
        }
    }
}
