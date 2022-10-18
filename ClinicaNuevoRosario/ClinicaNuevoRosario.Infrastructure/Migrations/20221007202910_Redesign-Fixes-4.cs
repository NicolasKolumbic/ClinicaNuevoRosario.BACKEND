using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class RedesignFixes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPlan_Plan_HealthInsurancesId",
                table: "DoctorPlan");

            migrationBuilder.RenameColumn(
                name: "HealthInsurancesId",
                table: "DoctorPlan",
                newName: "PlansId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorPlan_HealthInsurancesId",
                table: "DoctorPlan",
                newName: "IX_DoctorPlan_PlansId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPlan_Plan_PlansId",
                table: "DoctorPlan",
                column: "PlansId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPlan_Plan_PlansId",
                table: "DoctorPlan");

            migrationBuilder.RenameColumn(
                name: "PlansId",
                table: "DoctorPlan",
                newName: "HealthInsurancesId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorPlan_PlansId",
                table: "DoctorPlan",
                newName: "IX_DoctorPlan_HealthInsurancesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPlan_Plan_HealthInsurancesId",
                table: "DoctorPlan",
                column: "HealthInsurancesId",
                principalTable: "Plan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
