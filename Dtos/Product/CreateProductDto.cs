using System.ComponentModel.DataAnnotations;

namespace LearnASP.Dtos.Product
{
    public class CreateProductDto
    {
        public string name { get; set; } = null!;
        public double price { get; set; }
        public String categoryId { get; set; } = null!;
    }
}
