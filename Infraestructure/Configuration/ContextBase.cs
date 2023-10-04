using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            SeedIdentityRoles(builder);
        }


        private void SeedIdentityRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                    new IdentityRole() { Name = "Sindico", ConcurrencyStamp = "2", NormalizedName = "SINDICO" },
                    new IdentityRole() { Name = "Morador", ConcurrencyStamp = "3", NormalizedName = "MORADOR" },
                    new IdentityRole() { Name = "Porteiro", ConcurrencyStamp = "4", NormalizedName = "PORTEIRO" }
                );
        }


        public string ObterStringConexao()
        {
            return "server=localhost;database=morus;user=root;password=12345678";
        }
    }
}
