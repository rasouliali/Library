using Library.Application.UseCases;
using Library.Persistence;
using Library.WebApi.Extensions.Middleware;
using Library.Persistence.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bearer Auth", Version = "v1" });
    c.AddSecurityDefinition("Authorization", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. <br /> 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      <br />
                        Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityDefinition("UserId", new OpenApiSecurityScheme
    {
        Name = "UserId",
        In = ParameterLocation.Header,
        Description = "User Id",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();


    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });

});

builder.Services.AddTransient<LibraryContextInitialiser>();
//Add methods Extensions
builder.Services.AddInjectionApplication();
builder.Services.AddInjectionPersistence(builder.Configuration);
IWebHostEnvironment env = builder.Environment;

var app = builder.Build();
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    var serviceProvider = app.Services.GetRequiredService<IServiceScopeFactory>();
    using (var scope = serviceProvider.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<LibraryContextInitialiser>();
        initialiser.InitialiseAsync().Wait();//if database does not exist, this line create it and all tables
    }
}
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI( c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Clean Architecture V.1");
        c.RoutePrefix = string.Empty;
    });
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.AddMiddleware();

app.MapControllers();

app.Run();
