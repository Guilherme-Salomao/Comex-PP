using Comex.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Comex.Data
{
    public class ComexDbContext : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog=ComexT2Novo;Integrated Security=True;" +
            "Connect Timeout=30;Encrypt=False;" +
            "Trust Server Certificate=False;" +
            "Application Intent=ReadWrite;" +
            "Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
