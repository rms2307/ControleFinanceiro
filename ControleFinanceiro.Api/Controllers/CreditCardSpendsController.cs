using ControleFinanceiro.Api.ApiModels;
using ControleFinanceiro.Domain.Dtos.CreditCard;
using ControleFinanceiro.Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/v1/credit-cards")]
    [ApiController]
    public class CreditCardSpendsController : ControllerBase
    {
        private readonly IAddSpendInCreditCardUseCase _addSpendInCreditCardUseCase;

        public CreditCardSpendsController(IAddSpendInCreditCardUseCase addSpendInCreditCardUseCase)
        {
            _addSpendInCreditCardUseCase = addSpendInCreditCardUseCase;
        }

        [HttpPost("{creditCardId:int}/spends")]
        [SwaggerOperation(Summary = "Adicionar um gasto a um cartão de credito")]
        [ProducesResponseType(typeof(CreditCardSpendResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status409Conflict)]
        public ActionResult<ApiResponse<CreditCardSpendResponseDto>> Add([FromRoute] int creditCardId, [FromBody] CreditCardSpendRequestDto request)
        {
            _addSpendInCreditCardUseCase.AddSpendInCreditCard(creditCardId, request);
            return Created($"/api/v1/credit-cards/{creditCardId}/spends", new ApiResponse<dynamic>(request));
        }
    }
}
