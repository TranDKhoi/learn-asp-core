using LearnASP.Dtos.Category;
using LearnASP.Models;

namespace LearnASP.Core.Contracts
{
    public interface ICategoryRepo
    {
        public Task<List<Category>> GetAllCategory();
        public Task<Category> GetCategoryById(string id);
        public Task<Category> CreateCategory(CreateCategoryDto newCate);
        public Task UpdateCategory(String id, CreateCategoryDto newCate);
        public Task DeleteById(string id);
        public Task DeleteAll();
    }
}
