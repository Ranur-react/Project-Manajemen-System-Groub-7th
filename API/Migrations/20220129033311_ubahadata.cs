using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ubahadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_Accounts_Tb_M_Roles_RoleId",
                table: "Tb_M_Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Tb_M_Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_Accounts_Tb_M_Roles_RoleId",
                table: "Tb_M_Accounts",
                column: "RoleId",
                principalTable: "Tb_M_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_Accounts_Tb_M_Roles_RoleId",
                table: "Tb_M_Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Tb_M_Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_Accounts_Tb_M_Roles_RoleId",
                table: "Tb_M_Accounts",
                column: "RoleId",
                principalTable: "Tb_M_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
