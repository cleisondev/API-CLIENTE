
using API_CLIENTE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_CLIENTE.Context
{
    public class AppDBContext
    {

        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<Clientes> Cliente { get; set; }
            public DbSet<Contatos> Contatos { get; set; }
            public DbSet<Enderecos> Enderecos { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true)
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataBase"));
            }
        }
    }
}

