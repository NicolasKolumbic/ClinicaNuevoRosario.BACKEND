using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class UpdateDoctorScheduleTableCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startTime",
                table: "DoctorSchedules",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "endTime",
                table: "DoctorSchedules",
                newName: "EndTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "DoctorSchedules",
                newName: "startTime");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "DoctorSchedules",
                newName: "endTime");
        }
    }
}
