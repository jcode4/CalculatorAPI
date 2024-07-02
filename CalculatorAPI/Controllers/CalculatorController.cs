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
        public ActionResult<List<string>> SetFirstNumber(string location, double number)
        {
            _numberStore.StoreNumber(location, number, 0);
            return _calculator.GetAvailableOperations(location);
        }

        [HttpPost("setSecondNumber/{location}")]
        public ActionResult<List<string>> SetSecondNumber(string location, double number)
        {
            _numberStore.StoreNumber(location, number, 1);
            return _calculator.GetAvailableOperations(location);
        }

        [HttpPost("calculation/{location}")]
        public ActionResult<double> calculation(string location, string operation)
        {
            return _calculator.PerformCalculation(location, operation);
        }
    }

}
