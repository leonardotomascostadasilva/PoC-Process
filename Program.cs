using Microsoft.FeatureManagement;
using PoC_Process.Helper;
using PoC_Process.Process;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFeatureManagement(builder.Configuration.GetSection("FeatureManagement"));

builder.Services.AddScoped<AbstractProcess, Process1>();
builder.Services.AddScoped<AbstractProcess, Process2>();
builder.Services.AddScoped<AbstractProcess, Process3>();
builder.Services.AddScoped<IGateway, MyGateway>();
builder.Services.AddScoped<IGateway, MyGateway2>();
builder.Services.AddScoped(typeof(IFireForgetService2<>), typeof(FireForgetService2<>));

builder.Services.AddScoped<IExecuteProcess, ExecuteProcess>();

builder.Services.AddScoped<IFireForgetService, FireForgetService>();
builder.Services.AddScoped<IGateway3, Gateway3>();

//decorator
builder.Services.AddScoped<Gateway4>();
builder.Services.AddScoped<IGateway4>(serviceProvider =>
    new FireForgetService3(serviceProvider.GetRequiredService<Gateway4>()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/processs", async (IExecuteProcess executeProcess) =>
    {
       var results=  await executeProcess.ExecuteAllProcessAsync();
        return results;
    })
    .WithName("processs")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}