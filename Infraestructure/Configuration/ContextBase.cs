using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infraestructure.Configuration
{
    public class ContextBase : IdentityDbContext<User>
    {
        public ContextBase(DbContextOptions<ContextBase> opt) : base(opt)
        {
        }

        public DbSet<Message> Message { get; set; }
        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<AreaComum> AreaComum { get; set; }
        public DbSet<Arquivo> Arquivo { get; set; }
        public DbSet<Informacao> Informacao { get; set; }
        public DbSet<LivroCaixa> LivroCaixa { get; set; }
        public DbSet<TaxaMensal> TaxaMensal { get; set; }
        public DbSet<Votacao> Votacao { get; set; }
        public DbSet<Voto> Voto { get; set; }
        public DbSet<Multa> Multa { get; set; }
        public DbSet<Ocorrencia> Ocorrencia { get; set; }
        public DbSet<Reserva> Reserva { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
            SeedDatabaseInicial(builder);
            SeedIdentityUserAndRoles(builder);
            SeedMulta(builder);
        }

        private void SeedDatabaseInicial(ModelBuilder builder)
        {
            builder.Entity<Condominio>().HasData
                (
                    new Condominio { Id = 1, Bairro = "Bairro Morus", CEP = "29101000", Cidade = "Vila Velha", Estado = "ES", Nome = "Condominio Morus", Numero = 1, Porteiro = false, Rua = "Rua Morus" },
                    new Condominio { Id = 2, Bairro = "Bairro", CEP = "29101001", Cidade = "Vila Velha", Estado = "ES", Nome = "Condominio Dois", Numero = 2, Porteiro = false, Rua = "Rua Dois" }
                );

            builder.Entity<LivroCaixa>().HasData
                (
                    new LivroCaixa { Id = 1, Categoria = "teste", IdCondominio = 1, Torre = "A", ValorTransacao = 500.00m, TipoTransacao = Domain.Entities.Enum.TipoTransacao.ENTRADA, DataTransacao = new DateTime(2023, 10, 06), DescricaoTransacao = "Descrição teste" }
                );

            builder.Entity<Informacao>().HasData
                (
                    new Informacao { Id = 1, Ativo = true, IdCondominio = 1, DataCadastro = new DateTime(2023,10,06), DataAlteracao = new DateTime(2023, 10, 06), Descricao = "Descrição de informação inicial teste, lorem ipsum", Titulo = "Informação inicial" }
                );

            builder.Entity<AreaComum>().HasData
                (
                    new AreaComum { Id = 1, Id_condominio = 1, Limite = 30, Nome = "Churrasqueira" },
                    new AreaComum { Id = 2, Id_condominio = 1, Limite = 70, Nome = "Salão de Festas" },
                    new AreaComum { Id = 3, Id_condominio = 1, Limite = 15, Nome = "Quadra poliesportiva" }
                );
        }

        private void SeedMulta(ModelBuilder builder)
        {
            builder.Entity<Multa>().HasData
                (
                    new Multa { Id = 1, AplicadaEm = new DateTime(2023, 10, 06), DataExpiracao = new DateTime(2023, 11, 06), Id_usuario = 2, Motivo = "Jogou ovo da janela", TaxaJurosDia = 1, ValorMulta = 280.75m }
                );
        }


        private void SeedIdentityUserAndRoles(ModelBuilder builder)
        {
            string sindicoRoleId = Guid.NewGuid().ToString();
            string adminRoleId = Guid.NewGuid().ToString();
            string moradorRoleId = Guid.NewGuid().ToString();
            string porteiroRoleId = Guid.NewGuid().ToString();

            string emailSindico = "sindico@sindico.com.br";
            string emailAdmin = "admin@admin.com.br";
            string emailPorteiro = "porteiro@porteiro.com.br";
            string emailMorador = "morador@morador.com.br";
            string senhaPadrao = "Morus@2023";

            string emailSindicoDois = "sindicoDois@sindicoDois.com.br";

            string sindicoUserId = Guid.NewGuid().ToString();
            string sindicoDoisUserId = Guid.NewGuid().ToString();
            string adminUserId = Guid.NewGuid().ToString();
            string moradorUserId = Guid.NewGuid().ToString();
            string porteiroUserId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole() { Id = adminRoleId, Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                    new IdentityRole() { Id = sindicoRoleId, Name = "Sindico", ConcurrencyStamp = "2", NormalizedName = "SINDICO" },
                    new IdentityRole() { Id = moradorRoleId, Name = "Morador", ConcurrencyStamp = "3", NormalizedName = "MORADOR" },
                    new IdentityRole() { Id = porteiroRoleId, Name = "Porteiro", ConcurrencyStamp = "4", NormalizedName = "PORTEIRO" }
                );

            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData
                (
                    new User
                    {
                        Email = emailSindico,
                        UserName = emailSindico,
                        NormalizedEmail = emailSindico.ToUpperInvariant(),
                        NormalizedUserName = emailSindico.ToUpperInvariant(),
                        Id = sindicoUserId,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = hasher.HashPassword(null, senhaPadrao)
                    },
                    new User
                    {
                        Email = emailSindicoDois,
                        UserName = emailSindicoDois,
                        NormalizedEmail = emailSindicoDois.ToUpperInvariant(),
                        NormalizedUserName = emailSindicoDois.ToUpperInvariant(),
                        Id = sindicoDoisUserId,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = hasher.HashPassword(null, senhaPadrao)
                    },
                    new User
                    {
                        Email = emailMorador,
                        UserName = emailMorador,
                        NormalizedEmail = emailMorador.ToUpperInvariant(),
                        NormalizedUserName = emailMorador.ToUpperInvariant(),
                        Id = moradorUserId,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = hasher.HashPassword(null, senhaPadrao)
                    },
                    new User
                    {
                        Email = emailAdmin,
                        UserName = emailAdmin,
                        NormalizedEmail = emailAdmin.ToUpperInvariant(),
                        NormalizedUserName = emailAdmin.ToUpperInvariant(),
                        Id = adminUserId,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = hasher.HashPassword(null, senhaPadrao)
                    },
                    new User
                    {
                        Email = emailPorteiro,
                        UserName = emailPorteiro,
                        NormalizedEmail = emailPorteiro.ToUpperInvariant(),
                        NormalizedUserName = emailPorteiro.ToUpperInvariant(),
                        Id = porteiroUserId,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = hasher.HashPassword(null, senhaPadrao)
                    }
            );

            builder.Entity<IdentityUserRole<string>>().HasData
                (
                    new IdentityUserRole<string>
                    {
                        RoleId = sindicoRoleId,
                        UserId = sindicoUserId
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = sindicoRoleId,
                        UserId = sindicoDoisUserId
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = adminRoleId,
                        UserId = adminUserId
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = moradorRoleId,
                        UserId = moradorUserId
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = porteiroRoleId,
                        UserId = porteiroUserId
                    }
                );

            builder.Entity<Usuario>().HasData
                (
                    new Usuario
                    {
                        Id = 1,
                        IdCondominio = 1,
                        IdUserIdentity = sindicoUserId,
                        Nome = "Sindico da Costa Filho",
                        Torre = "A",
                        DataNascimento = new DateTime(1990, 1, 1),
                        Apartamento = 1,
                        CPF = "12345678999"
                    },
                    new Usuario
                    {
                        Id = 2,
                        IdCondominio = 1,
                        IdUserIdentity = moradorUserId,
                        Nome = "Morador de Carvalho",
                        Torre = "A",
                        DataNascimento = new DateTime(1990, 1, 1),
                        Apartamento = 2,
                        CPF = "12343223444"
                    },
                    new Usuario
                    {
                        Id = 3,
                        IdCondominio = 1,
                        IdUserIdentity = porteiroUserId,
                        Nome = "Porteiro Fernandes",
                        Torre = "A",
                        DataNascimento = new DateTime(1990, 1, 1),
                        Apartamento = 3,
                        CPF = "12343223445"
                    },
                    new Usuario
                    {
                        Id = 4,
                        IdCondominio = 1,
                        IdUserIdentity = adminUserId,
                        Nome = "Administrador",
                        Torre = "A",
                        DataNascimento = new DateTime(1990, 1, 1),
                        Apartamento = 3,
                        CPF = "12343223456"
                    },
                    new Usuario
                    {
                        Id = 5,
                        IdCondominio = 2,
                        IdUserIdentity = sindicoDoisUserId,
                        Nome = "Sindico Dois",
                        Torre = "A",
                        DataNascimento = new DateTime(1990, 1, 1),
                        Apartamento = 4,
                        CPF = "12343223336"
                    }
                );
        }


        public string ObterStringConexao()
        {
            //return "Server=db4free.net;Port=3306;Database=morusdb;user=morus_admin;password=Morus@2023;";
            return "Server=localhost;Database=morus;user=root;password=root";
        }
    }
}
