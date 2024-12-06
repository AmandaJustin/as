using MinhaLojaAPI.Data;

namespace MinhaLojaAPI.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pedido> GetAll() => _context.Pedidos.ToList();

        public Pedido GetById(int id)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return _context.Pedidos.Find(id);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public void Add(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public void Update(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
        }

        public void Delete(int id)
        {
            var pedido = GetById(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}