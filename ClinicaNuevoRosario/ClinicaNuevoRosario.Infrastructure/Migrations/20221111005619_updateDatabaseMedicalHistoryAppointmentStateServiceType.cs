using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class updateDatabaseMedicalHistoryAppointmentStateServiceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemEmail",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentStateId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppointmentState",
                columns: table => new
                {
                    AppointmentStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentStateDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentState", x => x.AppointmentStateId);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    MedicalHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.MedicalHistoryId);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.ServiceTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentStateId",
                table: "Appointments",
                column: "AppointmentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceTypeId",
                table: "Appointments",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_PatientId",
                table: "MedicalHistory",
                column: "PatientId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentState_AppointmentStateId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ServiceType_ServiceTypeId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentState");

            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_AppointmentStateId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ServiceTypeId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "SystemEmail",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "AppointmentStateId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "Appointments");
        }
    }
}
