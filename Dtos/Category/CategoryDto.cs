using LearnASP.Dtos.Product;

namespace LearnASP.Dtos.Category
{
    public class CategoryDto
    {
        public Guid id { get; set; }
        public String name { get; set; } = null!;
        public ICollection<ProductDto> products { get; set; }

        public CategoryDto()
        {
            products = new List<ProductDto>();
        }
    }
}
