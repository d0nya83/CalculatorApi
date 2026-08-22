using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        [HttpPost("sum")]
        public decimal sum(decimal num1, decimal num2)
        {
            return num1 + num2;
        }
        [HttpPost("minus")]
        public decimal minus(decimal num1, decimal num2)
        {
            return num1 - num2;
        }
        [HttpPost("multiplication")]
        public decimal multiplication(decimal num1, decimal num2)
        {
            return num1 * num2;

        }
        [HttpPost("division")]
        public string division(decimal num1, decimal num2)
        {
            try
            {
                return ("the resualt is : " + (num1 / num2).ToString());
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(DivideByZeroException))
                    return ("dont do that again maaan the erroe\r is:  " + ex.Message);
                return ex.Message;
            }

        }
    }
}
