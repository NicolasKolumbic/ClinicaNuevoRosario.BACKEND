using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class domainmodelupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_HealthInsurances_HealthInsuranceId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_HealthInsurances_HealthInsuranceId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_HealthInsuranceId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_HealthInsuranceId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "HealthInsuranceId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "HealthInsuranceId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Appointments");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Plan",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Plan");

            migrationBuilder.AddColumn<int>(
                name: "HealthInsuranceId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HealthInsuranceId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HealthInsuranceId",
                table: "Patients",
                column: "HealthInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_HealthInsuranceId",
                table: "Appointments",
                column: "HealthInsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_HealthInsurances_HealthInsuranceId",
                table: "Appointments",
                column: "HealthInsuranceId",
                principalTable: "HealthInsurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_HealthInsurances_HealthInsuranceId",
                table: "Patients",
                column: "HealthInsuranceId",
                principalTable: "HealthInsurances",
                principalColumn: "Id");
        }
    }
}
