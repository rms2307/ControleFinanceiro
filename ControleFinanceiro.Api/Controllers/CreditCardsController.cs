using ControleFinanceiro.Api.ApiModels;
using ControleFinanceiro.Domain.Dtos.CreditCard;
using ControleFinanceiro.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/v1/credit-cards")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obter todos cartões de credito.")]
        [ProducesResponseType(typeof(CreditCardResponseDto), StatusCodes.Status200OK)]
        public ActionResult<ApiResponse<IEnumerable<CreditCardResponseDto>>> GetAll()
        {
            var creditCards = _creditCardService.GetAll();
            return Ok(new ApiResponse<IEnumerable<CreditCardResponseDto>>(creditCards));
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Obter um cartão de credito pelo id.")]
        [ProducesResponseType(typeof(CreditCardResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public ActionResult<ApiResponse<CreditCardResponseDto>> GetById([FromRoute] int id)
        {
            var creditCard = _creditCardService.GetById(id);
            return Ok(new ApiResponse<CreditCardResponseDto>(creditCard));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastrar um cartão de credito.")]
        [ProducesResponseType(typeof(CreditCardResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public ActionResult<ApiResponse<CreditCardResponseDto>> Add([FromBody] CreditCardRequestDto dto)
        {
            int id = _creditCardService.Add(dto);
            return Created($"/api/v1/credit-cards/{id}", new ApiResponse<CreditCardRequestDto>(dto));
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Atualizar um cartão de credito.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public ActionResult Update([FromRoute] int id, [FromBody] CreditCardRequestDto dto)
        {
            _creditCardService.Update(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Remover um cartão de credito.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public ActionResult Delete([FromRoute] int id)
        {
            _creditCardService.Delete(id);
            return NoContent();
        }
    }
}
