using ControleFinanceiro.Api.ApiModels;
using ControleFinanceiro.Domain.Dtos.FixedCost;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/v1/fixed-costs")]
    [ApiController]
    public class FixedCostsController : ControllerBase
    {
        private readonly IFixedCostService _variedCostsService;

        public FixedCostsController(IFixedCostService variedCostsService)
        {
            _variedCostsService = variedCostsService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obter todos custos fixos.")]
        [ProducesResponseType(typeof(FixedCostResponseDto), StatusCodes.Status200OK)]
        public ActionResult<ApiResponse<IEnumerable<FixedCostResponseDto>>> GetAll()
        {
            var variedCosts = _variedCostsService.GetAll();
            return Ok(new ApiResponse<IEnumerable<FixedCostResponseDto>>(variedCosts));
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Obter um custo fixo pelo id.")]
        [ProducesResponseType(typeof(FixedCostResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public ActionResult<ApiResponse<FixedCostResponseDto>> GetById([FromRoute] int id)
        {
            var variedCost = _variedCostsService.GetById(id);
            return Ok(new ApiResponse<FixedCostResponseDto>(variedCost));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Criar um custo fixo.")]
        [ProducesResponseType(typeof(FixedCostResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public ActionResult<ApiResponse<FixedCostResponseDto>> Add([FromBody] FixedCostAddRequestDto dto)
        {
            _variedCostsService.Add(dto);
            return Created(string.Empty, new ApiResponse<FixedCostAddRequestDto>(dto));
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Atualizar um custo fixo.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public ActionResult Update([FromRoute] int id, [FromQuery] FixedCostFilterDto filter, [FromBody] FixedCostEditRequestDto dto)
        {
            _variedCostsService.Update(id, dto, filter);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Remover um custo fixo.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult Delete([FromRoute] int id, FixedCostFilterDto filter)
        {
            _variedCostsService.Delete(id, filter);
            return NoContent();
        }
    }
}
