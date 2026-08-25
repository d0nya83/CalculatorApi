using Calculation.Models;
using CalculatorApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private static List<DefincOpration> defincOprations = new List<DefincOpration>()
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
                    Name = "power",
                    Symbol = "^",
                },
                  new DefincOpration
                {
                     Id = 6,
                    Name = "Increase",
                    Symbol = "++",
                }
            };

        [HttpGet("getOpration")]
        public ActionResult<DefincOpration> GetOpration()
        {

            if (defincOprations != null)
            {
                return Ok(defincOprations);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateOperatore")]
        public ActionResult<DefincOpration> UpdateOperatore(int id, string newOperator)
        {
            
            try { 
                var currentOperator = defincOprations.FirstOrDefault(x => x.Id == id);
                if (currentOperator == null) throw new ArgumentNullException();
                currentOperator.Name = newOperator;
                currentOperator.Symbol = newOperator;
                return Ok(currentOperator);

                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("RemoveCurrentOperator")]
        public ActionResult<DefincOpration> RemoveCurrentOperator (int id)
        {
            var currentOperator = defincOprations.FirstOrDefault(x => x.Id == id);

            defincOprations.Remove(currentOperator);

            return Ok(currentOperator);
        }

        [HttpGet("GetOperationById ")]
        public ActionResult<DefincOpration> GetOperationById (int id)
        {
            var currentOperator = defincOprations.FirstOrDefault(x => x.Id == id);
            defincOprations.Remove(currentOperator);
            return Ok(currentOperator);

        }

        [HttpPost("Calculation")]
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



