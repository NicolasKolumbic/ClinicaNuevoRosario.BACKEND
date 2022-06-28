using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class UpdateHealthInsuranceAndPatientTableAndAddPlanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plan",
                table: "HealthInsurances");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthInsuranceId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_HealthInsurances_HealthInsuranceId",
                        column: x => x.HealthInsuranceId,
                        principalTable: "HealthInsurances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PlanId",
                table: "Patients",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_HealthInsuranceId",
                table: "Plan",
                column: "HealthInsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Plan_PlanId",
                table: "Patients",
                column: "PlanId",
                principalTable: "Plan",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Plan_PlanId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PlanId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "Plan",
                table: "HealthInsurances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
