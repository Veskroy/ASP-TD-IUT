var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapGet("/HealthCkeck", MinimalWebAPI1.Program.HealthCkeck);

app.MapGet("/UnObjectJson", MinimalWebAPI1.Program.UnObjectDeRetour.RetournerUnObjectJson);

app.MapGet("/CalculDouble/{unNombre}", MinimalWebAPI1.Program.RetourneLeDouble);

app.MapGet("/Divise", MinimalWebAPI1.Program.RetournerDivision);
/* -http://localhost:5299/Divise?dividende=20.8&diviseur=4.2- */

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
