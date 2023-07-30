using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaNuevoRosario.Identity.Migrations
{
    public partial class UpdateRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6f8b16d7-b2e4-420c-8c96-3ab021b11b78", "a3ec6212-26ef-4871-b13f-7e7c8d8c5101" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "084136d8-c054-46d1-beb8-14ad1e647b2d",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "c9b114d3-ed7d-445a-b0b3-8d06cee49025", "VISITANTE" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "304ec0ad-f5dd-442f-ae18-ed26ef5feb27",
                column: "ConcurrencyStamp",
                value: "4fda269c-eba4-4063-9c27-e2f5d2baa3b9");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30a33a14-23a6-447d-ae41-fbcbb7815f61", "31453664-716d-43bc-affe-e0fdff3aba21", "Contable", "CONTABLE" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d2c01424-3245-4dff-abb4-51086fb6f897", "a3ec6212-26ef-4871-b13f-7e7c8d8c5101" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30a33a14-23a6-447d-ae41-fbcbb7815f61");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2c01424-3245-4dff-abb4-51086fb6f897", "a3ec6212-26ef-4871-b13f-7e7c8d8c5101" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "084136d8-c054-46d1-beb8-14ad1e647b2d",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "891abf22-af25-48f0-8c8c-266227256702", "Visitante" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "304ec0ad-f5dd-442f-ae18-ed26ef5feb27",
                column: "ConcurrencyStamp",
                value: "324f005a-b424-4ab3-8f08-7d90b70b9f73");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f8b16d7-b2e4-420c-8c96-3ab021b11b78",
                column: "ConcurrencyStamp",
                value: "0419a811-538d-4fdf-9177-06950a81d794");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2c01424-3245-4dff-abb4-51086fb6f897",
                column: "ConcurrencyStamp",
                value: "aebf5fd3-e46c-46c9-8777-e42ee855e560");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6f8b16d7-b2e4-420c-8c96-3ab021b11b78", "a3ec6212-26ef-4871-b13f-7e7c8d8c5101" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3600fe5c-e3f3-4e0f-9bf4-e98d32eb5e12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1c2900b-be1b-4115-9af8-0586da203e31", "AQAAAAEAACcQAAAAEELSJYlKoxZwpLFdpznhMeHQNHFn5FtS4piAKLm7zSrpe7flW4F7z9Vj0Aulz8MRsA==", "5b5077a2-3615-423c-92eb-db6acedc8315" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3ec6212-26ef-4871-b13f-7e7c8d8c5101",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc8327e2-16ce-4081-8225-a7b99357f3ed", "AQAAAAEAACcQAAAAEDVhrGoEdcFcV0Ic2WPAs79x0EA2yhSynCzhvWGe3xQ/xL8fiPMoClaKZgRhPuy1vw==", "7350269c-e50e-43ac-aaa3-2c46613fd3ae" });
        }
    }
}
