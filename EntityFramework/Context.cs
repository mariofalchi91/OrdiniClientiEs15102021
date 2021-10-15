using Core.Entita;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EntityFramework
{
    public class Context:DbContext
    {
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Ordine> Ordini { get; set; }
        public Context() : base() { }
        public Context(DbContextOptions<Context> op) : base(op) { }
        protected override void OnConfiguring(DbContextOptionsBuilder op)
        {
            if (!op.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                string connectionStringSQL = config.GetConnectionString("AcademyG");
                op.UseSqlServer(connectionStringSQL);
            }
        }
        protected override void OnModelCreating(ModelBuilder m)
        {
            // entità cliente
            var eC = m.Entity<Cliente>();
            eC.HasKey(c => c.Id);
            eC.Property(c => c.Codice).HasMaxLength(100).IsRequired();
            eC.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            eC.Property(c => c.Cognome).HasMaxLength(100).IsRequired();

            //entità ordine
            var eO = m.Entity<Ordine>();
            eO.HasKey(o => o.Id);
            eO.Property(o => o.Data).IsRequired();
            eO.Property(o => o.Importo).IsRequired();
            eO.Property(o => o.CodOrdine).HasMaxLength(100).IsRequired();
            eO.Property(o => o.CodProdotto).HasMaxLength(100).IsRequired();

            //relazione 1 cliente ha N ordini
            eO.HasOne(o => o.Cliente).WithMany(c => c.Ordini);
            eC.HasMany(c => c.Ordini).WithOne(o => o.Cliente);
        }
    }
}
