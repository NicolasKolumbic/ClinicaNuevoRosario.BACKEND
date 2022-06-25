﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class UpdateDoctorScheduleTableCollection5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpecialties_DoctorScheduleId",
                table: "DoctorMedicalSpecialties",
                column: "DoctorScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorMedicalSpecialties_DoctorSchedules_DoctorScheduleId",
                table: "DoctorMedicalSpecialties",
                column: "DoctorScheduleId",
                principalTable: "DoctorSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorMedicalSpecialties_DoctorSchedules_DoctorScheduleId",
                table: "DoctorMedicalSpecialties");

            migrationBuilder.DropIndex(
                name: "IX_DoctorMedicalSpecialties_DoctorScheduleId",
                table: "DoctorMedicalSpecialties");
        }
    }
}
