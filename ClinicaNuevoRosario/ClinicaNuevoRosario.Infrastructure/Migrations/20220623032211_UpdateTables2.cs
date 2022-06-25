using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class UpdateTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpecialties_MedicalSpecialtyId",
                table: "DoctorMedicalSpecialties",
                column: "MedicalSpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorMedicalSpecialties_MedicalSpecialties_MedicalSpecialtyId",
                table: "DoctorMedicalSpecialties",
                column: "MedicalSpecialtyId",
                principalTable: "MedicalSpecialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorMedicalSpecialties_MedicalSpecialties_MedicalSpecialtyId",
                table: "DoctorMedicalSpecialties");

            migrationBuilder.DropIndex(
                name: "IX_DoctorMedicalSpecialties_MedicalSpecialtyId",
                table: "DoctorMedicalSpecialties");
        }
    }
}
