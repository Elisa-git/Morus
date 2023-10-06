using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class novauserseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06d3cbe4-c661-4db1-a3f4-430bb32dfcd1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "209cc869-2fc0-4e6b-a778-ee9a4577ef40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4154742a-cb22-4a5c-ad8d-3e4ae7e050f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84cbac89-0364-450c-9aba-755ea9c48061");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "90eb31df-2b2e-4ad5-99c9-0e8c78835dc0", "2", "Sindico", "SINDICO" },
                    { "a7bbfd60-4cf7-4968-b4df-a91800b5b8e8", "1", "Admin", "ADMIN" },
                    { "f91d0f6c-186c-4f3b-a296-c03ad13c09fe", "4", "Porteiro", "PORTEIRO" },
                    { "ff19d994-0d4c-412f-97ac-bab6b32748cb", "3", "Morador", "MORADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "89d3823c-b10d-48ff-a8af-e928699e1984", 0, "9064bc22-c846-4c73-a400-d2f3d764a993", "sindico@sindico.com.br", false, false, null, "SINDICO@SINDICO.COM.BR", "SINDICO@SINDICO.COM.BR", "AQAAAAEAACcQAAAAELanisi0aMEE1MOfTPPodPgVHo7v3y0mwGp8HffOD/Of4Wm88NIWx15AAXgCu4ePZg==", null, false, "40401e87-405b-42d6-9827-471da3fddc2f", false, "sindico@sindico.com.br" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "90eb31df-2b2e-4ad5-99c9-0e8c78835dc0", "89d3823c-b10d-48ff-a8af-e928699e1984" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7bbfd60-4cf7-4968-b4df-a91800b5b8e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f91d0f6c-186c-4f3b-a296-c03ad13c09fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff19d994-0d4c-412f-97ac-bab6b32748cb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "90eb31df-2b2e-4ad5-99c9-0e8c78835dc0", "89d3823c-b10d-48ff-a8af-e928699e1984" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90eb31df-2b2e-4ad5-99c9-0e8c78835dc0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89d3823c-b10d-48ff-a8af-e928699e1984");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06d3cbe4-c661-4db1-a3f4-430bb32dfcd1", "3", "Morador", "MORADOR" },
                    { "209cc869-2fc0-4e6b-a778-ee9a4577ef40", "4", "Porteiro", "PORTEIRO" },
                    { "4154742a-cb22-4a5c-ad8d-3e4ae7e050f3", "2", "Sindico", "SINDICO" },
                    { "84cbac89-0364-450c-9aba-755ea9c48061", "1", "Admin", "ADMIN" }
                });
        }
    }
}
