using CalculatorAPI.Interfaces;
using CalculatorAPI.Models;
using CalculatorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumberStoreController : ControllerBase
    {
        private readonly INumberStore _numberStore;
        private readonly ICalculator _calculator;
        public NumberStoreController(INumberStore numberStore, ICalculator calculator)
        {
            _numberStore = numberStore;
            _calculator = calculator;
        }

        // Endpoint to store a number
        [HttpPost("store")]
        public IActionResult StoreNumber([FromBody] NumberRequestModel model)
        { 
            // Validate input (e.g., location, number, supplier, position)
            if (string.IsNullOrEmpty(model.Location) || model.Number <= 0 || string.IsNullOrEmpty(model.Supplier) || model.Position < 1)
            {
                return BadRequest("Invalid input. Please provide valid location, number, supplier, and position.");
            }

            // Handle any exceptions (e.g., database errors, validation failures)
            try
            {
                // Call the NumberStore service method to store the number
                _numberStore.StoreNumber(model);
                return CreatedAtAction(nameof(GetNumbersForLocation), new { location = model.Location }, "Number stored successfully");
            }
            catch (Exception ex)
            {
               // Return appropriate response (e.g., 201 Created or 400 Bad Request)
                return StatusCode(500, $"Error storing number: {ex.Message}");
            }
            
            
            return Ok("Number stored successfully");
        }

        // Endpoint to get numbers for a location
        [HttpGet("get/{location}")]
        public IActionResult GetNumbersForLocation(string location)
        {
            // Call the NumberStore service method to retrieve numbers for the specified location
            var numbers = _numberStore.GetNumbersForLocation(location);
            if (numbers.Count == 0)
            {
                // Return a 404 Not Found status code if no numbers are found
                return NotFound();
            }

            // Create the view model
            var model = new LocationNumbersModel { locationNumbers = numbers };
            // Return the list of numbers as JSON
            return Ok(model);
        }

 
        // ClearNumbersForLocation
        [HttpDelete("clear/{location}")]
        public IActionResult ClearNumbersForLocation(string location)
        {
            _numberStore.ClearNumbersForLocation(location);
            return Ok($"Numbers cleared for location: {location}");
        }

        // CalculateForLocation
        [HttpGet("calculate/{location}/{operation}")]
        public IActionResult CalculateForLocation(string location, string operation)
        {
            var numbers = _numberStore.GetNumbersForLocation(location);

            if (numbers.Count < 2)
            {
                return BadRequest("Insufficient numbers for calculation.");
            }

            try
            {
                var result = _numberStore.CalculateForLocation(location, _calculator, operation);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Invalid operation: {ex.Message}");
            }
        }


    }
}
//private static readonly string[] Summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//private readonly ILogger<WeatherForecastController> _logger;

//public WeatherForecastController(ILogger<WeatherForecastController> logger)
//{
//    _logger = logger;
//}

//[HttpGet(Name = "GetWeatherForecast")]
//public IEnumerable<WeatherForecast> Get()
//{
//    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//    {
//        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//        TemperatureC = Random.Shared.Next(-20, 55),
//        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//    })
//    .ToArray();
//}