using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class newrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_AssignEmployees_Tb_M_Employees_employeeId",
                table: "Tb_T_AssignEmployees");

            migrationBuilder.DropIndex(
                name: "IX_Tb_T_AssignEmployees_employeeId",
                table: "Tb_T_AssignEmployees");

            migrationBuilder.DropColumn(
                name: "employeeId",
                table: "Tb_T_AssignEmployees");

            migrationBuilder.AlterColumn<string>(
                name: "IdEmployee",
                table: "Tb_T_AssignEmployees",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_AssignEmployees_IdEmployee",
                table: "Tb_T_AssignEmployees",
                column: "IdEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_AssignEmployees_Tb_M_Employees_IdEmployee",
                table: "Tb_T_AssignEmployees",
                column: "IdEmployee",
                principalTable: "Tb_M_Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_T_AssignEmployees_Tb_M_Employees_IdEmployee",
                table: "Tb_T_AssignEmployees");

            migrationBuilder.DropIndex(
                name: "IX_Tb_T_AssignEmployees_IdEmployee",
                table: "Tb_T_AssignEmployees");

            migrationBuilder.AlterColumn<string>(
                name: "IdEmployee",
                table: "Tb_T_AssignEmployees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "employeeId",
                table: "Tb_T_AssignEmployees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_AssignEmployees_employeeId",
                table: "Tb_T_AssignEmployees",
                column: "employeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_T_AssignEmployees_Tb_M_Employees_employeeId",
                table: "Tb_T_AssignEmployees",
                column: "employeeId",
                principalTable: "Tb_M_Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
