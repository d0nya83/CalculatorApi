using Calculation.Models;
using CalculatorApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        [HttpGet("getOpration")]
        public ActionResult<DefincOpration> GetOpration()
        {

            var donya = new List<DefincOpration>
            {
                new DefincOpration
                {
                    Id = 0,
                    Name = "add",
                    Symbol = "+",
                },
                new DefincOpration
                {
                    Id = 1,
                    Name = "mines",
                    Symbol = "-",
                },
                new DefincOpration
                {
                    Id = 2,
                    Name = "division",
                    Symbol = "/",
                },
                new DefincOpration
                {
                    Id = 3,
                    Name = "Multiplication",
                    Symbol = "*",
                },
                new DefincOpration
                {
                    Id = 4,
                    Name = "Percentage",
                    Symbol = "%",
                },
                 new DefincOpration
                {
                     Id = 5,
                    Name = "^",
                    Symbol = "power",
                }
            };

            if (donya != null)
            {
                return Ok(donya);
            }
            else
            {
                return BadRequest();
            }
        }
        
        [HttpPost("dff")]
        public ActionResult<CalculationResponse> Calculation(CalculationRequest calulationRequest)
        {
            try
            {
                decimal results = 0;

                switch (calulationRequest.Operation)
                {

                    case "add":
                    case "+":
                        results = calulationRequest.Number1 + calulationRequest.Number2;
                        break;

                    case "minus":
                    case "-":
                        results = calulationRequest.Number1 - calulationRequest.Number2;
                        break;

                    case "multiplication":
                    case "*":
                        results = calulationRequest.Number1 * calulationRequest.Number2;
                        break;

                    case "division":
                    case "/":
                        results = calulationRequest.Number1 / calulationRequest.Number2;
                        break;


                }

                return Ok(new CalculationResponse
                {
                    Success = true,
                    Message = "عملیات " + calulationRequest.Operation + " با موفقیت انجام شد...",
                    Result = results
                }

                   );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

// [HttpPost("minus")]
// public IActionResult minus(decimal num1, decimal num2)
// {
//     try
//    {
//      return Ok(num1 - num2);
//  }
//   catch (Exception ex)
//            {
//                //return BadRequest(ex.Message);


//            }
//        }

//        [HttpPost("multiplication")]
//        public IActionResult multiplication(decimal num1, decimal num2)
//        {
//            try
//            {
//                return Ok(num1 * num2);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPost("division")]
//        public IActionResult division(decimal num1, decimal num2)
//        {
//            try
//            {
//                return Ok(num1 / num2);
//            }
//            catch (Exception ex)
//            {
//                if (ex.GetType() == typeof(DivideByZeroException))
//                    return BadRequest("dont do that again maaan the erroe\r is:  " + ex.Message);
//                return BadRequest(ex.Message);
//            }

//        }

//        [HttpGet("help")]
//        public IActionResult help()
//        {
//            return Ok("this is a calculator for +*-/ ...");
//        }

//    }
//}

