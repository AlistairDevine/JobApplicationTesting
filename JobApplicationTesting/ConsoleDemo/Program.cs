using System;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleDemo;

swaggerClient client = new("https://localhost:44390", new HttpClient());

var records = await client.WeatherForecastAsync();

foreach (var r in records)
{
    Console.WriteLine($"{ r.Date }: { r.Summary }");
}