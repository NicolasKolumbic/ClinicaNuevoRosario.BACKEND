using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class updateDatabaseMedicalHistoryAppointmentStateServiceTypeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentState_AppointmentStateId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ServiceType_ServiceTypeId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentStateId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentState_AppointmentStateId",
                table: "Appointments",
                column: "AppointmentStateId",
                principalTable: "AppointmentState",
                principalColumn: "AppointmentStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ServiceType_ServiceTypeId",
                table: "Appointments",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentState_AppointmentStateId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ServiceType_ServiceTypeId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceTypeId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentStateId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentState_AppointmentStateId",
                table: "Appointments",
                column: "AppointmentStateId",
                principalTable: "AppointmentState",
                principalColumn: "AppointmentStateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ServiceType_ServiceTypeId",
                table: "Appointments",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
