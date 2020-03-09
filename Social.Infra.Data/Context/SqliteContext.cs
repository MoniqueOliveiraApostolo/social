using System;
using Social.Domain.Entities;
using Social.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Social.Infra.Data.Context
{
    public class SqliteContext : DbContext
    {
        public DbSet<Contato> Contato { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=Social.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contato>(new ContatoMap().Configure);
        }
    }
}
