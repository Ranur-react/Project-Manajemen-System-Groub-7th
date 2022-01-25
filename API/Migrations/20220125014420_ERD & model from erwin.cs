using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ERDmodelfromerwin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_M_Progress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgresDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProgressStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Progress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_M_Progress_Tb_M_Employees_Approver",
                        column: x => x.Approver,
                        principalTable: "Tb_M_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Projects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_DevelopTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProgres = table.Column<int>(type: "int", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Worker = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeadLine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusTask = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_DevelopTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_T_DevelopTasks_Tb_M_Employees_Worker",
                        column: x => x.Worker,
                        principalTable: "Tb_M_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_T_DevelopTasks_Tb_M_Progress_IdProgres",
                        column: x => x.IdProgres,
                        principalTable: "Tb_M_Progress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_AssignEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProject = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status_Assign = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_AssignEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_T_AssignEmployees_Tb_M_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Tb_M_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_T_AssignEmployees_Tb_M_Projects_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Tb_M_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_ProjectHistorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProject = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdProgres = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_ProjectHistorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_T_ProjectHistorys_Tb_M_Progress_IdProgres",
                        column: x => x.IdProgres,
                        principalTable: "Tb_M_Progress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_T_ProjectHistorys_Tb_M_Projects_IdProject",
                        column: x => x.IdProject,
                        principalTable: "Tb_M_Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_TestTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTask = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tester = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TestStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_TestTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_T_TestTasks_Tb_M_Employees_Tester",
                        column: x => x.Tester,
                        principalTable: "Tb_M_Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_T_TestTasks_Tb_T_DevelopTasks_IdTask",
                        column: x => x.IdTask,
                        principalTable: "Tb_T_DevelopTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_Progress_Approver",
                table: "Tb_M_Progress",
                column: "Approver");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_AssignEmployees_employeeId",
                table: "Tb_T_AssignEmployees",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_AssignEmployees_IdProject",
                table: "Tb_T_AssignEmployees",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_DevelopTasks_IdProgres",
                table: "Tb_T_DevelopTasks",
                column: "IdProgres");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_DevelopTasks_Worker",
                table: "Tb_T_DevelopTasks",
                column: "Worker");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_ProjectHistorys_IdProgres",
                table: "Tb_T_ProjectHistorys",
                column: "IdProgres");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_ProjectHistorys_IdProject",
                table: "Tb_T_ProjectHistorys",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_TestTasks_IdTask",
                table: "Tb_T_TestTasks",
                column: "IdTask");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_TestTasks_Tester",
                table: "Tb_T_TestTasks",
                column: "Tester");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_T_AssignEmployees");

            migrationBuilder.DropTable(
                name: "Tb_T_ProjectHistorys");

            migrationBuilder.DropTable(
                name: "Tb_T_TestTasks");

            migrationBuilder.DropTable(
                name: "Tb_M_Projects");

            migrationBuilder.DropTable(
                name: "Tb_T_DevelopTasks");

            migrationBuilder.DropTable(
                name: "Tb_M_Progress");
        }
    }
}
