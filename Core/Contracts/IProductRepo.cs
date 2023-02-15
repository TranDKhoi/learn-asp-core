using LearnASP.Dtos.Product;
using LearnASP.Models;

namespace LearnASP.Core.Contracts
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetAll();
        public Task<List<Product>> SearchProduct(String search);  
        public Task<Product?> GetById(String id);
        public Task<Product> CreateProduct(CreateProductDto id);
        public Task DeleteById(String id);
        public Task DeleteAll();
    }
}
