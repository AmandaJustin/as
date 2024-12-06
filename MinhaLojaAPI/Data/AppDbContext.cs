using Microsoft.EntityFrameworkCore;

namespace MinhaLojaAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public required DbSet<Pedido> Pedidos { get; set; }
        public required DbSet<Fornecedor> Fornecedores { get; set; }
    }
}