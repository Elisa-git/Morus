using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class nova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "858b55d1-4674-43d1-9bb8-458ff9e0b18e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9677bb4b-920b-429e-a42b-7c089114f601");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a557a33e-df00-49b5-ae48-a7d71853b1af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa14a2b2-2a54-430d-a947-56e73e5b2600");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "IdUserIdentity",
                table: "Usuario",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdUserIdentity",
                table: "Usuario",
                column: "IdUserIdentity");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_AspNetUsers_IdUserIdentity",
                table: "Usuario",
                column: "IdUserIdentity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_AspNetUsers_IdUserIdentity",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdUserIdentity",
                table: "Usuario");

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
                name: "IdUserIdentity",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "858b55d1-4674-43d1-9bb8-458ff9e0b18e", "2", "Sindico", "SINDICO" },
                    { "9677bb4b-920b-429e-a42b-7c089114f601", "3", "Morador", "MORADOR" },
                    { "a557a33e-df00-49b5-ae48-a7d71853b1af", "4", "Porteiro", "PORTEIRO" },
                    { "fa14a2b2-2a54-430d-a947-56e73e5b2600", "1", "Admin", "ADMIN" }
                });
        }
    }
}
