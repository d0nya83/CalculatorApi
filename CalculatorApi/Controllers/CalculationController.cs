using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        [HttpPost("sum")]
        public IActionResult sum(decimal num1, decimal num2)
        {
            try
            {
                return Ok(num1 + num2);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("minus")]
        public IActionResult minus(decimal num1, decimal num2)
        {
            try
            {
                return Ok(num1 - num2);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);


            }
        }

        [HttpPost("multiplication")]
        public IActionResult multiplication(decimal num1, decimal num2)
        {
            try
            {
                return Ok(num1 * num2);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("division")]
        public IActionResult division(decimal num1, decimal num2)
        {
            try
            {
                return Ok(num1 / num2);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(DivideByZeroException))
                    return BadRequest("dont do that again maaan the erroe\r is:  " + ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}
 
