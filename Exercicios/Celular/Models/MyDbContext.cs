using Microsoft.EntityFrameworkCore;
namespace Celular.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Item> Items { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
