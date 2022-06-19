using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class AddDomainBaseToMedicalSpecialities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MedicalSpecialties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MedicalSpecialties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "MedicalSpecialties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "MedicalSpecialties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MedicalSpecialties");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MedicalSpecialties");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "MedicalSpecialties");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MedicalSpecialties");
        }
    }
}
