using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            var results = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55)
            }).ToArray();

            //Relational pattern matching: >, <, >=, <=
            //Logical pattern matching: and, or, not

            //Switch statement
            switch ("Test")
            {
                default:
                    break;
            }

            foreach (var record in results)
            {
                //Switch expression
                record.Summary = record.TemperatureC switch
                {
                    < -32 => "Well below Freezing",
                    >= -32 and < 0 => "Freezing",
                    0 or 100 => "Exactly freezing or boiling",
                    > 0 and < 15 => "Cool",
                    >= 15 and < 25 => "Warm",
                    >= 25 => "Hot"
                };
            }

            return Task.FromResult(results);
        }
    }
}
