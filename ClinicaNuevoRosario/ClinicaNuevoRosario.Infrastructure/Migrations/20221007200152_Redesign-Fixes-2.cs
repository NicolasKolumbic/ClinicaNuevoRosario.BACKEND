using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class RedesignFixes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorHealthInsurance");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ClinicRoles");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ClinicRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorHealthInsurance",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(type: "int", nullable: false),
                    HealthInsurancesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorHealthInsurance", x => new { x.DoctorsId, x.HealthInsurancesId });
                    table.ForeignKey(
                        name: "FK_DoctorHealthInsurance_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorHealthInsurance_HealthInsurances_HealthInsurancesId",
                        column: x => x.HealthInsurancesId,
                        principalTable: "HealthInsurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicRoleId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationNumber = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<double>(type: "float", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_ClinicRoles_ClinicRoleId",
                        column: x => x.ClinicRoleId,
                        principalTable: "ClinicRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorHealthInsurance_HealthInsurancesId",
                table: "DoctorHealthInsurance",
                column: "HealthInsurancesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ClinicRoleId",
                table: "Employees",
                column: "ClinicRoleId");
        }
    }
}
