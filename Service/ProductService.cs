using FastEndpoint.dbContext;
using FastEndpoint.Interface;
using FastEndpoint.Model;
using Microsoft.EntityFrameworkCore;

namespace FastEndpoint.Service
{
    public class ProductService : IProductService
    {
        private readonly ProjectContext _projectContext;
        public ProductService(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<int> Create(Product product)
        {
            try
            {
                if (product == null)
                    return 0;

                await _projectContext.Products.AddAsync(product);
                int rows = await _projectContext.SaveChangesAsync();

                return rows > 0 ? 1 : 0;
            }
            catch (Exception)
            {
                return -1; // error
            }



        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
              var finddataa = await _projectContext.Products.FindAsync(id);
                    if (finddataa != null)
                    {
                        _projectContext.Products.Remove(finddataa);
                        await _projectContext.SaveChangesAsync();
                        return true;

                    }
                   

                
            }
            catch (Exception ex)
            {
                return false;

            }
            return false;
        }

        public async Task<List<Product>> GetAll()
        {
            var dbdata = await _projectContext.Products.ToListAsync();
            return dbdata.ToList();
        }

        public async Task<Product> GetById(Guid id)
        {
            var dbdata = await _projectContext.Products.FindAsync(id);
            return dbdata;
        }

        public async Task<bool> Update(Product product)
        {
            var dbdata = await _projectContext.Products.FindAsync(product.Id);
            if (dbdata != null)
            {
                dbdata.Price = product.Price;
                dbdata.Name = product.Name;
                dbdata.Stock=product.Stock;
                await _projectContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
