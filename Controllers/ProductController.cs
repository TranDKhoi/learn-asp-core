using AutoMapper;
using LearnASP.Core.Contracts;
using LearnASP.Dtos;
using LearnASP.Dtos.Product;
using LearnASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LearnASP.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _unitOfWork.Product.GetAll();
            var productsDto = _mapper.Map<ICollection<ProductDto>>(products);
            return Ok(new ApiResponse<ICollection<ProductDto>>(productsDto, "Get all product success"));
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchProduct([Required] String search)
        {
            var products = await _unitOfWork.Product.SearchProduct(search);
            var productsDto = _mapper.Map<ICollection<ProductDto>>(products);
            return Ok(new ApiResponse<ICollection<ProductDto>>(productsDto, "Get all product success"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(String id)
        {
            var res = await _unitOfWork.Product.GetById(id);
            var productDto = _mapper.Map<ProductDto>(res);
            return Ok(new ApiResponse<ProductDto>(productDto, "Get product success"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto product)
        {
            var res = await _unitOfWork.Product.CreateProduct(product);
            var productDto = _mapper.Map<ProductDto>(res);
            return Ok(new ApiResponse<ProductDto>(productDto, "Create prod success"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(String id)
        {
            await _unitOfWork.Product.DeleteById(id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await _unitOfWork.Product.DeleteAll();
            return NoContent();
        }
    }
}
