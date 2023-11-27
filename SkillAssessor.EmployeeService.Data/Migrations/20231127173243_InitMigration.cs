using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillAssessor.EmployeeService.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    EmploymentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    InterviewRequestId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillTitle = table.Column<string>(type: "text", nullable: false),
                    LevelNumber = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillLevels_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InterviewRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SkillLevelId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InterviewRequests_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterviewRequests_SkillLevels_SkillLevelId",
                        column: x => x.SkillLevelId,
                        principalTable: "SkillLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_InterviewRequestId",
                table: "Employees",
                column: "InterviewRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRequests_EmployeeId",
                table: "InterviewRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRequests_EmployeeId1",
                table: "InterviewRequests",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRequests_SkillLevelId",
                table: "InterviewRequests",
                column: "SkillLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillLevels_EmployeeId",
                table: "SkillLevels",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_InterviewRequests_InterviewRequestId",
                table: "Employees",
                column: "InterviewRequestId",
                principalTable: "InterviewRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_InterviewRequests_InterviewRequestId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "InterviewRequests");

            migrationBuilder.DropTable(
                name: "SkillLevels");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
