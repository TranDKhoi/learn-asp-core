using AutoMapper;
using LearnASP.Core.Contracts;
using LearnASP.Dtos;
using LearnASP.Dtos.Category;
using LearnASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnASP.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {

            var listCate = await _unitOfWork.Category.GetAllCategory();
            var listCateDto = _mapper.Map<IEnumerable<CategoryDto>>(listCate);
            return Ok(new ApiResponse<object>(listCateDto, "Get categories success"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(String id)
        {
            var cate = await _unitOfWork.Category.GetCategoryById(id);
            if (cate != null)
            {
                var cateDto = _mapper.Map<CategoryDto>(cate);
                return Ok(new ApiResponse<CategoryDto>(cateDto, "Get category success"));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto cateDto)
        {

            var res = await _unitOfWork.Category.CreateCategory(cateDto);

            if (res != null)
            {
                var newCateDto = _mapper.Map<CategoryDto>(res);

                return Ok(new ApiResponse<CategoryDto>(newCateDto, "Create category success"));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(String id, CreateCategoryDto cateDto)
        {
            await _unitOfWork.Category.UpdateCategory(id, cateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryById(String id)
        {
            await _unitOfWork.Category.DeleteById(id);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllCategory()
        {
            await _unitOfWork.Category.DeleteAll();
            return NoContent();
        }
    }
}
