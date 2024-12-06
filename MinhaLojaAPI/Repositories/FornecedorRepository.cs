using MinhaLojaAPI.Data;

namespace MinhaLojaAPI.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;

        public FornecedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Fornecedor> GetAll() => _context.Fornecedores.ToList();

        public Fornecedor GetById(int id)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return _context.Fornecedores.Find(id);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public void Add(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
        }

        public void Update(Fornecedor fornecedor)
        {
            _context.Fornecedores.Update(fornecedor);
        }

        public void Delete(int id)
        {
            var fornecedor = GetById(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}