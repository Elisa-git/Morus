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
                    IdCondominio = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_LivroCaixa_Condominio_IdCondominio",
                        column: x => x.IdCondominio,
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
                    Id_condominio = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Votacao",
                columns: table => new
                {
                    IdCondominio = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tema = table.Column<string>(type: "longtext", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ativa = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Votacao_Condominio_IdCondominio",
                        column: x => x.IdCondominio,
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
                    Id_usuario = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: false),
                    data_ocorrencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Resolvido = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocorrencia_Usuario_Id_usuario",
                        column: x => x.Id_usuario,
                        principalTable: "Usuario",
                        principalColumn: "Id");
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
                    Status = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                    IdVotacao = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ValorVoto = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voto_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voto_Votacao_IdVotacao",
                        column: x => x.IdVotacao,
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
                    { "1d607355-8667-4ae1-8d87-575c322d6c30", "2", "Sindico", "SINDICO" },
                    { "23d04413-e182-4769-826b-8261004d57e1", "4", "Porteiro", "PORTEIRO" },
                    { "4b90d0ce-6825-4b93-bd4e-68d85311a415", "1", "Admin", "ADMIN" },
                    { "6d853629-a22b-4dd2-9546-8662b6d6b679", "3", "Morador", "MORADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "453ade39-dfd6-4fc8-9fc9-dcf87934b2bd", 0, "a4461a1d-4997-41bc-98ce-3e8dcb32f268", "sindicoDois@sindicoDois.com.br", false, false, null, "SINDICODOIS@SINDICODOIS.COM.BR", "SINDICODOIS@SINDICODOIS.COM.BR", "AQAAAAEAACcQAAAAEPxnAIDMn8tbQahi/xCp7KScJbA7QDUMokRTwbGEAIo3vJun/R2m74WVHrQ7ZD+5JQ==", null, false, "1f00ae81-a65f-4122-8e21-e29bf97e1ef5", false, "sindicoDois@sindicoDois.com.br" },
                    { "5cbe0b1a-b35f-4e97-af18-01058c48ddea", 0, "0d8a858d-3c7d-4906-b90c-8555141fe329", "porteiro@porteiro.com.br", false, false, null, "PORTEIRO@PORTEIRO.COM.BR", "PORTEIRO@PORTEIRO.COM.BR", "AQAAAAEAACcQAAAAEH6AK56qo42b6EykKU9ZpqChYIFEh0feE2zMlFagiDW0dEOOBG967FdZ0+Zhyyt0sw==", null, false, "e69cd080-cb8a-492a-a553-61b613430372", false, "porteiro@porteiro.com.br" },
                    { "b0b0a636-7d0e-4280-a5b9-f689e9d6a3d6", 0, "eb6bc591-656c-46d5-9ee0-6c92073714e1", "morador@morador.com.br", false, false, null, "MORADOR@MORADOR.COM.BR", "MORADOR@MORADOR.COM.BR", "AQAAAAEAACcQAAAAEA06JQUNVLmfejqOfPepHxrTKeSE0/kruoPzCAccnV5iHEsaBPFDT+Lrfe3U3F8hIw==", null, false, "a64737ce-886d-4388-ae2f-fca3396c18ec", false, "morador@morador.com.br" },
                    { "cf3bc094-512e-47cb-95ea-865b22f009e7", 0, "e5e64431-5d43-4aab-8e60-6a5c22384ec1", "sindico@sindico.com.br", false, false, null, "SINDICO@SINDICO.COM.BR", "SINDICO@SINDICO.COM.BR", "AQAAAAEAACcQAAAAEHkHyeO24SS1YRKRT5qiRkJczj36+5tVXHQ7moNV2hD4yAWDywAv6MuSCe6vMWWQag==", null, false, "848d331b-3ac9-4f47-858e-ac2ed4d58c82", false, "sindico@sindico.com.br" },
                    { "eae32922-39c4-4c50-af04-d12d5be6a5eb", 0, "79050a08-452b-42bd-a403-08e860d6fe7f", "admin@admin.com.br", false, false, null, "ADMIN@ADMIN.COM.BR", "ADMIN@ADMIN.COM.BR", "AQAAAAEAACcQAAAAEH4EgjWuPi8xfUt4EgVj1TjDGsisMEXTT5zmNm5Y8GQwa61L/ehPRIqPuOqQQqrWpg==", null, false, "79316144-450f-4e2a-8dd1-55713d42e897", false, "admin@admin.com.br" }
                });

            migrationBuilder.InsertData(
                table: "Condominio",
                columns: new[] { "Id", "Bairro", "CEP", "Cidade", "Estado", "Nome", "Numero", "Porteiro", "Rua" },
                values: new object[,]
                {
                    { 1, "Bairro Morus", "29101000", "Vila Velha", "ES", "Condominio Morus", 1, false, "Rua Morus" },
                    { 2, "Bairro", "29101001", "Vila Velha", "ES", "Condominio Dois", 2, false, "Rua Dois" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1d607355-8667-4ae1-8d87-575c322d6c30", "453ade39-dfd6-4fc8-9fc9-dcf87934b2bd" },
                    { "23d04413-e182-4769-826b-8261004d57e1", "5cbe0b1a-b35f-4e97-af18-01058c48ddea" },
                    { "6d853629-a22b-4dd2-9546-8662b6d6b679", "b0b0a636-7d0e-4280-a5b9-f689e9d6a3d6" },
                    { "1d607355-8667-4ae1-8d87-575c322d6c30", "cf3bc094-512e-47cb-95ea-865b22f009e7" },
                    { "4b90d0ce-6825-4b93-bd4e-68d85311a415", "eae32922-39c4-4c50-af04-d12d5be6a5eb" }
                });

            migrationBuilder.InsertData(
                table: "Informacao",
                columns: new[] { "Id", "Ativo", "DataAlteracao", "DataCadastro", "Descricao", "Id_condominio", "Titulo" },
                values: new object[] { 1, true, new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição de informação inicial teste, lorem ipsum", 1, "Informação inicial" });

            migrationBuilder.InsertData(
                table: "LivroCaixa",
                columns: new[] { "Id", "Categoria", "DataTransacao", "DescricaoTransacao", "IdCondominio", "NumeroConta", "Torre", "ValorTransacao" },
                values: new object[] { 1, "teste", new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição teste", 1, "123", "A", 500.00m });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apartamento", "CPF", "DataNascimento", "IdUserIdentity", "Id_condominio", "Nome", "Torre" },
                values: new object[,]
                {
                    { 1, 1, "12345678999", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cf3bc094-512e-47cb-95ea-865b22f009e7", 1, "Sindico da Costa Filho", "A" },
                    { 2, 2, "12343223444", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "b0b0a636-7d0e-4280-a5b9-f689e9d6a3d6", 1, "Morador de Carvalho", "A" },
                    { 3, 3, "12343223445", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5cbe0b1a-b35f-4e97-af18-01058c48ddea", 1, "Porteiro Fernandes", "A" },
                    { 4, 3, "12343223456", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "eae32922-39c4-4c50-af04-d12d5be6a5eb", 1, "Administrador", "A" },
                    { 5, 4, "12343223336", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "453ade39-dfd6-4fc8-9fc9-dcf87934b2bd", 2, "Sindico Dois", "A" }
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
                name: "IX_LivroCaixa_IdCondominio",
                table: "LivroCaixa",
                column: "IdCondominio");

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
                name: "IX_Votacao_IdCondominio",
                table: "Votacao",
                column: "IdCondominio");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_IdUsuario",
                table: "Voto",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Voto_IdVotacao",
                table: "Voto",
                column: "IdVotacao");
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
