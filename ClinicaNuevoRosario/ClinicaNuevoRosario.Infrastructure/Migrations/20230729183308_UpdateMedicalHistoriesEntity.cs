using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class UpdateMedicalHistoriesEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories");

            migrationBuilder.AddColumn<int>(
                name: "HealthInsurranceNumber",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "MedicalHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "MedicalHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistories_DoctorId",
                table: "MedicalHistories",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Doctors_DoctorId",
                table: "MedicalHistories",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Doctors_DoctorId",
                table: "MedicalHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories");

            migrationBuilder.DropIndex(
                name: "IX_MedicalHistories_DoctorId",
                table: "MedicalHistories");

            migrationBuilder.DropColumn(
                name: "HealthInsurranceNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "MedicalHistories");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "MedicalHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
