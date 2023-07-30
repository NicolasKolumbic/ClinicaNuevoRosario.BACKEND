using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Identity.Migrations
{
    public partial class RemoveUpdateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Doctor_DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DoctorMedicalSpecialty");

            migrationBuilder.DropTable(
                name: "DoctorPlan");

            migrationBuilder.DropTable(
                name: "DoctorSchedule");

            migrationBuilder.DropTable(
                name: "MedicalSpecialty");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "HealthInsurance");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "084136d8-c054-46d1-beb8-14ad1e647b2d",
                column: "ConcurrencyStamp",
                value: "3d1ada60-acb6-4f15-b540-552c293b24c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "304ec0ad-f5dd-442f-ae18-ed26ef5feb27",
                column: "ConcurrencyStamp",
                value: "b07ae099-8502-46ad-8f5a-26809bc9dffc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30a33a14-23a6-447d-ae41-fbcbb7815f61",
                column: "ConcurrencyStamp",
                value: "f5df1cb9-bee9-4fd7-9adc-74eebbabbf05");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f8b16d7-b2e4-420c-8c96-3ab021b11b78",
                column: "ConcurrencyStamp",
                value: "6a0cf831-b16c-43c1-9455-50406bda12ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2c01424-3245-4dff-abb4-51086fb6f897",
                column: "ConcurrencyStamp",
                value: "fe992184-85ca-4f9c-9696-f80a31e55e44");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3600fe5c-e3f3-4e0f-9bf4-e98d32eb5e12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "158e2f71-fb9e-4091-87a5-0b8271c52a78", "AQAAAAEAACcQAAAAEHYdWgkLWt8SLpZYVHFbEJVRsqQP9AGM7aFlzH1wpw1lqo6i8tbmVoSkcKhvDP223w==", "f3c97709-8a7e-4906-85aa-624cc6b7809c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3ec6212-26ef-4871-b13f-7e7c8d8c5101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7318b90-71cd-4015-a3ec-fd0f2ce1c58c", "AQAAAAEAACcQAAAAEGthmBCN9vhM1oBPnGC6xZsx7G3gLLwIv+gEX4lK1Sq1wo9ZUwwwcUZXYO3WrklbhA==", "d3c4515f-65cb-4167-a3e0-fe3e486a57a6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDurationDefault = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationNumber = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<double>(type: "float", nullable: false),
                    SystemEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthInsurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthInsurance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSpecialty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSpecialty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    AppointmentDuration = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSchedule_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthInsuranceId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_HealthInsurance_HealthInsuranceId",
                        column: x => x.HealthInsuranceId,
                        principalTable: "HealthInsurance",
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
                        name: "FK_DoctorMedicalSpecialty_Doctor_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalSpecialty_MedicalSpecialty_MedicalSpecialtiesId",
                        column: x => x.MedicalSpecialtiesId,
                        principalTable: "MedicalSpecialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorPlan",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(type: "int", nullable: false),
                    PlansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPlan", x => new { x.DoctorsId, x.PlansId });
                    table.ForeignKey(
                        name: "FK_DoctorPlan_Doctor_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPlan_Plan_PlansId",
                        column: x => x.PlansId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "084136d8-c054-46d1-beb8-14ad1e647b2d",
                column: "ConcurrencyStamp",
                value: "002d281c-0edb-4c5d-878f-9228843899e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "304ec0ad-f5dd-442f-ae18-ed26ef5feb27",
                column: "ConcurrencyStamp",
                value: "5d94e334-dfde-4e35-9d33-45ccbc1c8b14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30a33a14-23a6-447d-ae41-fbcbb7815f61",
                column: "ConcurrencyStamp",
                value: "17016ffc-c20d-4aa2-a9a4-c82cd9d2192f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f8b16d7-b2e4-420c-8c96-3ab021b11b78",
                column: "ConcurrencyStamp",
                value: "d13c6c62-f210-4494-add3-c8ef1686a8c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2c01424-3245-4dff-abb4-51086fb6f897",
                column: "ConcurrencyStamp",
                value: "1ce00de6-f1d5-4623-a82e-808e6d14cf06");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3600fe5c-e3f3-4e0f-9bf4-e98d32eb5e12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69b8cb48-6495-41af-8e34-eeead0ba0baf", "AQAAAAEAACcQAAAAEB9EyPLje2SXNrnGHQiPlity7Ool8ZvaAI4KXGLiTnkbhosA4zZ68JZDo2OK0RZ+ow==", "e306e601-f9db-4844-a3a7-c833aa386efc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3ec6212-26ef-4871-b13f-7e7c8d8c5101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0e779d7-068a-416a-9f10-f3bef11e6489", "AQAAAAEAACcQAAAAEGQz3PVs9iU57lI+52u/4DdvtMt2hlDIom+gScvg043rpEEWKmoenBQ/PA6utT36oA==", "8115df37-e5a3-4ff9-8960-4f274761bf82" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DoctorId",
                table: "AspNetUsers",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalSpecialty_MedicalSpecialtiesId",
                table: "DoctorMedicalSpecialty",
                column: "MedicalSpecialtiesId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPlan_PlansId",
                table: "DoctorPlan",
                column: "PlansId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedule_DoctorId",
                table: "DoctorSchedule",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_HealthInsuranceId",
                table: "Plan",
                column: "HealthInsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Doctor_DoctorId",
                table: "AspNetUsers",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id");
        }
    }
}
