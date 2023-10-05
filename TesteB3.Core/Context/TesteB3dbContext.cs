using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteB3.Core.Models;

namespace TesteB3.Core.Context
{
    public class TesteB3dbContext : DbContext
    {
        private readonly string connectionString = "Server=ALANFELIPEDESKT\\SQLEXPRESS;Database=TesteB3;Integrated Security=SSPI;TrustServerCertificate=True";

        public TesteB3dbContext(DbContextOptions<TesteB3dbContext> options) : base(options)
        {
        }

        //protected readonly IConfiguration Configuration;

        //public TesteB3dbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Tarefa> Tarefa { get; set; }
    }
}
