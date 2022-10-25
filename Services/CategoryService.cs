using webapp1.Models;
using webapp1.Services.Interfaces;

namespace webapp1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataBaseContext _dataBaseContext;
        public CategoryService(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;

        }
        public void Add(Category category)
        {
            _dataBaseContext.Categories.Add(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _dataBaseContext.Categories.ToList();
        }

        public void Remove(Category category)
        {
            _dataBaseContext.Categories.Remove(category);
        }

        public Category GetOne(int id)
        {
            return _dataBaseContext.Categories.Find(id);
        }


        public void Update(Category product)
        {
            _dataBaseContext.Categories.Update(product);
        }
    }
}