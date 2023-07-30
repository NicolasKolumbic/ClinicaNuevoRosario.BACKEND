using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class UpdateMedicalHistoriesEntityFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalHistoryId",
                table: "Patients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicalHistoryId",
                table: "Patients",
                type: "int",
                nullable: true);
        }
    }
}
