using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Identity.Migrations
{
    public partial class UpdateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    MedicalLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentDurationDefault = table.Column<int>(type: "int", nullable: false),
                    SystemEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<double>(type: "float", nullable: false),
                    IdentificationNumber = table.Column<double>(type: "float", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Day = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<int>(type: "int", nullable: false),
                    AppointmentDuration = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HealthInsuranceId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "c9b114d3-ed7d-445a-b0b3-8d06cee49025");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "304ec0ad-f5dd-442f-ae18-ed26ef5feb27",
                column: "ConcurrencyStamp",
                value: "4fda269c-eba4-4063-9c27-e2f5d2baa3b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30a33a14-23a6-447d-ae41-fbcbb7815f61",
                column: "ConcurrencyStamp",
                value: "31453664-716d-43bc-affe-e0fdff3aba21");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f8b16d7-b2e4-420c-8c96-3ab021b11b78",
                column: "ConcurrencyStamp",
                value: "2fba6334-ca2d-4126-b6cd-d326b3684b91");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2c01424-3245-4dff-abb4-51086fb6f897",
                column: "ConcurrencyStamp",
                value: "50ee9dd9-ac73-4388-b3f5-6b9ddcd853c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3600fe5c-e3f3-4e0f-9bf4-e98d32eb5e12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dc174c0-811b-4cbd-980d-077613b21e67", "AQAAAAEAACcQAAAAEPq2HGgBwRgukBuQPXQ9APAwrj70zmGI8w/wiIpnDTRJK7FfZqHEY9rg1n5S4ssrdA==", "79b93a7d-d788-4f5c-8bbe-11ac78c8381d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3ec6212-26ef-4871-b13f-7e7c8d8c5101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f72c248-634b-4094-97ce-a7ab123f702f", "AQAAAAEAACcQAAAAEH/ask+VFIhvd4Vzyb0JE7R+hEB0bVc6fBU/LO8daoZlEk4m91Xqs3ck0Vtky4BtUA==", "cdb11802-7a2c-4bfa-bba3-a34ef261c006" });
        }
    }
}
