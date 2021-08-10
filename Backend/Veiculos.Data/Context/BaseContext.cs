using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Veiculos.Data.Context
{
    public class BaseContext : DbContext
    {
        protected string _conn;
        public BaseContext()
        {

        }
        public BaseContext(string conn) : base() => _conn = conn;

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_conn))
                optionsBuilder.UseSqlServer(_conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Map.VeiculoMap());

            modelBuilder.HasDefaultSchema("dbo");

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Domain.Entities.Veiculo> Veiculo { get; set; }
        
    }
}
