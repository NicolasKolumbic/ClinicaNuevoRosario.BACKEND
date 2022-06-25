using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class UpdateDoctorScheduleTableWithICollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorMedicalSpecialties_DoctorSchedules_DoctorScheduleId",
                table: "DoctorMedicalSpecialties");

            migrationBuilder.DropIndex(
                name: "IX_DoctorMedicalSpecialties_DoctorScheduleId",
                table: "DoctorMedicalSpecialties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpecialties_DoctorScheduleId",
                table: "DoctorMedicalSpecialties",
                column: "DoctorScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorMedicalSpecialties_DoctorSchedules_DoctorScheduleId",
                table: "DoctorMedicalSpecialties",
                column: "DoctorScheduleId",
                principalTable: "DoctorSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
