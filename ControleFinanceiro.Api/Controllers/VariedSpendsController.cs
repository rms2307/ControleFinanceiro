using ControleFinanceiro.Api.ApiModels;
using ControleFinanceiro.Domain.Dtos.VariedSpend;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/v1/varied-spends")]
    [ApiController]
    public class VariedSpendsController : ControllerBase
    {
        private readonly IVariedSpendService _variedCostsService;

        public VariedSpendsController(IVariedSpendService variedCostsService)
        {
            _variedCostsService = variedCostsService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obter todos custos variados.")]
        [ProducesResponseType(typeof(VariedSpendResponseDto), StatusCodes.Status200OK)]
        public ActionResult<ApiResponse<IEnumerable<VariedSpendResponseDto>>> GetAll()
        {
            var variedCosts = _variedCostsService.GetAll();
            return Ok(new ApiResponse<IEnumerable<VariedSpendResponseDto>>(variedCosts));
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Obter um custo variado pelo id.")]
        [ProducesResponseType(typeof(VariedSpendResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public ActionResult<ApiResponse<VariedSpendResponseDto>> GetById([FromRoute] int id)
        {
            var variedCost = _variedCostsService.GetById(id);
            return Ok(new ApiResponse<VariedSpendResponseDto>(variedCost));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Criar um custo variado.")]
        [ProducesResponseType(typeof(VariedSpendResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public ActionResult<ApiResponse<VariedSpendResponseDto>> Add([FromBody] VariedSpendRequestDto dto)
        {
            int id = _variedCostsService.Add(dto);
            return Created($"/api/v1/varied-costs/{id}", new ApiResponse<VariedSpendRequestDto>(dto));
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Atualizar um custo variado.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public ActionResult Update([FromRoute] int id, [FromBody] VariedSpendRequestDto dto)
        {
            _variedCostsService.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Remover um custo variado.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult Delete([FromRoute] int id)
        {
            _variedCostsService.Delete(id);
            return NoContent();
        }
    }
}
