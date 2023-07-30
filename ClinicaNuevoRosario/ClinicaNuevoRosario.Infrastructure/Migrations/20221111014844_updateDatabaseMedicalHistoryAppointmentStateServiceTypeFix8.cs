using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Infrastructure.Migrations
{
    public partial class updateDatabaseMedicalHistoryAppointmentStateServiceTypeFix8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentState_AppointmentStateId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ServiceType_ServiceTypeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistory_Patients_PatientId",
                table: "MedicalHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceType",
                table: "ServiceType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistory",
                table: "MedicalHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentState",
                table: "AppointmentState");

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

            migrationBuilder.RenameTable(
                name: "ServiceType",
                newName: "ServiceTypes");

            migrationBuilder.RenameTable(
                name: "MedicalHistory",
                newName: "MedicalHistories");

            migrationBuilder.RenameTable(
                name: "AppointmentState",
                newName: "AppointmentStates");

            migrationBuilder.RenameColumn(
                name: "ServiceName",
                table: "ServiceTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "ServiceTypes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistory_PatientId",
                table: "MedicalHistories",
                newName: "IX_MedicalHistories_PatientId");

            migrationBuilder.RenameColumn(
                name: "AppointmentStateDescription",
                table: "AppointmentStates",
                newName: "Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceTypes",
                table: "ServiceTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistories",
                table: "MedicalHistories",
                column: "MedicalHistoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentStates",
                table: "AppointmentStates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentStates_AppointmentStateId",
                table: "Appointments",
                column: "AppointmentStateId",
                principalTable: "AppointmentStates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ServiceTypes_ServiceTypeId",
                table: "Appointments",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentStates_AppointmentStateId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ServiceTypes_ServiceTypeId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_Patients_PatientId",
                table: "MedicalHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceTypes",
                table: "ServiceTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalHistories",
                table: "MedicalHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentStates",
                table: "AppointmentStates");

            migrationBuilder.RenameTable(
                name: "ServiceTypes",
                newName: "ServiceType");

            migrationBuilder.RenameTable(
                name: "MedicalHistories",
                newName: "MedicalHistory");

            migrationBuilder.RenameTable(
                name: "AppointmentStates",
                newName: "AppointmentState");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ServiceType",
                newName: "ServiceName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ServiceType",
                newName: "ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalHistories_PatientId",
                table: "MedicalHistory",
                newName: "IX_MedicalHistory_PatientId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AppointmentState",
                newName: "AppointmentStateDescription");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceType",
                table: "ServiceType",
                column: "ServiceTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalHistory",
                table: "MedicalHistory",
                column: "MedicalHistoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentState",
                table: "AppointmentState",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentState_AppointmentStateId",
                table: "Appointments",
                column: "AppointmentStateId",
                principalTable: "AppointmentState",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ServiceType_ServiceTypeId",
                table: "Appointments",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistory_Patients_PatientId",
                table: "MedicalHistory",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
