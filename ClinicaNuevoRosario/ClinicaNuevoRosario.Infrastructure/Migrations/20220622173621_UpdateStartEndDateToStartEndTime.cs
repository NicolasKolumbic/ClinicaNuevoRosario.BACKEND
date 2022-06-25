using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class UpdateStartEndDateToStartEndTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "DoctorSchedules",
                newName: "startTime");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "DoctorSchedules",
                newName: "endTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startTime",
                table: "DoctorSchedules",
                newName: "ToDate");

            migrationBuilder.RenameColumn(
                name: "endTime",
                table: "DoctorSchedules",
                newName: "FromDate");
        }
    }
}
