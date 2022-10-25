using webapp1.Models;

namespace webapp1.Services.Interfaces
{
    public interface IProductService
    {
        void Add(Product product);
        Product GetOne(int id);
        void Remove(Product product);
        IEnumerable<Product> GetAll();
        void Update(Product product);
    }
}