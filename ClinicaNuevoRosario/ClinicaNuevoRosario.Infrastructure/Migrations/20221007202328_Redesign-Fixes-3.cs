using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class RedesignFixes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_HealthInsurances_HealthInsuranceId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Plan_Doctors_DoctorId",
                table: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_Plan_DoctorId",
                table: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_HealthInsuranceId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "HealthInsuranceId",
                table: "Doctors");

            migrationBuilder.CreateTable(
                name: "DoctorPlan",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(type: "int", nullable: false),
                    HealthInsurancesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPlan", x => new { x.DoctorsId, x.HealthInsurancesId });
                    table.ForeignKey(
                        name: "FK_DoctorPlan_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPlan_Plan_HealthInsurancesId",
                        column: x => x.HealthInsurancesId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPlan_HealthInsurancesId",
                table: "DoctorPlan",
                column: "HealthInsurancesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPlan");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Plan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HealthInsuranceId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plan_DoctorId",
                table: "Plan",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HealthInsuranceId",
                table: "Doctors",
                column: "HealthInsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_HealthInsurances_HealthInsuranceId",
                table: "Doctors",
                column: "HealthInsuranceId",
                principalTable: "HealthInsurances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_Doctors_DoctorId",
                table: "Plan",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
