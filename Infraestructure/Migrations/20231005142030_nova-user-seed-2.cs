using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class novauserseed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Usuario");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42224299-f669-44c3-8228-70dcc875321c", "2", "Sindico", "SINDICO" },
                    { "59c5e6cc-a0bc-4138-a394-38ec09a7cbdd", "1", "Admin", "ADMIN" },
                    { "5ecaa12d-fb6f-4daf-bdf6-2a7124b04018", "4", "Porteiro", "PORTEIRO" },
                    { "7382557c-6724-4825-b311-16889bfb9fce", "3", "Morador", "MORADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5dea401d-2659-4be6-9b07-d6958c5e4785", 0, "7dc25ed5-0ca7-471b-93ae-cdd27e63864d", "sindico@sindico.com.br", false, false, null, "SINDICO@SINDICO.COM.BR", "SINDICO@SINDICO.COM.BR", "AQAAAAEAACcQAAAAEM/x9FkPPc8CbJ8NgxiNmZ2S8NDA9ZIHv1X3GxgnZ4umq+9GZOGFJSriJADXeLud8g==", null, false, "1bbea323-0287-4f45-833b-13e1f6ec9e87", false, "sindico@sindico.com.br" });

            migrationBuilder.InsertData(
                table: "Condominio",
                columns: new[] { "Id", "Bairro", "CEP", "Cidade", "Estado", "Nome", "Numero", "Porteiro", "Rua" },
                values: new object[] { 1, "Bairro Morus", "29101000", "Vila Velha", "ES", "Condominio Morus", 1, false, "Rua Morus" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "42224299-f669-44c3-8228-70dcc875321c", "5dea401d-2659-4be6-9b07-d6958c5e4785" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apartamento", "CPF", "DataNascimento", "IdUserIdentity", "Id_condominio", "Nome", "Torre" },
                values: new object[] { 1, 1, "12345678999", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5dea401d-2659-4be6-9b07-d6958c5e4785", 1, "Sindico da Costa Filho", "A" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59c5e6cc-a0bc-4138-a394-38ec09a7cbdd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ecaa12d-fb6f-4daf-bdf6-2a7124b04018");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7382557c-6724-4825-b311-16889bfb9fce");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "42224299-f669-44c3-8228-70dcc875321c", "5dea401d-2659-4be6-9b07-d6958c5e4785" });

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42224299-f669-44c3-8228-70dcc875321c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5dea401d-2659-4be6-9b07-d6958c5e4785");

            migrationBuilder.DeleteData(
                table: "Condominio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
