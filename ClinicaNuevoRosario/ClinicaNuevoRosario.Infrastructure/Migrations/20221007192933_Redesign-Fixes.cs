using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class RedesignFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_HealthInsurances_HealthInsuranceId",
                table: "Plan");

            migrationBuilder.DropTable(
                name: "DoctorDoctorSchedule");

            migrationBuilder.AlterColumn<int>(
                name: "HealthInsuranceId",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "DoctorSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_HealthInsurances_HealthInsuranceId",
                table: "Plan",
                column: "HealthInsuranceId",
                principalTable: "HealthInsurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorId",
                table: "DoctorSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_HealthInsurances_HealthInsuranceId",
                table: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "DoctorSchedules");

            migrationBuilder.AlterColumn<int>(
                name: "HealthInsuranceId",
                table: "Plan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DoctorDoctorSchedule",
                columns: table => new
                {
                    DoctorSchedulesId = table.Column<int>(type: "int", nullable: false),
                    DoctorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDoctorSchedule", x => new { x.DoctorSchedulesId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_DoctorDoctorSchedule_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorDoctorSchedule_DoctorSchedules_DoctorSchedulesId",
                        column: x => x.DoctorSchedulesId,
                        principalTable: "DoctorSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDoctorSchedule_DoctorsId",
                table: "DoctorDoctorSchedule",
                column: "DoctorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_HealthInsurances_HealthInsuranceId",
                table: "Plan",
                column: "HealthInsuranceId",
                principalTable: "HealthInsurances",
                principalColumn: "Id");
        }
    }
}
