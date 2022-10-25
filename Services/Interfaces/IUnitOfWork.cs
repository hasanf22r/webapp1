namespace webapp1.Services.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryService CategoryService { get; }
        IProductService ProductService { get; }
    
        int SaveChange();
    }
}