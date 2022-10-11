using ControleFinanceiro.Api.ApiModels;
using ControleFinanceiro.Domain.Dtos.FixedSpend;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/v1/fixed-spends")]
    [ApiController]
    public class FixedSpendsController : ControllerBase
    {
        private readonly IFixedSpendService _variedCostsService;

        public FixedSpendsController(IFixedSpendService variedCostsService)
        {
            _variedCostsService = variedCostsService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obter todos custos fixos.")]
        [ProducesResponseType(typeof(FixedSpendResponseDto), StatusCodes.Status200OK)]
        public ActionResult<ApiResponse<IEnumerable<FixedSpendResponseDto>>> GetAll()
        {
            var variedSpends = _variedCostsService.GetAll();
            return Ok(new ApiResponse<IEnumerable<FixedSpendResponseDto>>(variedSpends));
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Obter um custo fixo pelo id.")]
        [ProducesResponseType(typeof(FixedSpendResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public ActionResult<ApiResponse<FixedSpendResponseDto>> GetById([FromRoute] int id)
        {
            var variedCost = _variedCostsService.GetById(id);
            return Ok(new ApiResponse<FixedSpendResponseDto>(variedCost));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Criar um custo fixo.")]
        [ProducesResponseType(typeof(FixedSpendResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public ActionResult<ApiResponse<FixedSpendResponseDto>> Add([FromBody] FixedSpendAddRequestDto dto)
        {
            _variedCostsService.Add(dto);
            return Created(string.Empty, new ApiResponse<FixedSpendAddRequestDto>(dto));
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Atualizar um custo fixo.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public ActionResult Update([FromRoute] int id, [FromQuery] FixedSpendFilterDto filter, [FromBody] FixedSpendEditRequestDto dto)
        {
            _variedCostsService.Update(id, dto, filter);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Remover um custo fixo.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult Delete([FromRoute] int id, FixedSpendFilterDto filter)
        {
            _variedCostsService.Delete(id, filter);
            return NoContent();
        }
    }
}
