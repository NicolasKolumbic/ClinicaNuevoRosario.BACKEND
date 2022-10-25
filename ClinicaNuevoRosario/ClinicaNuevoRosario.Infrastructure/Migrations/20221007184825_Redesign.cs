using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class Redesign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorId",
                table: "DoctorSchedules");

            migrationBuilder.DropTable(
                name: "DoctorMedicalSpecialties");

            migrationBuilder.DropIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "DoctorSchedules");

            migrationBuilder.CreateTable(
                name: "DoctorDoctorSchedule",
                columns: table => new
                {
                    DoctorSchedulesId = table.Column<int>(type: "int", nullable: false),
                    DoctorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDoctorSchedule", x => new { x.DoctorSchedulesId, x.DoctorsId });
                    table.ForeignKey(
                        name: "FK_DoctorDoctorSchedule_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorDoctorSchedule_DoctorSchedules_DoctorSchedulesId",
                        column: x => x.DoctorSchedulesId,
                        principalTable: "DoctorSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "DoctorMedicalSpecialty",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(type: "int", nullable: false),
                    MedicalSpecialtiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalSpecialty", x => new { x.DoctorsId, x.MedicalSpecialtiesId });
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpecialty_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpecialty_MedicalSpecialties_MedicalSpecialtiesId",
                        column: x => x.MedicalSpecialtiesId,
                        principalTable: "MedicalSpecialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorDoctorSchedule_DoctorsId",
                table: "DoctorDoctorSchedule",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorHealthInsurance_HealthInsurancesId",
                table: "DoctorHealthInsurance",
                column: "HealthInsurancesId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpecialty_MedicalSpecialtiesId",
                table: "DoctorMedicalSpecialty",
                column: "MedicalSpecialtiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorDoctorSchedule");

            migrationBuilder.DropTable(
                name: "DoctorHealthInsurance");

            migrationBuilder.DropTable(
                name: "DoctorMedicalSpecialty");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "DoctorSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DoctorMedicalSpecialties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalSpecialtyId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalSpecialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpecialties_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpecialties_MedicalSpecialties_MedicalSpecialtyId",
                        column: x => x.MedicalSpecialtyId,
                        principalTable: "MedicalSpecialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpecialties_DoctorId",
                table: "DoctorMedicalSpecialties",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpecialties_MedicalSpecialtyId",
                table: "DoctorMedicalSpecialties",
                column: "MedicalSpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSchedules_Doctors_DoctorId",
                table: "DoctorSchedules",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
