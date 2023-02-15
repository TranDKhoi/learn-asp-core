using LearnASP.Core.Contracts;
using LearnASP.Dtos.Category;
using LearnASP.Error;
using LearnASP.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnASP.Core.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly DataContext _context;

        public CategoryRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategory(CreateCategoryDto newCate)
        {
            var cate = new Category
            {
                id = Guid.NewGuid(),
                name = newCate.name,
            };

            await _context.AddAsync(cate);
            _context.SaveChanges();
            return cate;
        }

        public async Task DeleteAll()
        {
            var cates = await _context.Category.ToListAsync();
            _context.Category.RemoveRange(cates);
            _context.SaveChanges();
        }

        public async Task DeleteById(string id)
        {
            var cate = await _context.Category.SingleOrDefaultAsync(i => i.id.ToString() == id);
            if (cate != null)
            {
                _context.Category.Remove(cate);
                _context.SaveChanges();
            }
            else
            {
                throw new ApiException("Category not found", 400);
            }
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _context.Category.Include(i => i.products).ToListAsync();
        }

        public async Task<Category> GetCategoryById(string id)
        {
            var cate = await _context.Category.SingleOrDefaultAsync(i => i.id.ToString() == id);
            if (cate != null)
                return cate;
            else
                throw new ApiException("Category not found", 400);
        }

        public async Task UpdateCategory(String id, CreateCategoryDto newCate)
        {
            var cate = await _context.Category.FirstOrDefaultAsync(i => i.id.ToString() == id);
            if (cate != null)
            {
                cate.name = newCate.name;
                await _context.SaveChangesAsync();
            }
        }
    }
}
