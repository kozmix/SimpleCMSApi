using Microsoft.EntityFrameworkCore;
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
    }
}
