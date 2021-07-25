using System.Threading.Tasks;

namespace POS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Colors = new Repository<Color>(context);
            Products = new ProductRepository(context);
            Purchases = new Repository<Purchase>(context);
            Sales = new Repository<Sale>(context);
            Sizes = new Repository<Size>(context);
            Suppliers = new Repository<Supplier>(context);
            Types = new Repository<Type>(context);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public IRepository<T> GetRepository<T>() where T : class
            => new Repository<T>(_context);

        public IRepository<Color> Colors { get; set; }
        public IRepository<Product> Products { get; set; }
        public IRepository<Purchase> Purchases { get; set; }
        public IRepository<Sale> Sales { get; set; }
        public IRepository<Size> Sizes { get; set; }
        public IRepository<Supplier> Suppliers { get; set; }
        public IRepository<Type> Types { get; set; }
    }
}