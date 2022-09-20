using ControleFinanceiro.Api.ApiModels;
using ControleFinanceiro.Domain.Dtos;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<ApiResponse<IEnumerable<CategoryResponseDto>>> GetAll()
        {
            var categories = _categoryService.GetAll();
            return new ApiResponse<IEnumerable<CategoryResponseDto>>(categories);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ApiResponse<CategoryResponseDto>> GetById(int id)
        {
            var category = _categoryService.GetById(id);
            return new ApiResponse<CategoryResponseDto>(category);
        }
    }
}
