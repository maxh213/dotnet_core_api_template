using Api.DataAccess;
using Api.DataAccess.Repositories;
using Api.DataAccess.Repositories.Database;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddScoped<IUserRepository, PostgresRepository>();

builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(
                builder.Configuration.GetValue<string>("AllowedOrigins") ?? "http://localhost:5100")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.WebHost.UseUrls("http://*:60000");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors();
app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
