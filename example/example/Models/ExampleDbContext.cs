using example.Models.EntityModel.Produtos;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;

namespace example.Models
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Produto> produto { get; set; }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await Database.ExecuteSqlRawAsync(sql, parameters);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>();
        }
    }
}
