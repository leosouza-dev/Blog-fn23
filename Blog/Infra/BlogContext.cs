using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog.Infra
{
    public class BlogContext : DbContext
    {

        // Classe que vai ser mapeada para uma tabela no DB
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Acessar o AppSettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            // recuperar connection string
            IConfiguration configuration = builder.Build();
            string stringConexao = configuration.GetConnectionString("Blog");

            optionsBuilder.UseSqlServer(stringConexao);
        }
    }
}
