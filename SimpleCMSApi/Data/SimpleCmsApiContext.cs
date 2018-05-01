using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using SimpleCMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCMSApi.Data
{
    public class SimpleCmsApiContext : DbContext
    {
        public SimpleCmsApiContext(DbContextOptions<SimpleCmsApiContext> options) : base(options)
        {

        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Sidebar> Sidebar { get; set; }
        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder
        //        .UseMySql(@"Server=localhost;database=SimpleCmsApi;uid=root;pwd=kozmix;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Page>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Content).IsRequired();
            });

            modelBuilder.Entity<Sidebar>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Content).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired();
            });
        }
    }
}
