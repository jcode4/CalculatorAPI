using CalculatorAPI.Interfaces;
using CalculatorAPI.Models;
using CalculatorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CalculatorAPI.Controllers
{
    // CalculatorController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator _calculator;
        private readonly INumberStore _numberStore;
        public CalculatorController(ICalculator calculator, INumberStore numberStore)
        {
            _calculator = calculator;
            _numberStore = numberStore;
        }

        [HttpPost("setFirstNumber/{location}")]
        [Produces("application/json")]
        public ActionResult<List<string>> SetFirstNumber(string location, [FromBody] double number)
        {
            _numberStore.StoreNumber(location, number, 0);
            return _calculator.GetAvailableOperations(location);
        }


        [HttpPost("setSecondNumber/{location}")]
        [Produces("application/json")] // Specify JSON response
        public ActionResult<List<string>> SetSecondNumber(string location, [FromBody] double number)
        {
            Console.WriteLine($"Setting second number {number} for location {location}");
            _numberStore.StoreNumber(location, number, 1);
            var operations = _calculator.GetAvailableOperations(location);
            Console.WriteLine($"Allowed operations after setting second number: {string.Join(",", operations)}");
            return operations;
        }

        [HttpPost("calculation/{location}")]
       // [Produces("application/json")] // Specify JSON response
        public ActionResult<double> Calculation(string location, [FromBody] string operation)
        {
            try
            {
                return _calculator.PerformCalculation(location, operation);
            }
            catch (Exception ex)
            {
                // Log exception or handle as needed
                Console.WriteLine($"Error in calculation for location {location}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
