using FastEndpoint.Model;

namespace FastEndpoint.Interface
{
    public interface IProductService
    {
        Task<int>Create(Product product);
        Task<List<Product>>GetAll();
        Task<Product>GetById(Guid id);
        Task<bool>Update(Product product);
        Task<bool>Delete(Guid id);
    }
}
