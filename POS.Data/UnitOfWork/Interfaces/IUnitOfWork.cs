namespace POS.Data
{
    public interface IUnitOfWork
    {
        public IRepository<Color> Colors { get; set; }
        public IRepository<Product> Products { get; set; }
        public IRepository<Purchase> Purchases { get; set; }
        public IRepository<Sale> Sales { get; set; }
        public IRepository<Size> Sizes { get; set; }
        public IRepository<Supplier> Suppliers { get; set; }
        public IRepository<Type> Types { get; set; }
    }
}