using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]  // /weather
public class WeatherController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing",
        "Bracing",
        "Hot",
        "Cool",
        "Chilly"
    };
    [HttpGet]
    public IEnumerable<Weather> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Weather()
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20,55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();
    }

    [HttpPost]
    public string Post() => "success";

    [HttpGet]
    [Route("test")]
    public IActionResult Get(int? number)
    {
        if (!number.HasValue)
            return NotFound();
        return new JsonResult(number);
    }
    
    [HttpGet]
    [Route("hello")]
    public IActionResult Hello()
    {
        string hello = Request.Query["hello"];
        if (string.IsNullOrEmpty(hello))
            return NotFound();
        return Content($"<h1>{hello}</h1>", "text/html;charset=utf-8");
    }
}