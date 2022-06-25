using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class UpdateDoctorScheduleTableAndDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorScheduleId",
                table: "DoctorMedicalSpecialties");

            migrationBuilder.AddColumn<int>(
                name: "DoctorScheduleId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorScheduleId",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "DoctorScheduleId",
                table: "DoctorMedicalSpecialties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
