using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class updateDatabaseMedicalHistoryAppointmentStateServiceTypeFix6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "AppointmentState",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AppointmentState",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "AppointmentState",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "AppointmentState",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "AppointmentState");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AppointmentState");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "AppointmentState");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AppointmentState");
        }
    }
}
