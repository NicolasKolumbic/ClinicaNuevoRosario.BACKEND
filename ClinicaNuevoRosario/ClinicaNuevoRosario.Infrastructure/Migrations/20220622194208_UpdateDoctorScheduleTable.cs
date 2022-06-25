using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class UpdateDoctorScheduleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "startTime",
                table: "DoctorSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "endTime",
                table: "DoctorSchedules",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "DoctorSchedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DoctorSchedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "DoctorSchedules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DoctorSchedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "DoctorMedicalSpecialties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DoctorMedicalSpecialties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorScheduleId",
                table: "DoctorMedicalSpecialties",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "DoctorMedicalSpecialties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DoctorMedicalSpecialties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpecialties_DoctorScheduleId",
                table: "DoctorMedicalSpecialties",
                column: "DoctorScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorMedicalSpecialties_DoctorSchedules_DoctorScheduleId",
                table: "DoctorMedicalSpecialties",
                column: "DoctorScheduleId",
                principalTable: "DoctorSchedules",
                principalColumn: "Id" );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorMedicalSpecialties_DoctorSchedules_DoctorScheduleId",
                table: "DoctorMedicalSpecialties");

            migrationBuilder.DropIndex(
                name: "IX_DoctorMedicalSpecialties_DoctorScheduleId",
                table: "DoctorMedicalSpecialties");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DoctorSchedules");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "DoctorMedicalSpecialties");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DoctorMedicalSpecialties");

            migrationBuilder.DropColumn(
                name: "DoctorScheduleId",
                table: "DoctorMedicalSpecialties");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "DoctorMedicalSpecialties");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DoctorMedicalSpecialties");

            migrationBuilder.AlterColumn<string>(
                name: "startTime",
                table: "DoctorSchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "endTime",
                table: "DoctorSchedules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
