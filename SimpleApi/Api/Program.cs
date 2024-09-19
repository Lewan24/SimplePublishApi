using System.Diagnostics;
using Api.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AppSettings appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

if (!string.IsNullOrWhiteSpace(appSettings.HostingUrls))
    builder.WebHost.UseUrls(appSettings.HostingUrls);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/updaterepo", () =>
    {
        try
        {
            var processInfo = new ProcessStartInfo("update.bat")
            {
                WorkingDirectory = string.IsNullOrWhiteSpace(appSettings.ExecuteFilePath) ? 
                    Directory.GetCurrentDirectory() : 
                    appSettings.ExecuteFilePath,
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(processInfo);
            return Results.Ok("Update started.");
        }
        catch (Exception ex)
        {
            return Results.Problem($"Error: {ex.Message}");
        }
    })
    .WithName("UpdateQuestsRepo")
    .WithOpenApi();

app.Run();