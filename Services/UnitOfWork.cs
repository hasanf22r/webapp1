using Microsoft.AspNetCore.Identity;
using webapp1.Models;
using webapp1.Services.Interfaces;

namespace webapp1.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly UserManager<AppUser> _userManager;
        public UnitOfWork(DataBaseContext dataBaseContext, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _dataBaseContext = dataBaseContext;
        }
        
        private IProductService _productService;
        public IProductService ProductService
        {
            get => _productService ?? (_productService = new ProductService(_dataBaseContext));
        }

        private ICategoryService _categoryService;
        public ICategoryService CategoryService
        {
            get => _categoryService ?? (_categoryService = new CategoryService(_dataBaseContext));
        }
 

        public int SaveChange()
        {
            return _dataBaseContext.SaveChanges();
        }
    }
}