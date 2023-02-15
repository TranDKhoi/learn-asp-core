using LearnASP.Dtos.Category;
using LearnASP.Models;

namespace LearnASP.Dtos.Product
{
    public class ProductDto
    {
        public Guid id { get; set; }
        public String name { get; set; } = null!;
        public double price { get; set; }
        public Guid categoryId { get; set; }
        public CategoryDto? category { get; set; }
        //public ICollection<BillDetailDto> billDetails { get; set; }
        public ProductDto()
        {
            //billDetails = new List<BillDetail>();
        }
    }
}
