using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_HealthInsurances_HealthInsuranceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSchedules_Doctors_doctorId",
                table: "DoctorSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalSpecialties_Doctors_DoctorId",
                table: "MedicalSpecialties");

            migrationBuilder.DropIndex(
                name: "IX_MedicalSpecialties_DoctorId",
                table: "MedicalSpecialties");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "MedicalSpecialties");

            migrationBuilder.DropColumn(
                name: "MedicalSpecialtyId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "HealthInsurranceId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "toDate",
                table: "DoctorSchedules",
                newName: "ToDate");

            migrationBuilder.RenameColumn(
                name: "fromDate",
                table: "DoctorSchedules",
                newName: "FromDate");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "DoctorSchedules",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorSchedules_doctorId",
                table: "DoctorSchedules",
                newName: "IX_DoctorSchedules_DoctorId");

            migrationBuilder.AlterColumn<int>(
                name: "HealthInsuranceId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_HealthInsurances_HealthInsuranceId",
                table: "Appointments",
                column: "HealthInsuranceId",
                principalTable: "HealthInsurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_HealthInsurances_HealthInsuranceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorId",
                table: "DoctorSchedules");

            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "DoctorSchedules",
                newName: "toDate");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "DoctorSchedules",
                newName: "fromDate");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "DoctorSchedules",
                newName: "doctorId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedules",
                newName: "IX_DoctorSchedules_doctorId");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "MedicalSpecialties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalSpecialtyId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "HealthInsuranceId",
                table: "Appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HealthInsurranceId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSpecialties_DoctorId",
                table: "MedicalSpecialties",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_HealthInsurances_HealthInsuranceId",
                table: "Appointments",
                column: "HealthInsuranceId",
                principalTable: "HealthInsurances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSchedules_Doctors_doctorId",
                table: "DoctorSchedules",
                column: "doctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalSpecialties_Doctors_DoctorId",
                table: "MedicalSpecialties",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
