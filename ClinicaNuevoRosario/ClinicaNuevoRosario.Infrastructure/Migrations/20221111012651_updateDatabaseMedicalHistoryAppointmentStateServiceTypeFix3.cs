using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class updateDatabaseMedicalHistoryAppointmentStateServiceTypeFix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MedicalHistory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MedicalHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "MedicalHistory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "MedicalHistory",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MedicalHistory");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MedicalHistory");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "MedicalHistory");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MedicalHistory");
        }
    }
}
