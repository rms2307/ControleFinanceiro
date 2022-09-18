using Microsoft.AspNetCore.Mvc.Filters;

namespace ControleFinanceiro.Api.Filters
{
    public class ModelStateValidatorFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            System.Console.WriteLine("===1 - OnActionExecuted===");
            throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            System.Console.WriteLine("===2 - OnActionExecuting===");
            throw new System.NotImplementedException();
        }
    }
}
