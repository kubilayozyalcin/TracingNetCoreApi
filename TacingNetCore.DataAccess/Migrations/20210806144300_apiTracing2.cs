using Microsoft.EntityFrameworkCore.Migrations;

namespace TacingNetCore.DataAccess.Migrations
{
    public partial class apiTracing2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceType_DeviceTypeId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Regions_RegionId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDevices_Devices_DeviceId",
                table: "EmployeeDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDevices_Employees_EmployeeId",
                table: "EmployeeDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RoleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDevices_DeviceId",
                table: "EmployeeDevices");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDevices_EmployeeId",
                table: "EmployeeDevices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_DeviceTypeId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_RegionId",
                table: "Devices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDevices_DeviceId",
                table: "EmployeeDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDevices_EmployeeId",
                table: "EmployeeDevices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_RegionId",
                table: "Devices",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceType_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId",
                principalTable: "DeviceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Regions_RegionId",
                table: "Devices",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDevices_Devices_DeviceId",
                table: "EmployeeDevices",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDevices_Employees_EmployeeId",
                table: "EmployeeDevices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
