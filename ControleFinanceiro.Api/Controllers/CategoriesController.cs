using ControleFinanceiro.Api.ApiModels;
using ControleFinanceiro.Domain.Dtos.Category;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obter todas categorias.")]
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status200OK)]
        public ActionResult<ApiResponse<IEnumerable<CategoryResponseDto>>> GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(new ApiResponse<IEnumerable<CategoryResponseDto>>(categories));
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Obter uma categoria pelo id.")]
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public ActionResult<ApiResponse<CategoryResponseDto>> GetById([FromRoute] int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(new ApiResponse<CategoryResponseDto>(category));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Criar uma categoria.")]
        [ProducesResponseType(typeof(CategoryResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public ActionResult<ApiResponse<CategoryResponseDto>> Add([FromBody] CategoryRequestDto dto)
        {
            int id = _categoryService.Add(dto);
            return Created($"/api/v1/categories/{id}", new ApiResponse<CategoryRequestDto>(dto));
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Atualizar uma categoria.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public ActionResult Update([FromRoute] int id, [FromBody] CategoryRequestDto dto)
        {
            _categoryService.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Remover uma categoria.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult Delete([FromRoute] int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }
    }
}
