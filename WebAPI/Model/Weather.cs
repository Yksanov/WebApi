namespace WebAPI.Model;

public class Weather
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string Summary { get; set; }
}