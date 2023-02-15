using LearnASP.Core.Contracts;
using LearnASP.Dtos;
using LearnASP.Dtos.Product;
using LearnASP.Error;
using LearnASP.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnASP.Core.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly DataContext _context;

        public ProductRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            var res = await _context.Product.Include(b => b.category).ToListAsync();
            return res;
        }

        public async Task<List<Product>> SearchProduct(string search)
        {
            var searchRes = await _context.Product.Where(p => p.name.Contains(search.ToLower())).Include(i => i.category).ToListAsync();
            return searchRes;
        }

        public async Task<Product?> GetById(string id)
        {
            var res = await _context.Product.FirstOrDefaultAsync(i => i.id.ToString() == id);
            if (res is null)
                throw new ApiException("Product not found", 400);

            return res;
        }

        public async Task<Product> CreateProduct(CreateProductDto productDto)
        {
            var cate = await _context.Category.SingleOrDefaultAsync(e => e.id.ToString() == productDto.categoryId);
            if (cate is null)
            {
                throw new ApiException("Category not found", 400);
            }


            var nPro = new Product
            {
                id = Guid.NewGuid(),
                name = productDto.name,
                price = productDto.price,
                categoryId = cate.id,
            };

            await _context.Product.AddAsync(nPro);
            _context.SaveChanges();

            return nPro;
        }

        public async Task DeleteById(string id)
        {
            var prod = await _context.Product.SingleOrDefaultAsync(i => i.id.ToString() == id);

            if (prod is null)
            {
                throw new ApiException("Product not found", 400);
            }
            else
            {
                _context.Product.Remove(prod);
                _context.SaveChanges();
            }
        }

        public async Task DeleteAll()
        {
            var toDelete = await _context.Product.ToListAsync();
            _context.Product.RemoveRange(toDelete);
            _context.SaveChanges();
        }
    }
}
