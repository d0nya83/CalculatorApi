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
        public decimal division(decimal num1, decimal num2)
        {
            if (num2 == 0M)
            {
                return 0;
            }
            else
            {
                return num1 / num2;
            }

        }
    }
}
