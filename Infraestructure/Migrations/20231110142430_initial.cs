﻿using System;
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
                    IdCondominio = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Limite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaComum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaComum_Condominio_IdCondominio",
                        column: x => x.IdCondominio,
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
                    Documento = table.Column<byte[]>(type: "longblob", nullable: false),
                    TamanhoArquivo = table.Column<long>(type: "bigint", nullable: false),
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
                name: "Encomenda",
                columns: table => new
                {
                    IdCondominio = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Destinatario = table.Column<string>(type: "longtext", nullable: false),
                    QuemRecebeu = table.Column<string>(type: "longtext", nullable: false),
                    DataRecebimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataRecolhimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false),
                    Apartamento = table.Column<int>(type: "int", nullable: false),
                    Torre = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encomenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encomenda_Condominio_IdCondominio",
                        column: x => x.IdCondominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Informacao",
                columns: table => new
                {
                    IdCondominio = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Informacao_Condominio_IdCondominio",
                        column: x => x.IdCondominio,
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
                    ValorTransacao = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TipoTransacao = table.Column<int>(type: "int", nullable: false)
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
                    IdCondominio = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_TaxaMensal_Condominio_IdCondominio",
                        column: x => x.IdCondominio,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdCondominio = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Usuario_Condominio_IdCondominio",
                        column: x => x.IdCondominio,
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
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Ocorrencia_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
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
                    { "9e62a436-54d2-42c6-8077-9228d0ed9216", "4", "Porteiro", "PORTEIRO" },
                    { "a03e79b4-7de4-4740-b6d3-e10c98e6a1aa", "1", "Admin", "ADMIN" },
                    { "a8d9d45d-fe4a-4b3a-b579-08d50cd7496b", "3", "Morador", "MORADOR" },
                    { "b850f3a3-75c3-4085-beb1-08ce1b5b0112", "2", "Sindico", "SINDICO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0b2af8d0-93da-442f-a313-a503b00cfd0b", 0, "d0a7d497-b01e-4744-9754-b9aa20199601", "admin@admin.com.br", false, false, null, "ADMIN@ADMIN.COM.BR", "ADMIN@ADMIN.COM.BR", "AQAAAAEAACcQAAAAEL+evsv9NhbMKjYRidxMmgaHkQcDLucjyFbjOOrDpjHJWBNBSMQmDNbg3jRKTOAtDA==", null, false, "65c3908c-a533-4824-b6ab-22e4cbe9673c", false, "admin@admin.com.br" },
                    { "5776f34a-480d-4d67-a1af-72e065486c68", 0, "ff5f41c1-0721-463c-874d-ce0c32efbee7", "morador@morador.com.br", false, false, null, "MORADOR@MORADOR.COM.BR", "MORADOR@MORADOR.COM.BR", "AQAAAAEAACcQAAAAEC4NU/BTpQRb5tViDXvZsna1WAUJmx0QanZrL95Ga3nafFvmHIk/JZnpw+yWQJYszg==", null, false, "f14d0832-20d8-4a38-9c6e-60e1464da736", false, "morador@morador.com.br" },
                    { "86c43289-3130-47ed-94bb-5bde692ea531", 0, "baa972a9-2374-4732-b445-2d32f696b7bf", "sindico@sindico.com.br", false, false, null, "SINDICO@SINDICO.COM.BR", "SINDICO@SINDICO.COM.BR", "AQAAAAEAACcQAAAAEPGK9rRxz9ZVxuFwLqy8STK2cS5i20WdER4+/HaioX375VkJ6k6XS4BpLrC/2ST13g==", null, false, "bc51ada0-6283-479a-be78-f55235191f0d", false, "sindico@sindico.com.br" },
                    { "ac4a2a3c-4b13-46e9-965d-da919e114473", 0, "1c5e976e-413f-435d-9657-60250edf9a40", "porteiro@porteiro.com.br", false, false, null, "PORTEIRO@PORTEIRO.COM.BR", "PORTEIRO@PORTEIRO.COM.BR", "AQAAAAEAACcQAAAAENVxfjmb534IrMosegxKe+hQ5SnpU0Iiuvq5rI9lWtjx5HLTtxswo70/c1WFtI/Nrw==", null, false, "772520fc-d1f3-4cc1-a924-def34d067205", false, "porteiro@porteiro.com.br" },
                    { "cf862acd-d90f-4ed2-9904-f3bd1dba836b", 0, "81e16703-978d-4346-a2af-b1eac6e16328", "sindicoDois@sindicoDois.com.br", false, false, null, "SINDICODOIS@SINDICODOIS.COM.BR", "SINDICODOIS@SINDICODOIS.COM.BR", "AQAAAAEAACcQAAAAEEO6C09t6+xjPkLFiTJ7rfHhrBVY9GzH0LfxfoO8ifOpXqcSiMJ95eOYoLLop4Zb2w==", null, false, "f3a24a86-760c-4157-a1db-3ae524dda05b", false, "sindicoDois@sindicoDois.com.br" }
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
                table: "AreaComum",
                columns: new[] { "Id", "IdCondominio", "Limite", "Nome" },
                values: new object[,]
                {
                    { 1, 1, 30, "Churrasqueira" },
                    { 2, 1, 70, "Salão de Festas" },
                    { 3, 1, 15, "Quadra poliesportiva" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a03e79b4-7de4-4740-b6d3-e10c98e6a1aa", "0b2af8d0-93da-442f-a313-a503b00cfd0b" },
                    { "a8d9d45d-fe4a-4b3a-b579-08d50cd7496b", "5776f34a-480d-4d67-a1af-72e065486c68" },
                    { "b850f3a3-75c3-4085-beb1-08ce1b5b0112", "86c43289-3130-47ed-94bb-5bde692ea531" },
                    { "9e62a436-54d2-42c6-8077-9228d0ed9216", "ac4a2a3c-4b13-46e9-965d-da919e114473" },
                    { "b850f3a3-75c3-4085-beb1-08ce1b5b0112", "cf862acd-d90f-4ed2-9904-f3bd1dba836b" }
                });

            migrationBuilder.InsertData(
                table: "Informacao",
                columns: new[] { "Id", "Ativo", "DataAlteracao", "DataCadastro", "Descricao", "IdCondominio", "Titulo" },
                values: new object[] { 1, true, new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição de informação inicial teste, lorem ipsum", 1, "Informação inicial" });

            migrationBuilder.InsertData(
                table: "LivroCaixa",
                columns: new[] { "Id", "Categoria", "DataTransacao", "DescricaoTransacao", "IdCondominio", "TipoTransacao", "Torre", "ValorTransacao" },
                values: new object[] { 1, "teste", new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Descrição teste", 1, 0, "A", 500.00m });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apartamento", "CPF", "DataNascimento", "IdCondominio", "IdUserIdentity", "Nome", "Torre" },
                values: new object[,]
                {
                    { 1, 1, "12345678999", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "86c43289-3130-47ed-94bb-5bde692ea531", "Sindico da Costa Filho", "A" },
                    { 2, 2, "12343223444", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "5776f34a-480d-4d67-a1af-72e065486c68", "Morador de Carvalho", "A" },
                    { 3, 3, "12343223445", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ac4a2a3c-4b13-46e9-965d-da919e114473", "Porteiro Fernandes", "A" },
                    { 4, 3, "12343223456", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "0b2af8d0-93da-442f-a313-a503b00cfd0b", "Administrador", "A" },
                    { 5, 4, "12343223336", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "cf862acd-d90f-4ed2-9904-f3bd1dba836b", "Sindico Dois", "A" }
                });

            migrationBuilder.InsertData(
                table: "Multa",
                columns: new[] { "Id", "AplicadaEm", "DataExpiracao", "Id_usuario", "Motivo", "TaxaJurosDia", "ValorMulta" },
                values: new object[] { 1, new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Jogou ovo da janela", 1.0, 280.75m });

            migrationBuilder.CreateIndex(
                name: "IX_AreaComum_IdCondominio",
                table: "AreaComum",
                column: "IdCondominio");

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
                name: "IX_Encomenda_IdCondominio",
                table: "Encomenda",
                column: "IdCondominio");

            migrationBuilder.CreateIndex(
                name: "IX_Informacao_IdCondominio",
                table: "Informacao",
                column: "IdCondominio");

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
                name: "IX_Ocorrencia_IdUsuario",
                table: "Ocorrencia",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_Id_AreaComum",
                table: "Reserva",
                column: "Id_AreaComum");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_Id_Usuario",
                table: "Reserva",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_TaxaMensal_IdCondominio",
                table: "TaxaMensal",
                column: "IdCondominio");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdCondominio",
                table: "Usuario",
                column: "IdCondominio");

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
                name: "Encomenda");

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
