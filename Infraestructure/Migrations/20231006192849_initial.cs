using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<string>(type: "longtext", nullable: false),
                    Cidade = table.Column<string>(type: "longtext", nullable: false),
                    Bairro = table.Column<string>(type: "longtext", nullable: false),
                    Rua = table.Column<string>(type: "longtext", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<string>(type: "longtext", nullable: false),
                    Porteiro = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagem_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AreaComum",
                columns: table => new
                {
                    Id_condominio = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Limite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaComum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaComum_Condominio_Id_condominio",
                        column: x => x.Id_condominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    Id_condominio = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Classificacao = table.Column<string>(type: "longtext", nullable: false),
                    TamanhoArquivo = table.Column<string>(type: "longtext", nullable: false),
                    DataUpload = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquivo_Condominio_Id_condominio",
                        column: x => x.Id_condominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Informacao",
                columns: table => new
                {
                    Id_condominio = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informacao_Condominio_Id_condominio",
                        column: x => x.Id_condominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LivroCaixa",
                columns: table => new
                {
                    Id_condominio = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DescricaoTransacao = table.Column<string>(type: "longtext", nullable: false),
                    Categoria = table.Column<string>(type: "longtext", nullable: false),
                    Torre = table.Column<string>(type: "longtext", nullable: false),
                    NumeroConta = table.Column<string>(type: "longtext", nullable: false),
                    ValorTransacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroCaixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivroCaixa_Condominio_Id_condominio",
                        column: x => x.Id_condominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaxaMensal",
                columns: table => new
                {
                    Id_condominio = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    Valor = table.Column<double>(type: "double", nullable: false),
                    Recorrente = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxaMensal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxaMensal_Condominio_Id_condominio",
                        column: x => x.Id_condominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_condominio = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true),
                    CPF = table.Column<string>(type: "longtext", nullable: false),
                    Torre = table.Column<string>(type: "longtext", nullable: true),
                    Apartamento = table.Column<int>(type: "int", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IdUserIdentity = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_AspNetUsers_IdUserIdentity",
                        column: x => x.IdUserIdentity,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Condominio_Id_condominio",
                        column: x => x.Id_condominio,
                        principalTable: "Condominio",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Votacao",
                columns: table => new
                {
                    Id_condominio = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tema = table.Column<string>(type: "longtext", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votacao_Condominio_Id_condominio",
                        column: x => x.Id_condominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Multa",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ValorMulta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AplicadaEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TaxaJurosDia = table.Column<double>(type: "double", nullable: false),
                    Motivo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Multa_Usuario_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ocorrencia",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    data_ocorrencia = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Usuario_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id_AreaComum = table.Column<int>(type: "int", nullable: false),
                    Id_Usuario = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DataReserva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserva_AreaComum_Id_AreaComum",
                        column: x => x.Id_AreaComum,
                        principalTable: "AreaComum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Usuario_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Voto",
                columns: table => new
                {
                    Id_votacao = table.Column<int>(type: "int", nullable: false),
                    Id_usuario = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ValorVoto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voto_Usuario_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voto_Votacao_Id_votacao",
                        column: x => x.Id_votacao,
                        principalTable: "Votacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0cbae1b7-daa8-420e-9e19-aea2bf9784b2", "4", "Porteiro", "PORTEIRO" },
                    { "80ffcf89-c78b-4c3f-80a1-5c6af4567a86", "1", "Admin", "ADMIN" },
                    { "9b9f90d6-25f8-4121-a2dd-0120e8c39a18", "3", "Morador", "MORADOR" },
                    { "b6daee1d-a9a1-4c23-9d71-d3a92fceabea", "2", "Sindico", "SINDICO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "69a5fe94-1d42-48dd-ab10-8f97a3b2140f", 0, "20482492-a783-4d71-a8ff-a272c2447bbb", "porteiro@porteiro.com.br", false, false, null, "PORTEIRO@PORTEIRO.COM.BR", "PORTEIRO@PORTEIRO.COM.BR", "AQAAAAEAACcQAAAAEI9FSXy6GsFGnxCQMT86LRP+SwXqjmX5z0opRXAHctRNdQX1ihXKgEkqMRsm40GwIA==", null, false, "73c1a8bd-d4b4-4134-83a3-97e114681207", false, "porteiro@porteiro.com.br" },
                    { "6d0ba1ee-344d-4827-ae35-f95f8df993cd", 0, "c302283f-974b-40d7-9231-4b7c72a01108", "admin@admin.com.br", false, false, null, "ADMIN@ADMIN.COM.BR", "ADMIN@ADMIN.COM.BR", "AQAAAAEAACcQAAAAEJsb6Mt9G/IPEDHzSsOlXGyGcLwdkWfCd5SpqEUDkvHnr/atIaFxP/IC1ZC1SRaKUQ==", null, false, "00cef1ef-157f-49a8-ba41-d8de94364ceb", false, "admin@admin.com.br" },
                    { "8df23972-8367-4223-891f-a2536b73a32d", 0, "6f045bbf-fddb-4e17-9c7f-b2cc16c6dc77", "sindico@sindico.com.br", false, false, null, "SINDICO@SINDICO.COM.BR", "SINDICO@SINDICO.COM.BR", "AQAAAAEAACcQAAAAEIswx0rGRNhPcKmRzpn7o0i3+oW1pIMl6cf9wd+S3WInfuFPYSrE2EwsIDTEnN/W7g==", null, false, "e7f55a8a-8ed4-4b49-805d-c3d368b61e80", false, "sindico@sindico.com.br" },
                    { "ebafef68-4f09-4fc5-834c-2b0871b770c0", 0, "4c34c2d1-b91d-461c-a855-0f3792140eb3", "morador@morador.com.br", false, false, null, "MORADOR@MORADOR.COM.BR", "MORADOR@MORADOR.COM.BR", "AQAAAAEAACcQAAAAEFCbu5TQX0ZVwT8joHu4IzzW0RwjvtYvMRUGM55ZXRwsu2SFCf42Xr00Cqpd2lgOEA==", null, false, "a7161f8a-e2ec-4d0d-a188-bfde5beeaf03", false, "morador@morador.com.br" }
                });

            migrationBuilder.InsertData(
                table: "Condominio",
                columns: new[] { "Id", "Bairro", "CEP", "Cidade", "Estado", "Nome", "Numero", "Porteiro", "Rua" },
                values: new object[] { 1, "Bairro Morus", "29101000", "Vila Velha", "ES", "Condominio Morus", 1, false, "Rua Morus" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0cbae1b7-daa8-420e-9e19-aea2bf9784b2", "69a5fe94-1d42-48dd-ab10-8f97a3b2140f" },
                    { "80ffcf89-c78b-4c3f-80a1-5c6af4567a86", "6d0ba1ee-344d-4827-ae35-f95f8df993cd" },
                    { "b6daee1d-a9a1-4c23-9d71-d3a92fceabea", "8df23972-8367-4223-891f-a2536b73a32d" },
                    { "9b9f90d6-25f8-4121-a2dd-0120e8c39a18", "ebafef68-4f09-4fc5-834c-2b0871b770c0" }
                });

            migrationBuilder.InsertData(
                table: "Informacao",
                columns: new[] { "Id", "Ativo", "DataAlteracao", "DataCadastro", "Descricao", "Id_condominio", "Titulo" },
                values: new object[] { 1, true, new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição de informação inicial teste, lorem ipsum", 1, "Informação inicial" });

            migrationBuilder.InsertData(
                table: "LivroCaixa",
                columns: new[] { "Id", "Categoria", "DataTransacao", "DescricaoTransacao", "Id_condominio", "NumeroConta", "Torre", "ValorTransacao" },
                values: new object[] { 1, "teste", new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição teste", 1, "123", "A", 500.00m });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apartamento", "CPF", "DataNascimento", "IdUserIdentity", "Id_condominio", "Nome", "Torre" },
                values: new object[,]
                {
                    { 1, 1, "12345678999", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8df23972-8367-4223-891f-a2536b73a32d", 1, "Sindico da Costa Filho", "A" },
                    { 2, 2, "12343223444", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ebafef68-4f09-4fc5-834c-2b0871b770c0", 1, "Morador de Carvalho", "A" },
                    { 3, 3, "12343223445", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69a5fe94-1d42-48dd-ab10-8f97a3b2140f", 1, "Porteiro Fernandes", "A" },
                    { 4, 3, "12343223456", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6d0ba1ee-344d-4827-ae35-f95f8df993cd", 1, "Administrador", "A" }
                });

            migrationBuilder.InsertData(
                table: "Multa",
                columns: new[] { "Id", "AplicadaEm", "DataExpiracao", "Id_usuario", "Motivo", "TaxaJurosDia", "ValorMulta" },
                values: new object[] { 1, new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Jogou ovo da janela", 1.0, 280.75m });

            migrationBuilder.CreateIndex(
                name: "IX_AreaComum_Id_condominio",
                table: "AreaComum",
                column: "Id_condominio");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivo_Id_condominio",
                table: "Arquivo",
                column: "Id_condominio");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Informacao_Id_condominio",
                table: "Informacao",
                column: "Id_condominio");

            migrationBuilder.CreateIndex(
                name: "IX_LivroCaixa_Id_condominio",
                table: "LivroCaixa",
                column: "Id_condominio");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_UserId",
                table: "Mensagem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Multa_Id_usuario",
                table: "Multa",
                column: "Id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_Id_usuario",
                table: "Ocorrencia",
                column: "Id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_Id_AreaComum",
                table: "Reserva",
                column: "Id_AreaComum");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_Id_Usuario",
                table: "Reserva",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_TaxaMensal_Id_condominio",
                table: "TaxaMensal",
                column: "Id_condominio");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Id_condominio",
                table: "Usuario",
                column: "Id_condominio");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdUserIdentity",
                table: "Usuario",
                column: "IdUserIdentity");

            migrationBuilder.CreateIndex(
                name: "IX_Votacao_Id_condominio",
                table: "Votacao",
                column: "Id_condominio");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_Id_usuario",
                table: "Voto",
                column: "Id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_Id_votacao",
                table: "Voto",
                column: "Id_votacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Informacao");

            migrationBuilder.DropTable(
                name: "LivroCaixa");

            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "Multa");

            migrationBuilder.DropTable(
                name: "Ocorrencia");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "TaxaMensal");

            migrationBuilder.DropTable(
                name: "Voto");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AreaComum");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Votacao");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Condominio");
        }
    }
}
