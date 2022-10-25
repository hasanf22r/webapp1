using webapp1.Models;
using webapp1.Services.Interfaces;

namespace webapp1.Services
{
    public class ProductService : IProductService
    {
        private readonly DataBaseContext _dataBaseContext;
        public ProductService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;

        }
        public void Add(Product product)
        {
            _dataBaseContext.Products.Add(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _dataBaseContext.Products.ToList();
        }

        public Product GetOne(int id)
        {
            return _dataBaseContext.Products.Find(id);
        }

        public void Update(Product product)
        {
            _dataBaseContext.Products.Update(product);
        }
        public void Remove(Product product)
        {
            _dataBaseContext.Products.Remove(product);
        }
    }
}