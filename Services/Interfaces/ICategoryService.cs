using webapp1.Models;

namespace webapp1.Services.Interfaces
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Remove(Category category);
        IEnumerable<Category> GetAll();
        Category GetOne(int id);
        void Update(Category product);
    }
}